using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBarricade : StoneBarricade
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.ObjectName = "Metal Barricade";
        this.ObjectDescription = "This is a metal barricade, can be built and sold at night.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Metal Barricade";
        this.ObjectSubtypeID = 2;

        this.MaxHitpoints = 350.0f;
        this.Armor = 5.0f;
        this.Protection = 10.0f;
        this.CurrentHitpoints = this.MaxHitpoints;
        this.PositionValue = 0.5f;
        this.PositionObstacle = 3.0f;
        this.PositionDanger = 0.5f;

        this.RepairRate = 1.0f;
        this.RefundRate = 1.0f;

        this.BaseCost = new DataStructures.Cost(75.0f, 0.0f, 0.0f, 25.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 5.0f;
        this.RequiredHumans = 0;
        this.PlayerObjectID = 101;

        this.RequiresInventor = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public MetalBarricade()
    {
        this.ObjectName = "Metal Barricade";
        this.ObjectDescription = "This is a metal barricade, can be built and sold at night.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Metal Barricade";
        this.ObjectSubtypeID = 2;

        this.MaxHitpoints = 350.0f;
        this.Armor = 5.0f;
        this.Protection = 10.0f;

        this.PositionValue = 0.5f;
        this.PositionObstacle = 3.0f;
        this.PositionDanger = 0.5f;

        this.RepairRate = 1.0f;
        this.RefundRate = 1.0f;

        this.BaseCost = new DataStructures.Cost(75.0f, 0.0f, 0.0f, 25.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 5.0f;
        this.RequiredHumans = 0;
        this.PlayerObjectID = 101;

        this.RequiresInventor = true;
    }
}
