using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceView : MonoBehaviour
{
    private const string prefabPath = "HUD/ResourceView";
    public static ResourceView create(GameObject parent, EconomyController economyController)
    {
        Object obj = Utils.loadPrefabFromFile(prefabPath);
        GameObject gameObj = (GameObject)GameObject.Instantiate(obj, parent.transform);
        ResourceView view = gameObj.GetComponent<ResourceView>();
        view.economyController = economyController;
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
