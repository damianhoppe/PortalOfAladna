using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBarricade : WoodenBarricade
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public StoneBarricade()
    {
        this.ObjectName = "Stone Barricade";
        this.ObjectDescription = "This is a stone barricade, can be built and sold at night.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Stone Barricade";
        this.ObjectSubtypeID = 2;

        this.MaxHitpoints = 200.0f;
        this.Armor = 2.0f;
        this.Protection = 10.0f;

        this.PositionValue = -1.0f;
        this.PositionObstacle = 2.0f;
        this.PositionDanger = -1.0f;

        this.RepairRate = 1.0f;
        this.RefundRate = 1.0f;

        this.BaseCost = new DataStructures.Cost(50.0f, 0.0f, 25.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 5.0f;
        this.RequiredHumans = 0;
        this.PlayerObjectID = 101;


    }
}
