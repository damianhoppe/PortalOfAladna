using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalWall : StoneWall
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.ObjectName = "Metal Wall";
        this.ObjectDescription = "This is a metal wall.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Metal Wall";
        this.ObjectSubtypeID = 2;

        this.MaxHitpoints = 900.0f;
        this.Armor = 10.0f;
        this.Protection = 10.0f;

        this.PositionValue = -7.0f;
        this.PositionObstacle = 6.0f;
        this.PositionDanger = -7.0f;

        this.BaseCost = new DataStructures.Cost(100.0f, 20.0f, 20.0f, 40.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 5.0f;
        this.RequiredHumans = 0;
        this.PlayerObjectID = 93;

        this.RequiresInventor = true;

        this.IsMilitary = true;
        this.IsCivilian = false;
        this.CurrentHitpoints = this.MaxHitpoints;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public MetalWall()
    {
        this.ObjectName = "Metal Wall";
        this.ObjectDescription = "This is a metal wall.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Metal Wall";
        this.ObjectSubtypeID = 2;

        this.MaxHitpoints = 900.0f;
        this.Armor = 10.0f;
        this.Protection = 10.0f;

        this.PositionValue = -7.0f;
        this.PositionObstacle = 6.0f;
        this.PositionDanger = -7.0f;

        this.BaseCost = new DataStructures.Cost(100.0f, 20.0f, 20.0f, 40.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 5.0f;
        this.RequiredHumans = 0;
        this.PlayerObjectID = 93;

        this.RequiresInventor = true;
    }
}
