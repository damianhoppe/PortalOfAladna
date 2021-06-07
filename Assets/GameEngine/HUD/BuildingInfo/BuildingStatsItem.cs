using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingStatsItem : MonoBehaviour
{
    private const string prefabPath = "HUD/BuildingStatsItem";
    public static BuildingStatsItem create(GameObject parent)
    {
        Object obj = Utils.loadPrefabFromFile(prefabPath);
        GameObject gameObj = (GameObject)GameObject.Instantiate(obj, parent.transform);
        BuildingStatsItem view = gameObj.GetComponent<BuildingStatsItem>();
        return view;
    }

    private EconomyController economyController;
    private Text txName;
    private Text txValue;

    void Awake()
    {
        initViews();
    }

    private void initViews()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        this.txName = texts[0];
        this.txValue = texts[1];
    }

    public void setName(string name)
    {
        this.txName.text = name;
    }

    public void setValue(string value)
    {
        this.txValue.text = value;
    }
}
