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

    public int Danger; //test
    bool updateEnabled;
    int numberOfEmployees;
    int maxNumberOfEmployees;
    int lvl;
    float currentPerformance;
    float upgradePercentage;

    Status status;
    BuildingRequirements buildingRequirements;

    public Building() : base(EStructureType.Building)
    {
        this.lvl = 0;
        this.maxNumberOfEmployees = 5;
        this.status = Status.IS_BEING_BUILT;
        this.buildingRequirements = new BuildingRequirements(this);
    }

    protected override void Start()
    {
        base.Start();
        buildingRequirements.initDictionary(nearbyStructuresRequired, requiredMinimalDistance);
    }

    protected override void Update()
    {
        if(this.updateEnabled)
        {
            this.currentPerformance = (float)this.numberOfEmployees / this.maxNumberOfEmployees;
            if (this.status == Status.IS_BEING_BUILT)
            {
                Color color = this.spriteRenderer.color;
                this.upgradePercentage += this.currentPerformance * buildSpeed * Time.deltaTime;
                color.a = this.upgradePercentage / 100;
                this.spriteRenderer.color = color;
                if (this.upgradePercentage >= 100)
                {
                    this.upgradePercentage = 0;
                    this.lvl++;
                    this.onUpgrade();
                    this.status = Status.WORKS;
                }
            }else
            {
            }
        }
    }

    public virtual BuildingRequirements getBuildingRequirements()
    {
        switch (this.lvl + 1)
        {
            case 1:
                return this.buildingRequirements;
        }
        return null;
    }

    public virtual void onCreate()
    {
        this.upgradePercentage = 0;
        this.updateEnabled = true;
        if (true)
        {
            this.numberOfEmployees = 2;
        }
    }

    public virtual void onDestroy()
    {
    }

    public virtual void onUpgrade()
    {
        switch(this.lvl)
        {
            case 1:
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
        WORKS, IS_BEING_BUILT
    }
}
