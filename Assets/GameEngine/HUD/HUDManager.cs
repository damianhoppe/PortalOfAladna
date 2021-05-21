using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    bool hudVisibility = true;

    private CanvasGroupManager economyView;
    private CanvasGroupManager buildingSystemView;

    void Start()
    {
        this.economyView = loadCanvasGroupManager("EconomyHUD");
        this.buildingSystemView = loadCanvasGroupManager("BuildingSystemHUD");
        updateHUDVisibility(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            this.hudVisibility = !this.hudVisibility;
            updateHUDVisibility();
        }
    }

    private CanvasGroupManager loadCanvasGroupManager(string objectName)
    {
        GameObject gameObject = Utils.getChildGameObject(this.transform, objectName);
        if (gameObject != null)
            return gameObject.GetComponent<CanvasGroupManager>();
        return null;
    }

    public void updateHUDVisibility()
    {
        if (this.hudVisibility)
        {
            this.economyView.show();
            this.buildingSystemView.show();
        }
        else
        {
            this.economyView.hide();
            this.buildingSystemView.hide();
        }    
    }
}
