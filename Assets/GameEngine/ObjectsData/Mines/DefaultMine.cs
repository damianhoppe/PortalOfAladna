using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMine : DefaultBuilding
{
    protected override void Start()
    {
        base.Start();
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
    public virtual float PortalDistance { get; protected set; } = 0.0f;
    public virtual DataStructures.Cost DailyProduction { get; protected set; } = new DataStructures.Cost(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
    public virtual DataStructures.Cost NightProduction { get; protected set; } = new DataStructures.Cost(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
    public virtual DataStructures.Cost AccumulatedResources { get; protected set; } = new DataStructures.Cost(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
    public virtual DataStructures.Cost DeliverySize { get; protected set; } = new DataStructures.Cost(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);

    public virtual float MinningPower { get; protected set; } = 1.0f; // ile surowcow na cykl
    public virtual float MinningSpeed { get; protected set; } = 1.0f; // ile trwa cykl (mniejsze==szybciej)
    public virtual float MinningDelay { get; protected set; } // ile do nast. dostawy
    public virtual int MinedResource { get; protected set; } = 0; //PlayerObjectID dla rodzaju zloza

    public List<DefaultResource> SurroundingOres = new List<DefaultResource>();

    public virtual void CheckSurroundings()
    {
        Position tmpPosition = new Position((int)this.transform.position.x+1, (int)this.transform.position.y);
        Structure tmpStructure = GM.getStructure(tmpPosition);
        if (tmpStructure.PlayerObjectID == this.MinedResource && tmpStructure.getType()==EStructureType.Ore)
        {
            SurroundingOres.Add((DefaultResource)tmpStructure);
        }
        //if tmpStructure to kopalnia X albo kopalnia Y
        //  dodaj do listy
    }
    public virtual void MineResources()
    {
        foreach(DefaultResource Resource in SurroundingOres)
        {
           this.AccumulatedResources+=Resource.Mine();
        }
        DeliverResources();
    }
    public virtual void ChangeActivity()
    {
        if (this.ActiveAtNight) this.ActiveAtNight = false;
        else this.ActiveAtNight = true;
    }
    public virtual void DeliverResources()
    {
        if (DataStructures.Cost.IsGreater(this.AccumulatedResources, this.DeliverySize))
        {
            EC.ResourcesGained(this.DeliverySize);
            this.AccumulatedResources -= this.DeliverySize;
        }
    }

}
