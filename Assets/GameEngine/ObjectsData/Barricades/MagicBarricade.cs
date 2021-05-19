using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBarricade : MetalBarricade
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.ObjectName = "Magic Barricade";
        this.ObjectDescription = "This is a magic barricade, can be built and sold at night.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Magic Barricade";
        this.ObjectSubtypeID = 2;

        this.MaxHitpoints = 600.0f;
        this.Armor = 10.0f;
        this.Protection = 15.0f;
        this.CurrentHitpoints = this.MaxHitpoints;
        this.PositionValue = 2.0f;
        this.PositionObstacle = 5.0f;
        this.PositionDanger = 2.0f;

        this.RepairRate = 1.0f;
        this.RefundRate = 1.0f;

        this.BaseCost = new DataStructures.Cost(100.0f, 0.0f, 0.0f, 0.0f, 25.0f, 0.0f);
        this.EnergyToBuild = 5.0f;
        this.RequiredHumans = 0;
        this.PlayerObjectID = 102;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public MagicBarricade()
    {
        this.ObjectName = "Magic Barricade";
        this.ObjectDescription = "This is a magic barricade, can be built and sold at night.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Magic Barricade";
        this.ObjectSubtypeID = 2;

        this.MaxHitpoints = 600.0f;
        this.Armor = 10.0f;
        this.Protection = 15.0f;

        this.PositionValue = 2.0f;
        this.PositionObstacle = 5.0f;
        this.PositionDanger = 2.0f;

        this.RepairRate = 1.0f;
        this.RefundRate = 1.0f;

        this.BaseCost = new DataStructures.Cost(100.0f, 0.0f, 0.0f, 0.0f, 25.0f, 0.0f);
        this.EnergyToBuild = 5.0f;
        this.RequiredHumans = 0;
        this.PlayerObjectID = 102;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
    }

}
