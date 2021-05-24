using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalMine : DefaultMine
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Small Metal Mine";
        this.ObjectDescription = "This is a Small Metal Mine.";
        this.ObjectType = "Mine";
        this.ObjectTypeID = -1;
        this.ObjectSubtype = "Default Mine";
        this.ObjectSubtypeID = -1;

        this.MaxHitpoints = 75.0f;
        this.ActiveAtNight = false;
        this.Armor = 2.0f;
        this.Protection = 5.0f;

        this.PositionValue = 7.0f;
        this.PositionObstacle = 1.5f;

        this.BaseCost = new DataStructures.Cost(100.0f, 50.0f, 25.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 20.0f;
        this.RequiredHumans = 10;

        this.PlayerObjectID = 37;

        this.MiningPower = 1.0f;
        this.MiningSpeed = 1.0f;
        this.MinedResource = "Metal";
        this.MinesDeep = false;

        this.CurrentHitpoints = this.MaxHitpoints;

        this.RequiresInventor = true;
        this.RequiresResearcher = false;
        this.RequiresAcademy = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    MetalMine()
    {
        this.ObjectName = "Small Metal Mine";
        this.ObjectDescription = "This is a Small Metal Mine.";
        this.ObjectType = "Mine";
        this.ObjectTypeID = -1;
        this.ObjectSubtype = "Default Mine";
        this.ObjectSubtypeID = -1;

        this.MaxHitpoints = 75.0f;
        this.ActiveAtNight = false;
        this.Armor = 2.0f;
        this.Protection = 5.0f;

        this.PositionValue = 7.0f;
        this.PositionObstacle = 1.5f;

        this.BaseCost = new DataStructures.Cost(100.0f, 50.0f, 25.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 20.0f;
        this.RequiredHumans = 10;

        this.PlayerObjectID = 37;

        this.MiningPower = 1.0f;
        this.MiningSpeed = 1.0f;
        this.MinedResource = "Metal";
        this.MinesDeep = false;

        this.CurrentHitpoints = this.MaxHitpoints;

        this.RequiresInventor = true;
        this.RequiresResearcher = false;
        this.RequiresAcademy = false;
    }
}
