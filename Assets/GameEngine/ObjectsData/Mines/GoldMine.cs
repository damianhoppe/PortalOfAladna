﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMine : DefaultMine
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Small Gold Mine";
        this.ObjectDescription = "This is a Small Gold Mine.";
        this.ObjectType = "Mine";
        this.ObjectTypeID = -1;
        this.ObjectSubtype = "Default Mine";
        this.ObjectSubtypeID = -1;

        this.MaxHitpoints = 50.0f;
        this.ActiveAtNight = false;
        this.Armor = 1.0f;
        this.Protection = 0.0f;

        this.PositionValue = 5.0f;
        this.PositionObstacle = 1.0f;

        this.BaseCost = new DataStructures.Cost(0.0f, 10.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 31;

        this.MiningPower = 1.0f;
        this.MiningSpeed = 1.0f;
        this.MinedResource = "Gold";
        this.MinesDeep = false;

        this.CurrentHitpoints = this.MaxHitpoints;

        this.RequiresInventor = false;
        this.RequiresResearcher = false;
        this.RequiresAcademy = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    GoldMine()
    {
        this.ObjectName = "Small Gold Mine";
        this.ObjectDescription = "This is a Small Gold Mine.";
        this.ObjectType = "Mine";
        this.ObjectTypeID = -1;
        this.ObjectSubtype = "Default Mine";
        this.ObjectSubtypeID = -1;

        this.MaxHitpoints = 50.0f;
        this.ActiveAtNight = false;
        this.Armor = 1.0f;
        this.Protection = 0.0f;

        this.PositionValue = 5.0f;
        this.PositionObstacle = 1.0f;

        this.BaseCost = new DataStructures.Cost(0.0f, 10.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 31;

        this.MiningPower = 1.0f;
        this.MiningSpeed = 1.0f;
        this.MinedResource = "Gold";
        this.MinesDeep = false;

        this.CurrentHitpoints = this.MaxHitpoints;

        this.RequiresInventor = false;
        this.RequiresResearcher = false;
        this.RequiresAcademy = false;
    }
}
