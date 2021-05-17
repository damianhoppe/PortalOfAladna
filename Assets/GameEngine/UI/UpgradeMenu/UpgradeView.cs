using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private const string prefabPath = "UI/UpgradeMenu/UpgradeView";
    public static UpgradeView create(UpgradeMenuBehaviour parent, int upgradeId, Upgrade upgrade)
    {
        Object obj = Utils.loadPrefabFromFile(prefabPath);
        GameObject gameObj = (GameObject)GameObject.Instantiate(obj, parent.getContent().transform);
        UpgradeView upgradeView = gameObj.GetComponent<UpgradeView>();
        upgradeView.upgrade = upgrade;
        upgradeView.upgradeId = upgradeId;
        upgradeView.upgradeBehaviour = parent;
        return upgradeView;
    }

    private Upgrade upgrade;
    private int upgradeId;
    private Text nameText;
    private Text valueText;
    private Button addButton;
    private Image addButtonImage;
    private bool started;
    private UpgradeMenuBehaviour upgradeBehaviour;

    void Start()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        this.nameText = texts[0];
        this.valueText = texts[1];
        this.addButton = GetComponentInChildren<Button>();
        this.addButton.onClick.AddListener(onAddButtonClick);
        this.addButtonImage = GetComponentInChildren<Image>();
        initViews();
    }

    public void initViews()
    {
        if (this.upgrade == null)
            return;
        this.nameText.text = this.upgrade.getName();
        this.loadValues();
    }

    public void loadValues()
    {
        this.valueText.text = this.upgrade.getValue().ToString();
    }

    public void onAddButtonClick()
    {
        if(this.upgradeBehaviour.addPoint(this.upgradeId))
            this.loadValues();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Color color = new Color(0.7f, 0.7f, 0.7f);
        this.nameText.color = color;
        this.valueText.color = color;
        this.addButtonImage.color = color;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Color color = Color.white;
        this.nameText.color = color;
        this.valueText.color = color;
        this.addButtonImage.color = color;
    }
}
