using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : DefaultBuilding
{
    
    protected override void Start()
    {
        base.Start();

        this.PlayerObjectID = 0;

        this.ObjectName = "Porta;";
        this.ObjectDescription = "This is a portal. Protect it at any cost.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Portal";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 1000.0f;
        this.Armor = 10.0f;
        this.Protection = 50.0f;

        this.PositionValue = 100.0f;
        this.PositionDanger = 100.0f;
        this.PositionObstacle = 100.0f;

        this.BaseCost = new DataStructures.Cost(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.RepairRate = 2.0f;
        this.CanRepair = true;

        this.BuildingStorage = new DataStructures.Cost(1000.0f, 400.0f, 400.0f, 400.0f, 400.0f, 0.0f);
        this.LivingSpace = 50;

        this.BlocksPlayerUnits = true;
        this.RequiresAccess = true;

        this.CanBuild = false;
        this.CanSell = false;
        this.IsMilitary = true;

        this.CurrentHitpoints = this.MaxHitpoints;
}
    public Portal()
    {
        this.PlayerObjectID = 0;

        this.ObjectName = "Porta;";
        this.ObjectDescription = "This is a portal. Protect it at any cost.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Portal";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 1000.0f;
        this.Armor = 10.0f;
        this.Protection = 50.0f;

        this.PositionValue = 100.0f;
        this.PositionDanger = 100.0f;
        this.PositionObstacle = 100.0f;

        this.BaseCost = new DataStructures.Cost(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.RepairRate = 2.0f;
        this.CanRepair = true;

        this.BuildingStorage = new DataStructures.Cost(1000.0f, 400.0f, 400.0f, 400.0f, 400.0f, 0.0f);
        this.LivingSpace = 50;

        this.BlocksPlayerUnits = true;
        this.RequiresAccess = true;

        this.CanBuild = false;
        this.CanSell = false;
        this.IsMilitary = true;

        this.CurrentHitpoints = this.MaxHitpoints;
    }
    protected override void Update()
    {
        base.Update();
    }
    public override void onCreate()
    {
        base.onCreate();

        this.BaseCost= new DataStructures.Cost(2500.0f, 1000.0f, 1000.0f, 500.0f, 500.0f, 0.0f);
        this.RepairRate = 2.0f;
    }
}
