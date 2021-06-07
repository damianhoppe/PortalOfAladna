using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Structure, IBuilding
{
    [SerializeField]
    bool builded = false;
    [SerializeField]
    List<Structure> nearbyStructuresRequired;
    [SerializeField]
    public int requiredMinimalDistance;
    [SerializeField]
    int buildSpeed;
    [SerializeField]
    int maxLvl;

    protected int lvl;
    bool updateEnabled = false;
    bool initialized = false;
    float upgradePercentage;

    public int Danger; //test
    int numberOfEmployees;
    int maxNumberOfEmployees;
    float currentPerformance;

    protected Status status;
    BuildingRequirements buildingRequirements;
    BuildingStatusBehaviour buildingStatus;
    protected HPBar hpBar;

    public Building() : base(EStructureType.Building)
    {
        this.lvl = 0;
        this.status = Status.IS_BEING_BUILT;
        this.buildingRequirements = new BuildingRequirements(this);
        setPosition(new Position(10000,10000));
    }
    protected override void Awake()
    {
        base.Awake();
        if (BuilderBehaviour._DEBUG) Debug.Log("Awake: " + toString());
        buildingRequirements.initDictionary(nearbyStructuresRequired, requiredMinimalDistance);
    }

    protected override void Start()
    {
        base.Start();
        if (this.builded)
        {
            this.upgradePercentage = 100;
            this.updateEnabled = true;
        }
        if(BuilderBehaviour._DEBUG) Debug.Log("Start: " + toString() + " : " + requiredMinimalDistance + " / " + nearbyStructuresRequired.Count + " / " + this.updateEnabled);
        if (this.updateEnabled)
        {
            onCreate();
        }
    }

    protected override void Update()
    {
        if (this.updateEnabled)
        {
            this.update();
        }
    }

    protected virtual void update()
    {
        if (this.hpBar == null)
            this.destroy(true);
        this.currentPerformance = 1;
        if (this.status == Status.IS_BEING_BUILT)
        {
            Color color = this.spriteRenderer.color;
            this.upgradePercentage += this.currentPerformance * buildSpeed * Time.deltaTime;
            color.a = this.upgradePercentage / 200 + 0.5f;
            this.spriteRenderer.color = color;
            this.hpBar.setHealthPercentage(this.upgradePercentage);
            if (this.upgradePercentage >= 100)
            {
                this.hpBar.setHealthPercentage(100);
                this.upgradePercentage = 0;
                this.lvl++;
                this.onUpgrade();
                this.status = Status.WORKS;
            }
        }
    }

    public override BuildingStatusBehaviour.Status canBuild()
    {
        BuildingStatusBehaviour.Status baseStatus = base.canBuild();
        if (baseStatus != BuildingStatusBehaviour.Status.ALLOW_BUILDING)
            return baseStatus;
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
        if (BuilderBehaviour._DEBUG) Debug.Log("onCreate: " + toString());
        this.hpBar = HPBar.create(this.gameObject);
        if (!this.builded)
        {
            this.hpBar.setFillColor(Color.white);
            this.upgradePercentage = 0;
            this.hpBar.setHealth(0);
        }
        Structure structure = this.buildingRequirements.findNearestStructure(this.gridManager);
        if (BuilderBehaviour._DEBUG)
        {
            if (structure != null)
                Debug.Log("Nearest structure: " + structure.gameObject.name);
            else
                Debug.Log("Nearest structure: null");
        }
    }

    public virtual void onUpgrade()
    {
        switch(this.lvl)
        {
            case 1:
                this.hpBar.setTargetFillColor(Color.red);
                this.hpBar.hideWithDelay(1);
                break;
            case 2:
                break;
        }
    }

    public override void onClick()
    {
        if (BuilderBehaviour._DEBUG) Debug.Log("S: " + this.status.ToString() + " - " + (int)this.upgradePercentage + "%" + ", LVL:" + this.lvl + ", PERF: " + this.currentPerformance + ", NOE: " + this.numberOfEmployees + "/:" + this.maxNumberOfEmployees);
    }

    public enum Status
    {
        IS_BEING_BUILT, WORKS
    }

    public virtual void setEnabled(bool enabled)
    {
        if (BuilderBehaviour._DEBUG) Debug.Log("setEnabled(" + enabled + "): " + toString());
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

    public virtual void subtractRequirements() { }

    protected virtual bool isInDistance(Position position, int distance)
    {
        int xDiff = Mathf.Abs(position.x - getPosition().x);
        int yDiff = Mathf.Abs(position.y - getPosition().y);
        if (xDiff <= distance && yDiff <= distance)
            return true;
        return false;
    }
    protected virtual bool isAroundInDistance(Position position, int distance)
    {
        int xDiff = Mathf.Abs(position.x - getPosition().x);
        int yDiff = Mathf.Abs(position.y - getPosition().y);
        if (xDiff == 0 && yDiff == 0)
            return false;
        if (xDiff <= distance && yDiff <= distance)
            return true;
        return false;
    }
}
