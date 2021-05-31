using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingListView : MonoBehaviour
{
    private const string prefabPath = "HUD/List/BuildingListView";
    public static BuildingListView create(GameObject parent, string title, BuilderBehaviour buildingSystem)
    {
        Object obj = Utils.loadPrefabFromFile(prefabPath);
        GameObject gameObj = (GameObject)GameObject.Instantiate(obj, parent.transform);
        BuildingListView view = gameObj.GetComponent<BuildingListView>();
        view.Start();
        view.title = title;
        view.buildingSystem = buildingSystem;
        return view;
    }

    public string title;
    public BuilderBehaviour buildingSystem;
    private List<BuildingView> views;
    private GameObject content;
    private RectTransform scrollbarTransform;
    private GameObject hud;
    private GameObject scrollbar;

    public BuildingListView()
    {
        this.views = new List<BuildingView>();
    }

    public void Start()
    {
        this.content = Find(this.transform, "BuildingListView");
        if (this.content == null && BuilderBehaviour._DEBUG)
            Debug.Log("BuildingListView.Start() - content is null");
        this.hud = GameObject.Find("HUD");
        this.scrollbar = Utils.getChildGameObject(this.transform, "Scroll View");
        scrollbarTransform = scrollbar.GetComponent<RectTransform>();
        calculateWidth();
    }

    public void addBuilding(GameObject buildingObject, int buildingId)
    {
        BuildingView view = BuildingView.create(this.content, buildingObject, buildingId, this.buildingSystem);
    }

    private GameObject Find(Transform parent, string name)
    {
        GameObject v = null;
        foreach (Transform child in parent)
        {
            if (child.name == name)
            {
                return child.gameObject;
            }
            v = Find(child, name);
            if (v != null)
                return v;
        }
        return v;
    }

    public void calculateWidth()
    {
        RectTransform hudTransform = hud.GetComponent<RectTransform>();
        scrollbarTransform.sizeDelta = new Vector2(hudTransform.sizeDelta.x, scrollbarTransform.sizeDelta.y);
    }
}
