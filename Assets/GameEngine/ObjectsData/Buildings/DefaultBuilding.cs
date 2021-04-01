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
        this.BuildingCost = new DataStructures.Cost(100.0f,10.0f,5.0f,0.0f,0.0f,5.0f);
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
    public DataStructures.Cost BuildingCost;
    public virtual bool OnBuild()
    {
        if (this.CanBuild)
        {
            //base.OnBuild();
            return true;
        }
        else return false;
    }

    public virtual bool OnUpgrade()
    {
        if (this.CanUpgrade)
        {
            //base.OnUpgrade();
            return true;
        }
        else return false;
    }
    public virtual bool OnRepair()
    {
        if (this.CanRepair)
        {
            //base.OnRepair();
            return true;
        }
        else return false;
    }
    public virtual bool OnSell()
    {
        if (this.CanSell)
        {
            //base.OnSell();
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
            return true;
        }
        else if (this.IsMilitary)
        {
            float DMG = Damage * (1.0f - this.Protection / 100.0f) - this.Armor;
            if (DMG <= 0.0f) DMG = 0.0f;
            this.CurrentHitpoints -= DMG;
            if (this.CurrentHitpoints <= 0.0f) OnDeath();
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
            return true;
        }
        else return false; 
    }
}
