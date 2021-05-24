using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingView : MonoBehaviour
{
    private const string prefabPath = "HUD/BuildingView";
    public static BuildingView create(GameObject parent, GameObject buildingObject, int buildingId, BuilderBehaviour buildingSystem)
    {
        Object obj = Utils.loadPrefabFromFile(prefabPath);
        GameObject gameObj = (GameObject)GameObject.Instantiate(obj, parent.transform);
        Structure structure = buildingObject.GetComponent<Structure>();
        if (structure == null)
        {
            if (BuilderBehaviour._DEBUG)
                Debug.Log("BuildingView.create(" + buildingId + ") - structure is null");
            return null;
        }
        BuildingView view = gameObj.GetComponent<BuildingView>();
        view.buildingId = buildingId;
        view.buildingObject = buildingObject;
        view.structure = structure;
        view.buildingSystem = buildingSystem;
        return view;
    }

    private int buildingId = -1;
    private GameObject buildingObject;
    private Structure structure;
    private BuilderBehaviour buildingSystem;

    private Text txName;
    private Image image;

    void Start()
    {
        initViews();
    }

    public void initViews()
    {
        this.txName = this.GetComponentInChildren<Text>();
        this.image = this.GetComponentInChildren<Image>();

        updateContent();
    }

    public void updateContent()
    {
        SpriteRenderer spriteRenderer;
        this.txName.text = structure.getName();
        spriteRenderer = this.buildingObject.GetComponent<SpriteRenderer>();
        if(spriteRenderer != null)
            this.image.sprite = spriteRenderer.sprite;
    }

    public void onClick()
    {
        this.buildingSystem.setBuildingMode(BuilderBehaviour.Mode.BUILDING, this.buildingObject);
    }
}