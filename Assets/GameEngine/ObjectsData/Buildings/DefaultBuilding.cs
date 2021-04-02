using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBuilding : Building
{
    // Start is called before the first frame update


    void Start()
    {
        base.Start();
        //UC = GameObject.Find("UpgradeController").GetComponent<UpgradeController>();
        
        this.CurrentHitpoints = this.MaxHitpoints;
        //czy zmiana TotalCost zmieni BaseCost?
        this.TotalCost = this.BaseCost;
        this.UpgradeCost = this.TotalCost * UpgradeRate;
        //zapytanie do EconomyControllera "czy nas stac" aby utworzyc budynek
        //EC = GameObject.Find("EconomyController").GetComponent<EconomyController>();
        //this.OnBuild();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
    public string ObjectName { get; protected set; } = "Default Building";
    public string ObjectDescription { get; protected set; } = "Default Building description";
    public string ObjectType { get; protected set; } = "Building";
    public int ObjectTypeID { get; protected set; } = 1;
    public string ObjectSubtype { get; protected set; } = "Default";
    public int ObjectSubtypeID { get; protected set; } = 0;

    public bool IsFriendly { get; protected set; } = true;
    public bool IsHostile { get; protected set; } = false;
    public bool CanSelect { get; protected set; } = true;
    public bool IsAlive { get; protected set; } = true;
    public bool IsDead { get; protected set; } = false;
    public bool CanDie { get; protected set; } = true;

    public bool CanBuild { get; protected set; } = true;
    public bool CanUpgrade { get; protected set; } = true;
    public bool CanRepair { get; protected set; } = true;
    public bool CanSell { get; protected set; } = true;

    public bool IsMilitary { get; protected set; } = false;
    public bool IsCivilian { get; protected set; } = true;

    public bool HasHealth { get; protected set; } = true;

    public float MaxHitpoints { get; protected set; } = 100.0f;
    public float CurrentHitpoints { get; protected set; }
    public float Armor { get; protected set; } = 0.0f;
    public float Protection { get; protected set; } = 0.0f;  //Wyrazone w %tach, 10.0f == 10%

    public float SightRange { get; protected set; } = 2.0f;
    public bool ActiveAtNight { get; protected set; } = false;
    
    public DataStructures.Cost BaseCost { get; protected set; } = new DataStructures.Cost(100.0f, 10.0f, 5.0f, 0.0f, 0.0f, 5.0f);
    public DataStructures.Cost TotalCost { get; protected set; }
    public DataStructures.Cost UpgradeCost { get; protected set; }
    public DataStructures.Cost RepairCost { get; protected set; }

    public int RequiredHumans { get; protected set; } = 10;
    public float EnergyToBuild { get; protected set; } = 5.0f;
    public int BuildingLevel { get; protected set; } = 1;

    public float UpgradeRate { get; protected set; } = 0.50f;
    public float RepairRate { get; protected set; } = 0.50f;
    public float RefundRate { get; protected set; } = 0.75f;
    

    public virtual bool OnBuild()
    {
        if (this.CanBuild)
        {
            //base.OnBuild();
            //
            return true;
        }
        else return false;
    }

    public virtual bool OnUpgrade()
    {
        if (this.CanUpgrade)
        {
            //base.OnUpgrade();
            EconomyController EC =GameObject.Find("EconomyController").GetComponent<EconomyController>();
            if (EC.CanAffordTEST(this.UpgradeCost))
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
    public virtual bool OnRepair()
    {
        if (this.CanRepair)
        {
            //base.OnRepair();
            EconomyController EC = GameObject.Find("EconomyController").GetComponent<EconomyController>();
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
            EconomyController EC = GameObject.Find("EconomyController").GetComponent<EconomyController>();
            EC.ResourcesGained(this.TotalCost * this.RefundRate);
            PopulationController PC = GameObject.Find("PopulationController").GetComponent<PopulationController>();
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
            if (this.CurrentHitpoints <= 0.0f) OnDeath();
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
            if (this.CurrentHitpoints <= 0.0f) OnDeath();
            else 
            { 
                this.RepairCost = this.TotalCost * (1.0f - (this.CurrentHitpoints / this.MaxHitpoints)); 
            }
            return true;
        }
        return false;
    }
    public virtual bool OnDeath()
    {
        //return base.OnDeath();
        if (this.CanDie)
        {
            this.IsAlive = false;
            this.IsDead = true;
            if (this.ActiveAtNight)
            {
                PopulationController PC= GameObject.Find("PopulationController").GetComponent<PopulationController>();
                PC.KillHumans(this.RequiredHumans);
            }
            //zabij budynek itp.

            return true;
        }
        else return false; 
    }
}
