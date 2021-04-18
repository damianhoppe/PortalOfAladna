﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMason : DefaultBuilding
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public SmallMason()
    {
        this.ObjectName = "Small Mason";
        this.ObjectDescription = "This is small mason. Stone is stored here.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Small Default Mason";
        this.ObjectSubtypeID = 3;

        this.MaxHitpoints = 200.0f;
        this.Armor = 2.0f;
        this.Protection = 5.0f;

        this.PositionValue = 4.0f;
        this.PositionObstacle = 2.0f;

        this.PlayerObjectID = 13;
        this.BuildingStorage = new DataStructures.Cost(0.0f, 0.0f, 100.0f, 0.0f, 0.0f, 0.0f);
        this.BaseCost = new DataStructures.Cost(50.0f, 30.0f, 15.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 0;
    }
    public override bool onCreate()
    {
        //EconomyController EC = GameObject.Find("EconomyController").GetComponent<EconomyController>();
        this.EC.StorageIncrease(this.BuildingStorage);
        return base.onCreate();
    }
    public override bool onDestroy()
    {
        //EconomyController EC = GameObject.Find("EconomyController").GetComponent<EconomyController>();
        this.EC.StorageDecrease(this.BuildingStorage);
        return base.onDestroy();
    }
}
