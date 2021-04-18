using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBuilding : Building
{
    // Start is called before the first frame update

    public virtual UpgradeController UC { get; protected set; }
    public virtual EconomyController EC { get; protected set; }
    public virtual PopulationController PC { get; protected set; }
    public virtual DayNightController DNC { get; protected set; }

    protected override void Start()
    {
        base.Start();
        //UC = GameObject.Find("UpgradeController").GetComponent<UpgradeController>();

        UC = GameObject.Find("PlayerDataController").GetComponent<UpgradeController>();
        EC = GameObject.Find("PlayerDataController").GetComponent<EconomyController>();
        PC = GameObject.Find("PlayerDataController").GetComponent<PopulationController>();
        DNC = GameObject.Find("PlayerDataController").GetComponent<DayNightController>();

        this.CurrentHitpoints = this.MaxHitpoints;

        //czy zmiana TotalCost zmieni BaseCost?
        this.TotalCost = this.BaseCost;
        this.UpgradeCost = this.TotalCost * UpgradeRate;
        //zapytanie do EconomyControllera "czy nas stac" aby utworzyc budynek
        //EC = GameObject.Find("EconomyController").GetComponent<EconomyController>();
        //this.OnBuild();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public virtual string ObjectName { get; protected set; } = "Default Building";
    public virtual string ObjectDescription { get; protected set; } = "Default Building description";
    public virtual string ObjectType { get; protected set; } = "Building";
    public virtual int ObjectTypeID { get; protected set; } = 1;
    public virtual string ObjectSubtype { get; protected set; } = "Default";
    public virtual int ObjectSubtypeID { get; protected set; } = 0;
    public virtual int PlayerObjectID { get; protected set; } = 0;

    public virtual bool IsFriendly { get; protected set; } = true;
    public virtual bool IsHostile { get; protected set; } = false;
    public virtual bool CanSelect { get; protected set; } = true;
    public virtual bool IsAlive { get; protected set; } = true;
    public virtual bool IsDead { get; protected set; } = false;
    public virtual bool CanDie { get; protected set; } = true;

    public virtual bool CanBuild { get; protected set; } = true;
    public virtual bool CanUpgrade { get; protected set; } = true;
    public virtual bool CanRepair { get; protected set; } = true;
    public virtual bool CanSell { get; protected set; } = true;

    public virtual bool IsMilitary { get; protected set; } = false;
    public virtual bool IsCivilian { get; protected set; } = true;

    public virtual bool HasHealth { get; protected set; } = true;

    public virtual float MaxHitpoints { get; protected set; } = 100.0f;
    public virtual float CurrentHitpoints { get; protected set; }
    public virtual float Armor { get; protected set; } = 0.0f;
    public virtual float Protection { get; protected set; } = 0.0f;  //Wyrazone w %tach, 10.0f == 10%

    public virtual float SightRange { get; protected set; } = 2.0f;
    public virtual bool ActiveAtNight { get; protected set; } = false;
    
    public virtual DataStructures.Cost BaseCost { get; protected set; } = new DataStructures.Cost(100.0f, 10.0f, 5.0f, 0.0f, 0.0f, 5.0f);
    public virtual DataStructures.Cost TotalCost { get; protected set; }
    public virtual DataStructures.Cost UpgradeCost { get; protected set; }
    public virtual DataStructures.Cost RepairCost { get; protected set; }

    public virtual int RequiredHumans { get; protected set; } = 0;
    public virtual float EnergyToBuild { get; protected set; } = 0.0f;
    public virtual int BuildingLevel { get; protected set; } = 1;

    public virtual float UpgradeRate { get; protected set; } = 0.50f;
    public virtual float RepairRate { get; protected set; } = 0.50f;
    public virtual float RefundRate { get; protected set; } = 0.75f;

    public virtual float PositionDanger { get; protected set; } = 0.0f;
    public virtual float PositionValue { get; protected set; } = 0.0f;
    public virtual float PositionObstacle { get; protected set; } = 0.0f;

    public virtual DataStructures.Cost BuildingStorage { get; protected set; } = new DataStructures.Cost(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
    public virtual DataStructures.Cost ResourcesInside { get; protected set; } = new DataStructures.Cost(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);

    public virtual bool RequiresInventor { get; protected set; } = false;
    public virtual bool RequiresResearcher { get; protected set; } = false;
    public virtual bool RequiresAcademy { get; protected set; } = false;

    public virtual bool onCreate()
    {
        if (this.CanBuild)
        {
            if (EC.CanAffordTEST(this.BaseCost))
            {
                if (UC.CanBuild(this.RequiresInventor, this.RequiresResearcher, this.RequiresAcademy))
                {
                    base.onCreate();
                    //
                    return true;
                }
                else return false;
            }
            else return false;
        }
        else return false;
    }

    public virtual bool OnUpgrade()
    {
        if (this.CanUpgrade)
        {
            //base.OnUpgrade();
            //EconomyController EC =GameObject.Find("EconomyController").GetComponent<EconomyController>();
            if (EC.CanAffordTEST(this.UpgradeCost))
            {
                if (UC.CanBuild(this.RequiresInventor, this.RequiresResearcher, this.RequiresAcademy))
                {
                    EC.ResourcesSpent(this.UpgradeCost);
                    this.TotalCost += this.UpgradeCost;
                    this.UpgradeCost = TotalCost * 0.5f;
                    this.BuildingLevel++;
                    return true;
                }
                else return false;
            }
            else return false;
        }
        else return false;
    }
    public virtual bool OnRepair()
    {
        if (this.CanRepair)
        {
            //base.OnRepair();
            //EconomyController EC = GameObject.Find("EconomyController").GetComponent<EconomyController>();
            if (EC.CanAffordTEST(this.RepairCost))
            {
                EC.ResourcesSpent(this.RepairCost);
                this.RepairCost = this.TotalCost * 0.0f;
                this.CurrentHitpoints = this.MaxHitpoints;
                return true;
            }
            return false;
        }
        else return false;
    }
    public virtual bool OnSell()
    {
        if (this.CanSell)
        {
            //base.OnSell();
            //EconomyController EC = GameObject.Find("EconomyController").GetComponent<EconomyController>();
            EC.ResourcesGained(this.TotalCost * this.RefundRate);
            //PopulationController PC = GameObject.Find("PopulationController").GetComponent<PopulationController>();
            PC.FireHumans(this.RequiredHumans);
            return true;
        }
        else return false;
    }
    public virtual bool OnSelect()
    {
        //return base.OnSelect();
        if (this.CanSelect) return true;
        else return false;
    }
    
    public virtual bool OnHit(float Damage)
    {
        if (this.IsMilitary)
        {
            float DMG = (Damage - this.Armor) * (1.0f - this.Protection / 100.0f);
            if (DMG <= 0.0f) DMG=0.0f;
            this.CurrentHitpoints -= DMG;
            if (this.CurrentHitpoints <= 0.0f) onDestroy();
            else
            {
                this.RepairCost = this.TotalCost * (1.0f - (this.CurrentHitpoints / this.MaxHitpoints));
            }
            return true;
        }
        else if (this.IsMilitary)
        {
            float DMG = Damage * (1.0f - this.Protection / 100.0f) - this.Armor;
            if (DMG <= 0.0f) DMG = 0.0f;
            this.CurrentHitpoints -= DMG;
            if (this.CurrentHitpoints <= 0.0f) onDestroy();
            else 
            { 
                this.RepairCost = this.TotalCost * (1.0f - (this.CurrentHitpoints / this.MaxHitpoints)); 
            }
            return true;
        }
        return false;
    }
    public virtual bool onDestroy()
    {
        //return base.OnDeath();
        if (this.CanDie)
        {
            this.IsAlive = false;
            this.IsDead = true;
            if (this.ActiveAtNight)
            {
                //PopulationController PC= GameObject.Find("PopulationController").GetComponent<PopulationController>();
                PC.KillHumans(this.RequiredHumans);
            }
            //zabij budynek itp.

            return true;
        }
        else return false; 
    }
    public virtual bool StoreResources(DataStructures.Cost StoredResources)
    {
        if (DataStructures.Cost.IsLesser(StoredResources + this.ResourcesInside, this.BuildingStorage))
        {
            this.ResourcesInside += StoredResources;
            return true;
        }
        else return false;
    }
    public virtual bool TakeResources(DataStructures.Cost TakenResources)
    {
        if (DataStructures.Cost.IsLesser(TakenResources, this.ResourcesInside))
        {
            this.ResourcesInside -= TakenResources;
            return true;
        }
        else return false;
    }
}
