using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BuildingHUDBehaviour : MonoBehaviour
{
    [SerializeField]
    private List<EStructureCategory> visibleCategories;
    [SerializeField]
    private bool DEBUG = false;
    private class Category
    {
        public BuildingsGridView buildingList;
        public CategoryView categoryView;

        public Category(BuildingsGridView buildingList, CategoryView categoryView)
        {
            this.buildingList = buildingList;
            this.categoryView = categoryView;
        }
    }

    private ObjectHolder objectHolder;
    private BuilderBehaviour buildingSystem;
    private GameObject categoriesContent;
    private GameObject buildingGridContent;
    private Dictionary<EStructureCategory, Category> categories;
    private Scrollbar srollBar;
    private int screenWidth;

    public BuildingHUDBehaviour()
    {
        this.categories = new Dictionary<EStructureCategory, Category>();
    }

    void Awake()
    {
        this.screenWidth = Screen.width;
    }

    void Start()
    {
        this.objectHolder = GameObject.Find("SaveController").GetComponent<ObjectHolder>();
        this.buildingSystem = GameObject.Find("BuildingSystem").GetComponent<BuilderBehaviour>();
        this.categoriesContent = Utils.getChildGameObject(this.transform, "Categories");
        this.buildingGridContent = Utils.getChildGameObject(this.transform, "Buildings");

        if(DEBUG)
        {
            EStructureCategory[] enumCategories = ((EStructureCategory[])Enum.GetValues(typeof(EStructureCategory)));
            foreach (EStructureCategory category in enumCategories)
            {
                addCategory(category);
            }
        }
        else
        {
            foreach (EStructureCategory category in this.visibleCategories)
            {
                addCategory(category);
            }
        }

        
        Dictionary<int, GameObject> buildings = this.objectHolder.Buildings;

        foreach (KeyValuePair<int, GameObject> pair in buildings)
        {
            Structure structure = pair.Value.GetComponent<Structure>();
            EStructureCategory structureCategory = structure.category;
            Category category = null;
            categories.TryGetValue(structureCategory, out category);
            if (category == null)
            {
                continue;
            }
            if(!DEBUG)
            {
                if(structure.PlayerBuildable)
                    category.buildingList.addBuilding(pair.Value, pair.Key);
            }else
            {
                if(structure.DebugBuildable)
                    category.buildingList.addBuilding(pair.Value, pair.Key);
            }
        }
        showCategory(visibleCategories[0]);
        updateHeight();
    }

    void Update()
    {
        /*if(this.screenWidth != Screen.width)
        {
            this.screenWidth = Screen.width;
            foreach (KeyValuePair<EStructureCategory, BuildingsGridView> pair in categories)
            {
                pair.Value.calculateWidth();
            }
        }*/
    }

    private BuildingsGridView addCategory(EStructureCategory category)
    {
        BuildingsGridView newList = BuildingsGridView.create(this.buildingGridContent, category, this.buildingSystem);
        CategoryView categoryView = CategoryView.create(this.categoriesContent, category, this);
        this.categories.Add(category, new Category(newList, categoryView));
        return newList;
    }

    public void showCategory(EStructureCategory category)
    {
        foreach (KeyValuePair<EStructureCategory, Category> pair in this.categories)
        {
            if(pair.Key == category)
            {
                pair.Value.buildingList.canvasGroupManager.show();
            }else
            {
                pair.Value.buildingList.canvasGroupManager.hide();
            }
        }
    }

    private void updateHeight()
    {
        RectTransform transform = Utils.getChildGameObject(this.transform, "Background").GetComponent<RectTransform>();
        float height = transform.sizeDelta.y;
        Debug.Log("0: " + height);
        RectTransform categoriesTransform = Utils.getChildGameObject(this.transform, "Categories").GetComponent<RectTransform>();
        height -= ((this.categories.Count * 30) + 80);
        foreach (KeyValuePair<EStructureCategory, Category> pair in this.categories)
        {
            pair.Value.buildingList.setHeight(height);
        }
    }
}
