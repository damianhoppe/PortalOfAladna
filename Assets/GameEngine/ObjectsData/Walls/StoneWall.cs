using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneWall : WoodenWall
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.ObjectName = "Stone Wall";
        this.ObjectDescription = "This is a stone wall.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Stone Wall";
        this.ObjectSubtypeID = 2;

        this.MaxHitpoints = 500.0f;
        this.Armor = 7.5f;
        this.Protection = 7.5f;

        this.PositionValue = -6.0f;
        this.PositionObstacle = 4.0f;
        this.PositionDanger = -6.0f;

        this.BaseCost = new DataStructures.Cost(50.0f, 10.0f, 30.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 5.0f;
        this.RequiredHumans = 0;
        this.PlayerObjectID = 92;
        this.IsMilitary = true;
        this.IsCivilian = false;
        this.CurrentHitpoints = this.MaxHitpoints;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public StoneWall()
    {
        this.ObjectName = "Stone Wall";
        this.ObjectDescription = "This is a stone wall.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Stone Wall";
        this.ObjectSubtypeID = 2;

        this.MaxHitpoints = 500.0f;
        this.Armor = 7.5f;
        this.Protection = 7.5f;

        this.PositionValue = -6.0f;
        this.PositionObstacle = 4.0f;
        this.PositionDanger = -6.0f;

        this.BaseCost = new DataStructures.Cost(50.0f, 10.0f, 30.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 5.0f;
        this.RequiredHumans = 0;
        this.PlayerObjectID = 92;

    }
}
