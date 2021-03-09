using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderBehaviour : MonoBehaviour, IOnBuildingSelected
{
    [SerializeField]
    private GameObject cursor;
    [SerializeField]
    private GridManager gridManager;

    private BuildingId buildingId;
    private GameObject buildingPreview;

    void Start()
    {
        CursorBehaviour cursorB = cursor.GetComponent<CursorBehaviour>();
        cursorB.registerOnBuildSelectedListener(this);
    }

    void Update()
    {
        if (buildingPreview != null)
        {
            Vector3 pos = Utils.copy(cursor.transform.position);
            pos.z = buildingPreview.transform.position.z;
            buildingPreview.transform.position = pos;
            if (Input.GetMouseButtonDown(1))
            {
                Vector3 buildingPos = new Vector3(cursor.transform.position.x, cursor.transform.position.y, -0.5f);
                if (gridManager.canBuild((int)buildingPos.x, (int)buildingPos.y))
                {
                    Destroy(buildingPreview);
                    buildingPreview = null;
                    gridManager.addBuilding(Builder.getBuilding(buildingId, Utils.copyZ(cursor.transform.position, -0.5f)), buildingPos.x, buildingPos.y);
                }
            }
        }
    }

    public void onBuildingSelected(BuildingId buildingId)
    {
        this.buildingId = buildingId;
        if (buildingPreview != null) Destroy(buildingPreview);
        buildingPreview = Builder.getBuildingPreview(buildingId, Utils.copyZ(cursor.transform.position, -0.5f));
    }
}
