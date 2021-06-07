using System;
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
    public virtual GridManager GM { get; protected set; }

    private BuildingInfoView buildingInfoHUD;

    protected override void Awake()
    {
        UC = GameObject.Find("PlayerDataController").GetComponent<UpgradeController>();
        EC = GameObject.Find("PlayerDataController").GetComponent<EconomyController>();
        PC = GameObject.Find("PlayerDataController").GetComponent<PopulationController>();
        GM = GameObject.FindObjectOfType<GridManager>();
        DNC = GameObject.Find("PlayerDataController").GetComponent<DayNightController>();
        this.buildingInfoHUD = GameObject.Find("BuildingInfoHUD").GetComponent<BuildingInfoView>();
        base.Awake();
    }

    protected override void Start()
    {
        this.IsPlayerBuilding = true;
        //UC = GameObject.Find("UpgradeController").GetComponent<UpgradeController>();
        
        this.CurrentHitpoints = this.MaxHitpoints;

        //czy zmiana TotalCost zmieni BaseCost?
        this.TotalCost = this.BaseCost;
        this.UpgradeCost = this.TotalCost * UpgradeRate;
        //zapytanie do EconomyControllera "czy nas stac" aby utworzyc budynek
        //EC = GameObject.Find("EconomyController").GetComponent<EconomyController>();
        //this.OnBuild();
        base.Start();
        this.buildSpeed = 50;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }


    public override void onClick()
    {
        base.onClick();
        this.buildingInfoHUD.loadBuilding(this);
        this.buildingInfoHUD.show();
    }

    public virtual string ObjectDescription { get; protected set; } = "Default Building description";
    public virtual string ObjectType { get; protected set; } = "Building";
    
    public virtual int ObjectTypeID { get; protected set; } = 1;
    public virtual string ObjectSubtype { get; protected set; } = "Default";
    public virtual int ObjectSubtypeID { get; protected set; } = 0;
    //public virtual int PlayerObjectID { get; protected set; } = 0;

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

    public Dictionary<string,float> save()
    {
        Dictionary<string, float> save = new Dictionary<string, float>();

        save.Add("CurrentHitpoints", CurrentHitpoints);
        save.Add("MaxHitpoints", MaxHitpoints);
        return save;
    }
    public void load(Dictionary<string,float> save)
    {
        float data;
        save.TryGetValue("CurrentHitpoints",out data);
        CurrentHitpoints = data;
        save.TryGetValue("MaxHitpoints", out data);
        MaxHitpoints = data;
    }

    public virtual DataStructures.Cost UpgradeCost { get; protected set; }
    public virtual DataStructures.Cost RepairCost { get; protected set; }

    public virtual int RequiredHumans { get; protected set; } = 0;
    public virtual float EnergyToBuild { get; protected set; } = 0.0f;
    public virtual float EnergyToUpgrade { get; protected set; } = 0.0f;
    public virtual float EnergyToRepair { get; protected set; } = 0.0f;
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

    public virtual int LivingSpace { get; protected set; } = 0;
    public virtual float EnergyStorage { get; protected set; } = 0.0f;
    public virtual float EnergyUse { get; protected set; } = 0.0f;

    
    public virtual bool RequiresAccess { get; protected set; } = true;
    public virtual bool CanBuildAtNight { get; protected set; } = false;


    float t = 0;
    protected override void update()
    {
        base.update();
        /*if (this.works())
        {
            t += Time.deltaTime;
            if(t >= 2)
            {
                this.CurrentHitpoints -= 40;
                this.hpBar.setHealth(this.CurrentHitpoints);
                this.hpBar.showForSeconds(1f);
                if (this.CurrentHitpoints <= 0)
                {
                    this.destroy();
                }
                t -= 2;
            }
        }*/
    }

    public override void onCreate()
    {
        base.onCreate();
    }

    public override void subtractRequirements()
    {
        this.PC.IncreasePopulation(this.LivingSpace);
        this.EC.ResourcesSpent(this.UpgradeCost);
        this.EC.StorageIncrease(this.BuildingStorage);
        this.EC.DrainEnergy(this.EnergyToBuild);
        this.PC.EmployHumans(this.RequiredHumans);
        //Debug.Log("TEST");
    }

    
    public override BuildingStatusBehaviour.Status canBuild()
    {
        BuildingStatusBehaviour.Status baseStatus = base.canBuild();
        if (baseStatus != BuildingStatusBehaviour.Status.ALLOW_BUILDING)
            return baseStatus;
        if (!CreateAvailable())
            return BuildingStatusBehaviour.Status.LACK_OF_MATERIALS;
        return BuildingStatusBehaviour.Status.ALLOW_BUILDING;
    }

    public virtual bool CreateAvailable()
    {
        if (this.CanBuild)
        {
            if (EC.CanAfford(this.BaseCost,this.EnergyToBuild))
            {
                if (UC.CanBuild(this.RequiresInventor, this.RequiresResearcher, this.RequiresAcademy))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        else return false;
    }
    public override void onUpgrade()
    {
        base.onUpgrade();
        this.hpBar.setMaxHealth(this.MaxHitpoints);
        this.hpBar.setHealth(this.CurrentHitpoints);
        if (this.UpgradeAvailable())
        {
            EC.DrainEnergy(this.EnergyToUpgrade);
            EC.ResourcesSpent(this.UpgradeCost);
            this.TotalCost += this.UpgradeCost;
            this.UpgradeCost = TotalCost * 0.5f;
            this.BuildingLevel++;
        }
    }

    public virtual bool UpgradeAvailable()
    {
        if (this.CanUpgrade)
        {
            if (EC.CanAfford(this.UpgradeCost,this.EnergyToUpgrade))
            {
                if (UC.CanBuild(this.RequiresInventor, this.RequiresResearcher, this.RequiresAcademy))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        else return false;
    }
    public virtual void onRepair()
    {
        if (this.RepairAvailable())
        {
            EC.ResourcesSpent(this.RepairCost);
            EC.DrainEnergy(this.EnergyToRepair);
            this.RepairCost = this.TotalCost * 0.0f;
            this.CurrentHitpoints = this.MaxHitpoints;
        }
    }
    public virtual bool RepairAvailable()
    {
        if (this.CanRepair)
        {
            if (EC.CanAffordTEST(this.RepairCost,this.EnergyToRepair))
            {
                return true;
            }
            return false;
        }
        else return false;
    }
    public virtual void onSell()
    {
        if (this.SellAvailable())
        {
            EC.ResourcesGained(this.TotalCost * this.RefundRate);
            PC.FireHumans(this.RequiredHumans);
            this.EC.StorageDecrease(this.BuildingStorage);
            this.PC.DecreasePopulation(this.LivingSpace);
            this.DNC.tryMapRefresh();
        }
    }

    public virtual bool SellAvailable()
    {
        if (this.CanSell)
        {
            return true;
        }
        else return false;
    }
    public virtual void onSelect()
    {
        if (SelectAvailable())
        {
            //return base.OnSelect();
        }
    }
    public virtual bool SelectAvailable()
    {
        if (this.CanSelect) return true;
        else return false;
    }
    
    public virtual bool OnHit(float Damage)
    {
        //Debug.Log("Got attacked for " + Damage + " damage");
        if (this.IsCivilian)
        {
            float DMG = (Damage - this.Armor) * (1.0f - this.Protection / 100.0f);
            if (DMG <= 0.0f) DMG=0.0f;
            this.CurrentHitpoints -= DMG;
            this.hpBar.setHealth(this.CurrentHitpoints);
            this.hpBar.showForSeconds(0.5f);
            if (this.CurrentHitpoints <= 0.0f) destroy();
            else
            {
                this.RepairCost = this.TotalCost * (1.0f - (this.CurrentHitpoints / this.MaxHitpoints));
            }
            this.hpBar.setHealth(this.CurrentHitpoints);
            return true;
        }
        else if (this.IsMilitary)
        {
            float DMG = Damage * (1.0f - this.Protection / 100.0f) - this.Armor;
            if (DMG <= 0.0f) DMG = 0.0f;
            this.CurrentHitpoints -= DMG;
            this.hpBar.setHealth(this.CurrentHitpoints);
            this.hpBar.showForSeconds(0.5f);
            if (this.CurrentHitpoints <= 0.0f) destroy();
            else 
            { 
                this.RepairCost = this.TotalCost * (1.0f - (this.CurrentHitpoints / this.MaxHitpoints));
            }
            return true;
        }
        return false;
    }
    public override void destroy(bool forceDestruction = false)
    {
        if (this.DestroyAvailable())
        {
            base.destroy(forceDestruction);
        }
        

    }
    public override void onDestroy()
    {
        base.onDestroy();

        this.IsAlive = false;
        this.IsDead = true;
        if (this.ActiveAtNight)
        {
            PC.KillHumans(this.RequiredHumans);
        }
        this.EC.StorageDecrease(this.BuildingStorage);
        this.PC.DecreasePopulation(this.LivingSpace);
        this.DNC.tryMapRefresh();
        //destroy();
        //base.OnDeath();
    }
    public virtual bool DestroyAvailable()
    {
        if (this.CanDie)
        {
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
    public virtual float[] Modifiers()
    {
        float[] values = new float[]{ this.PositionObstacle, this.PositionValue, this.PositionDanger };
        return values;
    }
}
