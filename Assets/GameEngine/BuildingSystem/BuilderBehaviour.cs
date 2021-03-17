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
    private CursorBehaviour cursor;
    private Mode mode;
    private SpriteRenderer buildingReqSprite;

    void Start()
    {
        this.gridManager = FindObjectOfType<GridManager>();
        cursor = FindObjectsOfType<CursorBehaviour>()[0];
        cursor.addOnPositionChangedListener(this);
        mode = Mode.NONE;
        this.buildingReqSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(this.mode == Mode.BUILDING)
        {
            /*Vector3 target = new Vector3(cursor.transform.position.x, cursor.transform.position.y, this.defaultZPreview);
            this.buildingPreview.transform.position = Vector3.Lerp(this.buildingPreview.transform.position, target, Time.deltaTime * 50);*/
            this.buildingPreview.transform.position = new Vector3(cursor.transform.position.x, cursor.transform.position.y, this.defaultZPreview);
            this.buildingReqSprite.transform.position = this.buildingPreview.transform.position;
        }
        if (Input.GetMouseButtonDown(0) && this.mode != Mode.NONE)
        {
            Building building;
            Position position = cursor.getPosition();
            switch(this.mode)
            {
                case Mode.BUILDING:
                    if (gridManager.isInGrid(position.getX(), position.getY()) && gridManager.isEmpty(position.getX(), position.getY()))
                    {
                        Building buildingScript = this.buildingPreview.GetComponent<Building>();
                        if (buildingScript.getBuildingRequirements().areMet(this.gridManager))
                        {
                            GameObject buildingObject = Instantiate(buildingPreview);
                            building = buildingObject.GetComponent<Building>();
                            building.setPosition(cursor.getPosition());
                            buildingObject.name = building.getName();
                            buildingObject.transform.position = new Vector3(cursor.getPosition().x, cursor.getPosition().y, this.defaultZBuilding);
                            gridManager.addStructure((Structure)building, position.getX(), position.getY());
                            building.onCreate();
                        }
                    }
                    break;
                case Mode.DESTRUCTION:
                    building = (Building)this.gridManager.getStructure(position.x, position.y);
                    if (building != null)
                    {
                        building.onDestroy();
                        this.gridManager.destroyStructure(position.x, position.y);
                    }
                    break;
            }
        }
    }

    public void onPositionChanged(Position oldPosition, Position newPosition)
    {
        if (this.mode == Mode.BUILDING)
        {
            Building building = this.buildingPreview.GetComponent<Building>();
            building.setPosition(newPosition);
            if (gridManager.isInGrid(newPosition.getX(), newPosition.getY()) && gridManager.isEmpty(newPosition.getX(), newPosition.getY()) && building.getBuildingRequirements().areMet(this.gridManager))
            {
                this.buildingReqSprite.color = new Color(0,255,0,0.25f);
                this.cursor.setColor(Color.green);
            }
            else
            {
                this.buildingReqSprite.color = new Color(255, 0, 0, 0.25f);
                this.cursor.setColor(Color.red);
            }
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
                break;
        }
        switch (newMode)
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
                setBuildingPreviewPosition(cursor.getPosition());
                this.onPositionChanged(cursor.getPosition(), cursor.getPosition());

                Building b = this.buildingPreview.GetComponent<Building>();
                this.buildingReqSprite.size = new Vector2((float)b.requiredMinimalDistance * 2+1, (float)b.requiredMinimalDistance * 2+1);
                this.buildingReqSprite.enabled = true;
                break;
            case Mode.NONE:
                break;
            case Mode.DESTRUCTION:
                this.cursor.setColor(Color.red);
                break;
        }
        this.mode = newMode;
    }

    public enum Mode
    {
        NONE, BUILDING, DESTRUCTION
    }
}