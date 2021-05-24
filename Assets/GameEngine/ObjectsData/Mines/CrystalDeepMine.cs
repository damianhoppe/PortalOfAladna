using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalDeepMine : DefaultMine
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Deep Gold Mine";
        this.ObjectDescription = "This is a Deep Gold Mine.";
        this.ObjectType = "Mine";
        this.ObjectTypeID = -1;
        this.ObjectSubtype = "Default Mine";
        this.ObjectSubtypeID = -1;

        this.MaxHitpoints = 700.0f;
        this.ActiveAtNight = false;
        this.Armor = 10.0f;
        this.Protection = 15.0f;

        this.PositionValue = 25.0f;
        this.PositionObstacle = 5.0f;
        this.PositionDanger = 5.0f;

        this.BaseCost = new DataStructures.Cost(2500.0f, 400.0f, 250.0f, 100.0f, 50.0f, 0.0f);
        this.EnergyToBuild = 75.0f;
        this.RequiredHumans = 50;

        this.PlayerObjectID = 40;

        this.MiningPower = 2.0f;
        this.MiningSpeed = 1.0f;
        this.MinedResource = "Crystal";
        this.MinesDeep = true;

        this.CurrentHitpoints = this.MaxHitpoints;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
        this.RequiresAcademy = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();


    }

    CrystalDeepMine()
    {
        this.ObjectName = "Deep Gold Mine";
        this.ObjectDescription = "This is a Deep Gold Mine.";
        this.ObjectType = "Mine";
        this.ObjectTypeID = -1;
        this.ObjectSubtype = "Default Mine";
        this.ObjectSubtypeID = -1;

        this.MaxHitpoints = 700.0f;
        this.ActiveAtNight = false;
        this.Armor = 10.0f;
        this.Protection = 15.0f;

        this.PositionValue = 25.0f;
        this.PositionObstacle = 5.0f;
        this.PositionDanger = 5.0f;

        this.BaseCost = new DataStructures.Cost(2500.0f, 400.0f, 250.0f, 100.0f, 50.0f, 0.0f);
        this.EnergyToBuild = 75.0f;
        this.RequiredHumans = 50;

        this.PlayerObjectID = 40;

        this.MiningPower = 2.0f;
        this.MiningSpeed = 1.0f;
        this.MinedResource = "Crystal";
        this.MinesDeep = true;

        this.CurrentHitpoints = this.MaxHitpoints;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
        this.RequiresAcademy = true;
    }
}
