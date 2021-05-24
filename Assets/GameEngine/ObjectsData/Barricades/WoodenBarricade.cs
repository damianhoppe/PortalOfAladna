using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBarricade : DefaultBuilding
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.ObjectName = "Wooden Barricade";
        this.ObjectDescription = "This is a wooden barricade, can be built and sold at night.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Wooden Barricade";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 100.0f;
        this.Armor = 1.0f;
        this.Protection = 5.0f;

        this.PositionValue = -2.0f;
        this.PositionObstacle = 1.0f;
        this.PositionDanger = -2.0f;

        this.RepairRate = 1.0f;
        this.RefundRate = 1.0f;

        this.BaseCost = new DataStructures.Cost(25.0f, 25.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 5.0f;
        this.RequiredHumans = 0;
        this.PlayerObjectID = 99;

        this.RequiresAccess = false;
        this.BlocksPlayerUnits = false;
        this.CanBuildAtNight = true;

        this.IsMilitary = true;
        this.IsCivilian = false;
        this.CurrentHitpoints = this.MaxHitpoints;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public WoodenBarricade()
    {
        this.ObjectName = "Wooden Barricade";
        this.ObjectDescription = "This is a wooden barricade, can be built and sold at night.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Wooden Barricade";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 100.0f;
        this.Armor = 1.0f;
        this.Protection = 5.0f;

        this.PositionValue = -2.0f;
        this.PositionObstacle = 1.0f;
        this.PositionDanger = -2.0f;

        this.RepairRate = 1.0f;
        this.RefundRate = 1.0f;

        this.BaseCost = new DataStructures.Cost(25.0f, 25.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 5.0f;
        this.RequiredHumans = 0;
        this.PlayerObjectID = 99;

        this.RequiresAccess = false;
        this.BlocksPlayerUnits = false;
        this.CanBuildAtNight = true;
}
    public override void onSell()
    {
        this.RefundRate = this.CurrentHitpoints / this.MaxHitpoints;
        base.onSell();
    }
    public override bool OnHit(float Damage)
    {
        bool tmp = base.OnHit(Damage);
        this.RefundRate = this.CurrentHitpoints / this.MaxHitpoints;
        return tmp;
    }
}
