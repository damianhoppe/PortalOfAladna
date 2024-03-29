﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeCarpenter : MediumCarpenter
{
    public LargeCarpenter()
    {
        this.ObjectName = "Large Carpenter";
        this.ObjectDescription = "This is large carpenter. Wood is stored here.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Large Default Carpenter";
        this.ObjectSubtypeID = 3;

        this.MaxHitpoints = 1000.0f;
        this.Armor = 10.0f;
        this.Protection = 15.0f;

        this.PositionValue = 8.0f;
        this.PositionObstacle = 6.0f;

        this.PlayerObjectID = 12;
        this.BuildingStorage = new DataStructures.Cost(0.0f, 2000.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.BaseCost = new DataStructures.Cost(800.0f, 400.0f, 200.0f, 100.0f, 10.0f, 0.0f);
        this.EnergyToBuild = 20.0f;
        this.RequiredHumans = 15;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.ObjectName = "Large Carpenter";
        this.ObjectDescription = "This is large carpenter. Wood is stored here.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Large Default Carpenter";
        this.ObjectSubtypeID = 3;

        this.MaxHitpoints = 1000.0f;
        this.Armor = 10.0f;
        this.Protection = 15.0f;

        this.PositionValue = 8.0f;
        this.PositionObstacle = 6.0f;

        this.PlayerObjectID = 12;
        this.BuildingStorage = new DataStructures.Cost(0.0f, 2000.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.BaseCost = new DataStructures.Cost(800.0f, 400.0f, 200.0f, 100.0f, 10.0f, 0.0f);
        this.EnergyToBuild = 20.0f;
        this.RequiredHumans = 15;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;

        this.CurrentHitpoints = this.MaxHitpoints;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
