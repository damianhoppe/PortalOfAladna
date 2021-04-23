using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Structure, IBuilding
{
    [SerializeField]
    List<Structure> nearbyStructuresRequired;
    [SerializeField]
    public int requiredMinimalDistance;
    [SerializeField]
    int buildSpeed;
    [SerializeField]
    int maxLvl;

    protected int lvl;
    bool updateEnabled;
    bool initialized = false;
    float upgradePercentage;

    public int Danger; //test
    int numberOfEmployees;
    int maxNumberOfEmployees;
    float currentPerformance;

    protected Status status;
    BuildingRequirements buildingRequirements;
    BuildingStatusBehaviour buildingStatus;
    GridManager gridManager;
    protected HPBar hpBar;

    public Building() : base(EStructureType.Building)
    {
        this.lvl = 0;
        this.status = Status.IS_BEING_BUILT;
        this.buildingRequirements = new BuildingRequirements(this);
    }

    protected override void Start()
    {
        base.Start();
        this.gridManager = FindObjectOfType<GridManager>();
        Debug.Log("Start: " + requiredMinimalDistance + " / " + nearbyStructuresRequired.Count);
        buildingRequirements.initDictionary(nearbyStructuresRequired, requiredMinimalDistance);
        initialized = true;
        if (this.updateEnabled)
            onCreate();
    }

    protected override void Update()
    {
        if(this.initialized)
        {
            if (this.updateEnabled)
            {
                this.update();
            }
        }
    }

    protected virtual void update()
    {
        this.currentPerformance = 1;
        if (this.status == Status.IS_BEING_BUILT)
        {
            Color color = this.spriteRenderer.color;
            this.upgradePercentage += this.currentPerformance * buildSpeed * Time.deltaTime;
            color.a = this.upgradePercentage / 200 + 0.5f;
            this.spriteRenderer.color = color;
            this.hpBar.setHealth(this.upgradePercentage);
            if (this.upgradePercentage >= 100)
            {
                this.hpBar.setHealth(100);
                this.upgradePercentage = 0;
                this.lvl++;
                this.onUpgrade();
                this.status = Status.WORKS;
            }
        }
    }

    public BuildingStatusBehaviour.Status canBuild()
    {
        if(gridManager == null)
            this.gridManager = FindObjectOfType<GridManager>();
        Debug.Log(getPosition().toString());
        if(!gridManager.isInGrid(getPosition()) || !gridManager.isEmpty(getPosition()))
        {
            return BuildingStatusBehaviour.Status.INCORRECT_PLACE;
        }
        if(!this.buildingRequirements.areMet(this.gridManager))
        {
            return BuildingStatusBehaviour.Status.LACK_OF_REQUIRED_BUILDING;
        }
        return BuildingStatusBehaviour.Status.ALLOW_BUILDING;
    }

    public virtual BuildingRequirements getBuildingRequirements()
    {
        return this.buildingRequirements;
    }

    public void getCosts()
    {
        switch(this.lvl + 1)
        {
            case 1:
                return;
            case 2:
                return;
        }
        return;
    }

    public virtual void onCreate()
    {
        this.hpBar = HPBar.create(this.gameObject);
        this.hpBar.hide();
        this.hpBar.setHealth(0);
        this.hpBar.setFillColor(Color.white);
        this.upgradePercentage = 0;
        Structure structure = this.buildingRequirements.findNearestStructure(this.gridManager);
        if(structure != null)
            Debug.Log("Nearest structure: " + structure.gameObject.name);
        else
            Debug.Log("Nearest structure: null");
    }

    public virtual void onUpgrade()
    {
        switch(this.lvl)
        {
            case 1:
                this.hpBar.setTargetFillColor(Color.red);
                break;
            case 2:
                break;
        }
    }

    public override void onClick()
    {
        Debug.Log("S: " + this.status.ToString() + " - " + (int)this.upgradePercentage + "%" + ", LVL:" + this.lvl + ", PERF: " + this.currentPerformance + ", NOE: " + this.numberOfEmployees + "/:" + this.maxNumberOfEmployees);
    }

    public enum Status
    {
        IS_BEING_BUILT, WORKS
    }

    public void setEnabled(bool enabled)
    {
        this.updateEnabled = enabled;
    }

    public override void onCursorOver()
    {
        if (this.hpBar != null)
            this.hpBar.show();
    }

    public override void onCursorLeft()
    {
        if (this.hpBar != null)
            this.hpBar.hideWithDelay(1);
    }

    public bool works()
    {
        return this.status == Status.WORKS;
    }
}
