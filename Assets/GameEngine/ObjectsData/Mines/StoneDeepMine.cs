using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDeepMine : DefaultMine
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Deep Stone Mine";
        this.ObjectDescription = "This is a Deep Stone Mine.";
        this.ObjectType = "Mine";
        this.ObjectTypeID = -1;
        this.ObjectSubtype = "Default Mine";
        this.ObjectSubtypeID = -1;

        this.MaxHitpoints = 250.0f;
        this.ActiveAtNight = false;
        this.Armor = 3.0f;
        this.Protection = 5.0f;

        this.PositionValue = 15.0f;
        this.PositionObstacle = 3.0f;

        this.BaseCost = new DataStructures.Cost(600.0f, 100.0f, 25.0f, 25.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 25.0f;
        this.RequiredHumans = 20;

        this.PlayerObjectID = 36;

        this.MiningPower = 2.0f;
        this.MiningSpeed = 1.0f;
        this.MinedResource = "Stone";
        this.MinesDeep = true;

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

    StoneDeepMine()
    {
        this.ObjectName = "Deep Stone Mine";
        this.ObjectDescription = "This is a Deep Stone Mine.";
        this.ObjectType = "Mine";
        this.ObjectTypeID = -1;
        this.ObjectSubtype = "Default Mine";
        this.ObjectSubtypeID = -1;

        this.MaxHitpoints = 250.0f;
        this.ActiveAtNight = false;
        this.Armor = 3.0f;
        this.Protection = 5.0f;

        this.PositionValue = 15.0f;
        this.PositionObstacle = 3.0f;

        this.BaseCost = new DataStructures.Cost(600.0f, 100.0f, 25.0f, 25.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 25.0f;
        this.RequiredHumans = 20;

        this.PlayerObjectID = 36;

        this.MiningPower = 2.0f;
        this.MiningSpeed = 1.0f;
        this.MinedResource = "Stone";
        this.MinesDeep = true;

        this.CurrentHitpoints = this.MaxHitpoints;

        this.RequiresInventor = true;
        this.RequiresResearcher = false;
        this.RequiresAcademy = false;
    }
}
