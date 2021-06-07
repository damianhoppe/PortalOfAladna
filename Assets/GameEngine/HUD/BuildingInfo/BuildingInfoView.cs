using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingInfoView : MonoBehaviour
{
    private Text txName;
    private Text txDescription;
    private GameObject statsContainer;
    private Button bDestroy;
    private CanvasGroupManager canvasGroupManager;
    private GameObject buttons;

    private CursorBehaviour cursorBehaviour;

    private bool visible = false;
    private bool timerStarted = false;
    private float timer;

    private DefaultBuilding building;

    void Awake()
    {
        this.txName = Utils.getChildGameObject(this.gameObject.transform, "Name").GetComponentInChildren<Text>();
        this.txDescription = Utils.getChildGameObject(this.gameObject.transform, "Description").GetComponentInChildren<Text>();
        this.statsContainer = Utils.getChildGameObject(this.gameObject.transform, "Stats");
        this.bDestroy = Utils.getChildGameObject(this.gameObject.transform, "ButtonDestroy").GetComponent<Button>();
        this.buttons = Utils.getChildGameObject(this.gameObject.transform, "Buttons");
        this.canvasGroupManager = this.GetComponent<CanvasGroupManager>();

        this.cursorBehaviour = GameObject.Find("Cursor").GetComponent<CursorBehaviour>();
        this.visible = false;
        this.canvasGroupManager.setCanvasGroup(this.GetComponent<CanvasGroup>());
        this.hide();
    }

    void Update()
    {
        if (visible)
        {
            Debug.Log((!this.cursorBehaviour.IsPointerOverUIElement() && Input.GetMouseButton(0)) || Input.GetKeyDown(KeyCode.Escape));
            if ((!this.cursorBehaviour.IsPointerOverUIElement() && Input.GetMouseButton(0)) || Input.GetKeyDown(KeyCode.Escape))
            {
                hide();
            }
        }
        if(this.timerStarted)
        {
            if (timer > 0)
            {
                this.timer -= Time.deltaTime;
            }else
            {
                this.timerStarted = false;
                this.visible = true;
                this.canvasGroupManager.show();
            }
        }
    }

    public void loadBuilding(DefaultBuilding building)
    {
        this.building = building;
        this.txName.text = this.building.getName();
        if (this.building.ObjectDescription == null)
        {
            this.txDescription.text = "";
        }else
        {
            this.txDescription.text = this.building.ObjectDescription;
        }
        this.buttons.SetActive(building.CanSell);
    }

    public void show()
    {
        this.timerStarted = true;
        this.timer = 0.2f;
        this.canvasGroupManager.show();
    }

    public void hide()
    {
        this.timerStarted = false;
        this.visible = false;
        this.canvasGroupManager.hide();
    }

    public void onClickDestroyButton()
    {
        if (this.building == null)
            return;
        this.building.destroy();
        hide();
    }
}
