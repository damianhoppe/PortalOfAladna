﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBank : DefaultBuilding
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

    public override string ObjectName { get; protected set; } = "Small Bank";
    public override string ObjectDescription { get; protected set; } = "This is bank. You can store gold here.";
    public override string ObjectType { get; protected set; } = "Building";
    public override int ObjectTypeID { get; protected set; } = 1;
    public override string ObjectSubtype { get; protected set; } = "Small Default Bank";
    public override int ObjectSubtypeID { get; protected set; } = 3;

    public override float MaxHitpoints { get; protected set; } = 200.0f;
    public override DataStructures.Cost BuildingStorage { get; protected set; } = new DataStructures.Cost(500.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);

    public override float Armor { get; protected set; } = 1.0f;
    public override float Protection { get; protected set; } = 10.0f;

    public override float PositionValue { get; protected set; } = 4.0f;
    public override float PositionObstacle { get; protected set; } = 2.0f;

    public override DataStructures.Cost BaseCost { get; protected set; } = new DataStructures.Cost(150.0f, 20.0f, 10.0f, 0.0f, 0.0f, 0.0f);
    public override float EnergyToBuild { get; protected set; } = 20.0f;
    public override int RequiredHumans { get; protected set; } = 10;

    public override bool OnBuild()
    {
        EconomyController EC = GameObject.Find("EconomyController").GetComponent<EconomyController>();
        EC.StorageIncrease(this.BuildingStorage);
        return base.OnBuild();
    }
    public override bool OnDeath()
    {
        EconomyController EC = GameObject.Find("EconomyController").GetComponent<EconomyController>();
        EC.StorageDecrease(this.BuildingStorage);
        return base.OnDeath();
    }
}