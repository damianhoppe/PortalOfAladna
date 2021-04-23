using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderBehaviour : MonoBehaviour, IOnCursorPositionChanged
{
    [SerializeField]
    private List<Building> buildings;
    [SerializeField]
    private float defaultZBuilding;
    [SerializeField]
    private float defaultZPreview;

    private GridManager gridManager;
    private GameObject buildingPreview;
    private Building building;
    private BuildingStatusBehaviour buildingStatus;
    private CursorBehaviour cursor;
    private Mode mode;
    private SpriteRenderer buildingReqSprite;
    private int buildingInitialized = 0;

    void Start()
    {
        this.gridManager = FindObjectOfType<GridManager>();
        this.buildingStatus = FindObjectOfType<BuildingStatusBehaviour>();
        cursor = FindObjectsOfType<CursorBehaviour>()[0];
        cursor.addOnPositionChangedListener(this);
        mode = Mode.NONE;
        this.buildingReqSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(this.buildingInitialized > 0)
        {
            if (this.buildingInitialized == 2)
            {
                this.buildingReqSprite.size = new Vector2((float)this.building.requiredMinimalDistance * 2 + 1, (float)this.building.requiredMinimalDistance * 2 + 1);
                this.buildingReqSprite.enabled = true;
                onPositionChanged(cursor.getPosition(), cursor.getPosition());
                this.buildingInitialized = 0;
            }
            else
            {
                this.buildingInitialized++;
            }
        }
        if(this.mode == Mode.BUILDING)
        {
            this.buildingPreview.transform.position = new Vector3(cursor.transform.position.x, cursor.transform.position.y, this.defaultZPreview);
            this.buildingReqSprite.transform.position = this.buildingPreview.transform.position;
        }
        if (Input.GetMouseButtonDown(0) && this.mode != Mode.NONE)
        {
            Position position = cursor.getPosition();
            switch (this.mode)
            {
                case Mode.BUILDING:
                    if (this.buildingInitialized != 0)
                        break;
                    if (building.canBuild() == BuildingStatusBehaviour.Status.ALLOW_BUILDING)
                    {
                        GameObject buildingObject = Instantiate(buildingPreview);
                        Building buildingTemp = buildingObject.GetComponent<Building>();
                        buildingTemp.setPosition(position);
                        Debug.Log("Test: " + buildingTemp.getBuildingRequirements().positionsToCheck.Count);
                        buildingObject.name = buildingTemp.getName();
                        buildingObject.transform.position = new Vector3(cursor.getPosition().x, cursor.getPosition().y, this.defaultZBuilding);
                        gridManager.addStructure((Structure)buildingTemp, position.getX(), position.getY());
                        buildingTemp.setEnabled(true);
                        buildingTemp.subtractRequirements();
                    }
                    break;
                case Mode.DESTRUCTION:
                    building = (Building)this.gridManager.getStructure(position.x, position.y);
                    if (building != null)
                    {
                        building.destroy();
                    }
                    break;
            }
        }
    }

    public void onPositionChanged(Position oldPosition, Position newPosition)
    {
        if (this.mode == Mode.BUILDING)
        {
            this.building.setPosition(new Position(newPosition));
            BuildingStatusBehaviour.Status status = this.building.canBuild();
            Debug.Log(status);
            if (status == BuildingStatusBehaviour.Status.ALLOW_BUILDING)
            {
                this.buildingReqSprite.color = new Color(0,255,0,0.25f);
                this.cursor.setColor(Color.green);
            }
            else
            {
                this.buildingReqSprite.color = new Color(255, 0, 0, 0.25f);
                this.cursor.setColor(Color.red);
            }
            this.buildingStatus.setStatus(status);
        }
    }

    private void setBuildingPreviewPosition(Position pos)
    {
        this.buildingPreview.transform.position = pos.toVector3(this.defaultZPreview);
    }

    public List<Building> getBuildings()
    {
        return this.buildings;
    }

    public Mode getBuildingMode()
    {
        return this.mode;
    }

    public void setBuildingMode(Mode newMode, GameObject building = null)
    {
        this.cursor.resetColor();
        switch (this.mode)
        {
            case Mode.BUILDING:
                Destroy(this.buildingPreview);
                buildingPreview = null;
                this.buildingReqSprite.enabled = false;
                this.buildingStatus.setStatus(BuildingStatusBehaviour.Status.NONE);
                break;
        }
        this.mode = newMode;
        switch (this.mode)
        {
            case Mode.BUILDING:
                if (building == null)
                {
                    setBuildingMode(Mode.NONE);
                    break;
                }
                this.buildingPreview = Instantiate(building);
                Structure structure = this.buildingPreview.GetComponent<Structure>();
                this.buildingPreview.name = structure.getName() + " - preview";

                this.building = this.buildingPreview.GetComponent<Building>();
                if (this.building == null)
                {
                    setBuildingMode(Mode.NONE);
                    break;
                }
                setBuildingPreviewPosition(cursor.getPosition());
                this.building.setPosition(cursor.getPosition());
                this.buildingInitialized = 1;
                this.buildingStatus.setStatus(BuildingStatusBehaviour.Status.NONE);
                break;
            case Mode.NONE:
                this.buildingStatus.setStatus(BuildingStatusBehaviour.Status.NONE);
                break;
            case Mode.DESTRUCTION:
                this.cursor.setColor(Color.red);
                this.buildingStatus.setStatus(BuildingStatusBehaviour.Status.DESTRUCTION);
                break;
        }
    }

    public enum Mode
    {
        NONE, BUILDING, DESTRUCTION
    }
}