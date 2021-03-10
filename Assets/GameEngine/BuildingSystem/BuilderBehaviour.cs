using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderBehaviour : MonoBehaviour, IOnBuildingSelected, IOnCursorPositionChanged
{
    [SerializeField]
    private GridManager gridManager;
    [SerializeField]
    private List<Building> buildings;

    private GameObject buildingPreview;
    private CursorBehaviour cursor;

    void Start()
    {
        cursor = FindObjectsOfType<CursorBehaviour>()[0];
        cursor.registerOnBuildSelectedListener(this);
        cursor.addOnPositionChangedListener(this);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && buildingPreview != null)
        {
            Position position = cursor.getPosition();
            if (gridManager.isInGrid(position.getX(), position.getY()) && gridManager.isEmpty(position.getX(), position.getY()))
            {
                Building buildingScript = this.buildingPreview.GetComponent<Building>();
                buildingScript.setPosition(new Position(position));
                if (buildingScript.getBuildingRequirements().areMet(this.gridManager))
                {
                    GameObject buildingObject = Instantiate(buildingPreview);
                    Building building = buildingObject.GetComponent<Building>();
                    buildingObject.name = building.getName();
                    gridManager.addStructure((Structure)building, position.getX(), position.getY());
                    building.onCreate();
                }
            }
        }
        if(Input.GetMouseButtonDown(2))
        {
            Destroy(this.buildingPreview);
            buildingPreview = null;
        }
    }

    public void onBuildingSelected(GameObject building)
    {
        if (this.buildingPreview != null) Destroy(this.buildingPreview);
        this.buildingPreview = Instantiate(building);
        this.buildingPreview.name = this.buildingPreview.GetComponent<Structure>().getName() + " - preview";
        setBuildingPreviewPosition(cursor.getPosition());
    }

    public void onPositionChanged(Position oldPosition, Position newPosition)
    {
        if(this.buildingPreview != null)
        {
            this.setBuildingPreviewPosition(newPosition);
        }
    }

    private void setBuildingPreviewPosition(Position pos)
    {
        this.buildingPreview.transform.position = pos.toVector3(-0.5f);
    }

    public List<Building> getBuildings()
    {
        return this.buildings;
    }

    public bool allowsToClick()
    {
        return this.buildingPreview == null;
    }
}