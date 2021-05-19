using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWall : MetalWall
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

        this.MaxHitpoints = 1500.0f;
        this.Armor = 20.0f;
        this.Protection = 15.0f;

        this.PositionValue = -8.0f;
        this.PositionObstacle = 8.0f;
        this.PositionDanger = -8.0f;

        this.BaseCost = new DataStructures.Cost(200.0f, 30.0f, 30.0f, 30.0f, 40.0f, 0.0f);
        this.EnergyToBuild = 5.0f;
        this.RequiredHumans = 0;
        this.PlayerObjectID = 94;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;

        this.IsMilitary = true;
        this.IsCivilian = false;
        this.CurrentHitpoints = this.MaxHitpoints;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public MagicWall()
    {
        this.ObjectName = "Metal Wall";
        this.ObjectDescription = "This is a metal wall.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Metal Wall";
        this.ObjectSubtypeID = 2;

        this.MaxHitpoints = 1500.0f;
        this.Armor = 20.0f;
        this.Protection = 15.0f;

        this.PositionValue = -8.0f;
        this.PositionObstacle = 8.0f;
        this.PositionDanger = -8.0f;

        this.BaseCost = new DataStructures.Cost(200.0f, 30.0f, 30.0f, 30.0f, 40.0f, 0.0f);
        this.EnergyToBuild = 5.0f;
        this.RequiredHumans = 0;
        this.PlayerObjectID = 94;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
    }
}
