using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderBehaviour : MonoBehaviour, IOnCursorPositionChanged
{
    public static bool _DEBUG = false;

    [SerializeField]
    public bool DEBUG = false;
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
    private ObjectHolder objectHolder;
    private bool buildingStructure = false;
    private Structure structure;

    void Start()
    {
        this.gridManager = FindObjectOfType<GridManager>();
        this.buildingStatus = FindObjectOfType<BuildingStatusBehaviour>();
        cursor = FindObjectsOfType<CursorBehaviour>()[0];
        cursor.addOnPositionChangedListener(this);
        mode = Mode.NONE;
        this.buildingReqSprite = gameObject.GetComponent<SpriteRenderer>();
        this.objectHolder = GameObject.Find("SaveController").GetComponent<ObjectHolder>();
    }

    void Update()
    {
        if (this.buildingInitialized > 0)
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
        BuildingStatusBehaviour.Status status;
        if(this.mode != Mode.NONE)
        {
            status = this.structure.canBuild();
            if (this.mode == Mode.BUILDING)
            {
                this.buildingPreview.transform.position = new Vector3(cursor.transform.position.x, cursor.transform.position.y, this.defaultZPreview);
                this.buildingReqSprite.transform.position = this.buildingPreview.transform.position;

                if (status == BuildingStatusBehaviour.Status.ALLOW_BUILDING)
                {
                    this.buildingReqSprite.color = new Color(0, 255, 0, 0.25f);
                    this.cursor.setColor(Color.green);
                }
                else
                {
                    this.buildingReqSprite.color = new Color(255, 0, 0, 0.25f);
                    this.cursor.setColor(Color.red);
                }
                this.buildingStatus.setStatus(status);
            }
            if (this.cursor.GetMouseButtonDown(0))
            {
                Position position = cursor.getPosition();
                switch (this.mode)
                {
                    case Mode.BUILDING:
                        if (status == BuildingStatusBehaviour.Status.ALLOW_BUILDING)
                        {
                            if (this.buildingStructure)
                            {
                                GameObject buildingObject = Instantiate(buildingPreview);
                                Structure structureTemp = buildingObject.GetComponent<Structure>();
                                structureTemp.setPosition(position);
                                structureTemp.name = structureTemp.getName();
                                structureTemp.transform.position = new Vector3(cursor.getPosition().x, cursor.getPosition().y, this.defaultZBuilding);
                                gridManager.addStructure(structureTemp, position.getX(), position.getY());
                            }
                            else
                            {
                                if (this.buildingInitialized != 0)
                                    break;
                                GameObject buildingObject = Instantiate(buildingPreview);
                                Building buildingTemp = buildingObject.GetComponent<Building>();
                                buildingTemp.setPosition(position);
                                if (this.DEBUG) Debug.Log("Test: " + buildingTemp.getBuildingRequirements().positionsToCheck.Count);
                                buildingObject.name = buildingTemp.getName();
                                buildingObject.transform.position = new Vector3(cursor.getPosition().x, cursor.getPosition().y, this.defaultZBuilding);
                                gridManager.addStructure((Structure)buildingTemp, position.getX(), position.getY());
                                buildingTemp.setEnabled(true);
                                building.subtractRequirements();
                            }
                        }
                        break;
                    case Mode.DESTRUCTION:
                        structure = this.gridManager.getStructure(position.x, position.y);
                        if (structure != null)
                        {
                            structure.destroy();
                        }
                        break;
                }
            }
        }
    }

    public void onPositionChanged(Position oldPosition, Position newPosition)
    {
        if (this.mode == Mode.BUILDING)
        {
            this.structure.setPosition(new Position(newPosition));
        }
    }

    private void setBuildingPreviewPosition(Position pos)
    {
        this.buildingPreview.transform.position = pos.toVector3(this.defaultZPreview);
    }

    public Mode getBuildingMode()
    {
        return this.mode;
    }

    public void setBuildingMode(Mode newMode, GameObject building = null)
    {
        this.buildingStructure = false;
        this.buildingInitialized = 0;
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
                this.structure = this.buildingPreview.GetComponent<Structure>();
                if(structure == null)
                {
                    if (this.DEBUG) Debug.Log("BuilderBehaviour.setBuildingMode() - structure is null");
                    setBuildingMode(Mode.NONE);
                    break;
                }
                this.buildingPreview.name = structure.getName() + " - preview";

                this.structure.setPosition(cursor.getPosition());

                this.building = this.buildingPreview.GetComponent<Building>();
                this.buildingStatus.setStatus(BuildingStatusBehaviour.Status.NONE);
                setBuildingPreviewPosition(cursor.getPosition());
                if (this.building == null)
                {
                    this.buildingStructure = true;
                }else
                {
                    this.buildingInitialized = 1;
                }
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
    public void setBuildingModeId(Mode newMode, int buildingId = 0)
    {
        if (newMode != Mode.BUILDING)
        {
        }
        GameObject buildingObject = null;
        if(!this.objectHolder.Buildings.TryGetValue(buildingId, out buildingObject))
        {
            if (DEBUG)
                Debug.Log("BuilderBehaviour.setBuildingMode(" + newMode.ToString() + ", " + buildingId + ") - buildingObject is null");
            setBuildingMode(Mode.NONE, null);
            return;
        }
        Building building = null;
        setBuildingMode(newMode, building.gameObject);
    }

    public enum Mode
    {
        NONE, BUILDING, DESTRUCTION
    }
    //Save

    public void LoadBuilding(int x, int y, GameObject building)
    {
        GameObject buildingObject = Instantiate(building);
        Structure structureTemp = buildingObject.GetComponent<Structure>();
        structureTemp.setPosition(new Position(x, y));
        structureTemp.name = structureTemp.getName();
        structureTemp.transform.position = new Vector3(x, y, this.defaultZBuilding);

        Building buildingTemp = buildingObject.GetComponent<Building>();
        if(buildingTemp != null)
        {
            buildingTemp.setEnabled(true);
        }
        gridManager.addStructure(structureTemp, x, y);
    }
}