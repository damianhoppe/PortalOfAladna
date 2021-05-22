using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMine : DefaultBuilding
{
    public MiningController MC { get; protected set; }

    protected override void Start()
    {
        base.Start();

        this.MC = GameObject.Find("MiningController").GetComponent<MiningController>();

        this.ObjectName = "Default Mine";
        this.ObjectDescription = "This is a Default Mine.";
        this.ObjectType = "Mine";
        this.ObjectTypeID = -1;
        this.ObjectSubtype = "Default Mine";
        this.ObjectSubtypeID = -1;

        this.MaxHitpoints = 100.0f;
        this.ActiveAtNight = true;
        this.Armor = 1.0f;
        this.Protection = 0.0f;

        this.PositionValue = 1.0f;
        this.PositionObstacle = 1.0f;

        this.BaseCost = new DataStructures.Cost(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 0.0f;

        this.CurrentHitpoints = this.MaxHitpoints;

        this.PlayerObjectID = -1;
    }
    
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    DefaultMine()
    {
        this.ObjectName = "Default Mine";
        this.ObjectDescription = "This is a Default Mine.";
        this.ObjectType = "Mine";
        this.ObjectTypeID = -1;
        this.ObjectSubtype = "Default Mine";
        this.ObjectSubtypeID = -1;

        this.MaxHitpoints = 100.0f;
        this.ActiveAtNight = true;
        this.Armor = 1.0f;
        this.Protection = 0.0f;

        this.PositionValue = 1.0f;
        this.PositionObstacle = 1.0f;

        this.BaseCost = new DataStructures.Cost(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 0.0f;

        this.PlayerObjectID = -1;

    }
    
    public virtual DataStructures.Cost DailyProduction { get; protected set; } = new DataStructures.Cost(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
    public virtual DataStructures.Cost NightProduction { get; protected set; } = new DataStructures.Cost(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
    public virtual DataStructures.Cost AccumulatedResources { get; protected set; } = new DataStructures.Cost(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
    public virtual DataStructures.Cost DeliverySize { get; protected set; } = new DataStructures.Cost(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
    public virtual float PortalDistance { get; protected set; } = 0.0f;


    public virtual float ExtractionPerCycle { get; protected set; } = 0.0f; //do podglądu produkcji dziennej?

    public virtual float MiningPower { get; protected set; } = 1.0f; // ile surowcow na cykl
    public virtual float MiningSpeed { get; protected set; } = 1.0f; // ile trwa cykl (mniejsze==szybciej)
    public virtual float MiningDelay { get; protected set; } // ile do nast. dostawy
    public virtual int MinedResource { get; protected set; } = 0; //PlayerObjectID dla rodzaju zloza

    public List<DefaultResource> SurroundingOres = new List<DefaultResource>();

    public virtual void CheckSurroundings()
    {

        this.ExtractionPerCycle = 0.0f;

        SurroundingOres = new List<DefaultResource>();

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                Position tmpPosition = new Position(Mathf.RoundToInt(this.transform.position.x) + i, Mathf.RoundToInt(this.transform.position.y) + j);
                Structure tmpStructure = GM.getStructure(tmpPosition);
                if (tmpStructure == null) continue;
                else if (tmpStructure.getType() == EStructureType.Ore)
                {
                    if (tmpStructure.PlayerObjectID == this.MinedResource)
                    {
                        DefaultResource tmpResource = (DefaultResource)tmpStructure;
                        if (tmpResource.RemainingOre > 0 && tmpResource.Depleted == false)
                        {
                            SurroundingOres.Add(tmpResource);
                        }
                    }
                }
            }
        }
        
        ExtractionPerCycle = 0.0f;

        foreach (DefaultResource Resource in SurroundingOres)
        {
            ExtractionPerCycle += Resource.OreRichness*this.MiningPower;
        }

    }
    public virtual void MineResources()
    {
        DataStructures.Cost yield = new DataStructures.Cost();

        foreach(DefaultResource Resource in SurroundingOres)
        {
           yield+=Resource.Mine(this.MiningPower);
        }

        if (DNC.IsDay()) this.DailyProduction = yield;
        else this.NightProduction = yield;
        
        this.AccumulatedResources += yield;

        //DeliverResources();
    }
    public virtual void ChangeActivity()
    {
        if (this.ActiveAtNight) this.ActiveAtNight = false;
        else this.ActiveAtNight = true;
    }
    public virtual void DeliverResources()
    {
        /*
        if (DataStructures.Cost.IsGreater(this.AccumulatedResources, this.DeliverySize))
        {
            EC.ResourcesGained(this.DeliverySize);
            this.AccumulatedResources -= this.DeliverySize;
        }
        */
    }
    public override void onCreate()
    {
        base.onCreate();
        MC.RegisterMine(this);
    }
    public override void onSell()
    {
        MC.UnregisterMine(this);
        base.onSell();
    }
    public override void onDestroy()
    {
        MC.UnregisterMine(this);
        base.onDestroy();
    }
}
