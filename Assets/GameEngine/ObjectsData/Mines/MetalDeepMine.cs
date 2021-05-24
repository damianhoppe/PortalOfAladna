using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDeepMine : DefaultMine
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Deep Metal Mine";
        this.ObjectDescription = "This is a Deep Metal Mine.";
        this.ObjectType = "Mine";
        this.ObjectTypeID = -1;
        this.ObjectSubtype = "Default Mine";
        this.ObjectSubtypeID = -1;

        this.MaxHitpoints = 350.0f;
        this.ActiveAtNight = false;
        this.Armor = 5.0f;
        this.Protection = 10.0f;

        this.PositionValue = 20.0f;
        this.PositionObstacle = 4.0f;

        this.BaseCost = new DataStructures.Cost(1000.0f, 200.0f, 150.0f, 50.0f, 10.0f, 0.0f);
        this.EnergyToBuild = 50.0f;
        this.RequiredHumans = 30;

        this.PlayerObjectID = 38;

        this.MiningPower = 2.0f;
        this.MiningSpeed = 1.0f;
        this.MinedResource = "Metal";
        this.MinesDeep = true;

        this.CurrentHitpoints = this.MaxHitpoints;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
        this.RequiresAcademy = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();


    }

    MetalDeepMine()
    {
        this.ObjectName = "Deep Metal Mine";
        this.ObjectDescription = "This is a Deep Metal Mine.";
        this.ObjectType = "Mine";
        this.ObjectTypeID = -1;
        this.ObjectSubtype = "Default Mine";
        this.ObjectSubtypeID = -1;

        this.MaxHitpoints = 350.0f;
        this.ActiveAtNight = false;
        this.Armor = 5.0f;
        this.Protection = 10.0f;

        this.PositionValue = 20.0f;
        this.PositionObstacle = 4.0f;

        this.BaseCost = new DataStructures.Cost(1000.0f, 200.0f, 150.0f, 50.0f, 10.0f, 0.0f);
        this.EnergyToBuild = 50.0f;
        this.RequiredHumans = 30;

        this.PlayerObjectID = 38;

        this.MiningPower = 2.0f;
        this.MiningSpeed = 1.0f;
        this.MinedResource = "Metal";
        this.MinesDeep = true;

        this.CurrentHitpoints = this.MaxHitpoints;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
        this.RequiresAcademy = false;
    }
}
