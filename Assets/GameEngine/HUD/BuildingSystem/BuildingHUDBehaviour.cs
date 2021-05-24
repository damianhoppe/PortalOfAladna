using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingHUDBehaviour : MonoBehaviour
{
    private ObjectHolder objectHolder;
    private BuilderBehaviour buildingSystem;
    private Dictionary<string, BuildingListView> categories;
    private Scrollbar srollBar;
    private int screenWidth;

    public BuildingHUDBehaviour()
    {
        this.categories = new Dictionary<string, BuildingListView>();
    }

    void Awake()
    {
        this.screenWidth = Screen.width;
    }

    void Start()
    {
        this.objectHolder = GameObject.Find("SaveController").GetComponent<ObjectHolder>();
        this.buildingSystem = GameObject.Find("BuildingSystem").GetComponent<BuilderBehaviour>();
        Dictionary<int, GameObject> buildings = this.objectHolder.Buildings;

        ////TYMCZASOWO TYLKO JEDNA KATEOGIRA - WSZYSTKIE BUDYNKI
        BuildingListView main = addCategory("");
        foreach(KeyValuePair<int, GameObject> pair in buildings)
        {
            main.addBuilding(pair.Value, pair.Key);
        }
    }

    void Update()
    {
        if(this.screenWidth != Screen.width)
        {
            this.screenWidth = Screen.width;
            foreach (KeyValuePair<string, BuildingListView> pair in categories)
            {
                pair.Value.calculateWidth();
            }
        }
    }

    private BuildingListView addCategory(string name)
    {
        BuildingListView newList = BuildingListView.create(this.gameObject, name, this.buildingSystem);
        this.categories.Add(name, newList);
        return newList;
    }
}
