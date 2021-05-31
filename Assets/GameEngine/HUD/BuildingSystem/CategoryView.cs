using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CategoryView : MonoBehaviour
{
    private const string prefabPath = "HUD/CategoryView";
    public static CategoryView create(GameObject parent, EStructureCategory category, BuildingHUDBehaviour buildingHUDBehaviour)
    {
        Object obj = Utils.loadPrefabFromFile(prefabPath);
        GameObject gameObj = (GameObject)GameObject.Instantiate(obj, parent.transform);
        CategoryView view = gameObj.GetComponent<CategoryView>();
        view.category = category;
        view.buildingHUDBehaviour = buildingHUDBehaviour;
        return view;
    }

    private EStructureCategory category;
    private BuildingHUDBehaviour buildingHUDBehaviour;

    private TextMeshProUGUI labelView;

    void Awake()
    {
        this.labelView = this.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start()
    {
        updateContent();
    }

    public void updateContent()
    {
        this.labelView.text = category.ToString();
    }

    public void onClick()
    {
        buildingHUDBehaviour.showCategory(category);
    }
}
