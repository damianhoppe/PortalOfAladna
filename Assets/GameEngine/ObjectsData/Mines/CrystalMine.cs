using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalMine : DefaultMine
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Small Crystal Mine";
        this.ObjectDescription = "This is a Small Crystal Mine.";
        this.ObjectType = "Mine";
        this.ObjectTypeID = -1;
        this.ObjectSubtype = "Default Mine";
        this.ObjectSubtypeID = -1;

        this.MaxHitpoints = 150.0f;
        this.ActiveAtNight = false;
        this.Armor = 5.0f;
        this.Protection = 10.0f;

        this.PositionValue = 10.0f;
        this.PositionObstacle = 3.0f;
        this.PositionDanger = 3.0f;

        this.BaseCost = new DataStructures.Cost(300.0f, 100.0f, 100.0f, 25.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 30.0f;
        this.RequiredHumans = 15;

        this.PlayerObjectID = 39;

        this.MiningPower = 1.0f;
        this.MiningSpeed = 1.0f;
        this.MinedResource = "Crystal";
        this.MinesDeep = false;

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

    CrystalMine()
    {
        this.ObjectName = "Small Crystal Mine";
        this.ObjectDescription = "This is a Small Crystal Mine.";
        this.ObjectType = "Mine";
        this.ObjectTypeID = -1;
        this.ObjectSubtype = "Default Mine";
        this.ObjectSubtypeID = -1;

        this.MaxHitpoints = 150.0f;
        this.ActiveAtNight = false;
        this.Armor = 5.0f;
        this.Protection = 10.0f;

        this.PositionValue = 10.0f;
        this.PositionObstacle = 3.0f;

        this.BaseCost = new DataStructures.Cost(300.0f, 100.0f, 100.0f, 25.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 30.0f;
        this.RequiredHumans = 15;

        this.PlayerObjectID = 39;

        this.MiningPower = 1.0f;
        this.MiningSpeed = 1.0f;
        this.MinedResource = "Crystal";
        this.MinesDeep = false;

        this.CurrentHitpoints = this.MaxHitpoints;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
        this.RequiresAcademy = false;
    }
}
