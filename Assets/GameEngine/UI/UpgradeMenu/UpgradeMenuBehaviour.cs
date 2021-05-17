using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuBehaviour : MonoBehaviour
{
    private UpgradeController upgradeController;
    private SaveController saveController;
    private GameObject contentObject;
    private Button backButton;
    private TextMeshProUGUI textPoints;

    private List<UpgradeView> views;

    void Start()
    {
        Debug.Log("load");
        this.upgradeController = GameObject.Find("PlayerDataController").GetComponent<UpgradeController>();
        this.saveController = GameObject.Find("PlayerDataController").GetComponent<SaveController>();
        this.saveController.load();
        this.contentObject = GameObject.Find("Content");
        this.views = new List<UpgradeView>();
        this.backButton = GetComponentInChildren<Button>();
        this.backButton.onClick.AddListener(onBackButtonClick);
        this.textPoints = GetComponentInChildren<TextMeshProUGUI>();
        IDictionary<int, Upgrade> upgrades = this.upgradeController.getUpgrades();
        foreach (KeyValuePair<int, Upgrade> pair in upgrades)
        {
            UpgradeView view = UpgradeView.create(this, pair.Key, pair.Value);
            this.views.Add(view);
        }
        updatePoints();
    }

    public bool addPoint(int upgradeId)
    {
        if (this.upgradeController.upgrade(upgradeId))
        {
            updatePoints();
            return true;
        }
        return false;
    }

    public GameObject getContent()
    {
        return this.contentObject;
    }

    public void updatePoints()
    {
        this.textPoints.text = this.upgradeController.getAvailablePoints().ToString();
    }

    public void onBackButtonClick()
    {
        this.saveController.Save();
    }
}
