using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalLookout : WoodenLookout
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Metal Lookout";
        this.ObjectDescription = "This is a metal lookout, with higher view range.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Metal Lookout";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 100.0f;
        this.Armor = 5.0f;
        this.Protection = 10.0f;

        this.SightRange = 5.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 2.0f;
        this.PositionObstacle = 2.5f;
        this.PositionDanger = 3.5f;

        this.BaseCost = new DataStructures.Cost(50.0f, 25.0f, 5.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 5.0f;
        this.RequiredHumans = 10;
        this.PlayerObjectID = 73;

        this.RequiresInventor = true;

        this.CurrentHitpoints = this.MaxHitpoints;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public MetalLookout()
    {
        this.ObjectName = "Metal Lookout";
        this.ObjectDescription = "This is a metal lookout, with higher view range.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Metal Lookout";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 100.0f;
        this.Armor = 5.0f;
        this.Protection = 10.0f;

        this.SightRange = 5.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 2.0f;
        this.PositionObstacle = 2.5f;
        this.PositionDanger = 3.5f;

        this.BaseCost = new DataStructures.Cost(50.0f, 25.0f, 5.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 5.0f;
        this.RequiredHumans = 10;
        this.PlayerObjectID = 73;

        this.RequiresInventor = true;
    }
}
