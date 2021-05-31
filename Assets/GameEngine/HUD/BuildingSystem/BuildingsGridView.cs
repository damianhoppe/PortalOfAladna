using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsGridView : MonoBehaviour
{

    private const string prefabPath = "HUD/Grid/BuildingsGridView";
    public static BuildingsGridView create(GameObject parent, EStructureCategory category, BuilderBehaviour buildingSystem)
    {
        Object obj = Utils.loadPrefabFromFile(prefabPath);
        GameObject gameObj = (GameObject)GameObject.Instantiate(obj, parent.transform);
        BuildingsGridView view = gameObj.GetComponent<BuildingsGridView>();
        view.category = category;
        view.title = category.ToString();
        view.buildingSystem = buildingSystem;
        return view;
    }

    public EStructureCategory category;
    public string title;
    public BuilderBehaviour buildingSystem;
    private List<BuildingView> views;
    public CanvasGroupManager canvasGroupManager;
    private GameObject content;

    public BuildingsGridView()
    {
        this.views = new List<BuildingView>();
    }

    public void Awake()
    {
        this.canvasGroupManager = this.GetComponent<CanvasGroupManager>();
        this.content = Utils.getChildGameObject(this.transform, "BuildingsGridViewContent");
    }

    public void setHeight(float height)
    {
        RectTransform transform = this.gameObject.GetComponent<RectTransform>();
        transform.sizeDelta = new Vector2(transform.sizeDelta.x, height-30);
    }

    public void addBuilding(GameObject buildingObject, int buildingId)
    {
        BuildingView view = BuildingView.create(this.content, buildingObject, buildingId, this.buildingSystem);
    }
}
