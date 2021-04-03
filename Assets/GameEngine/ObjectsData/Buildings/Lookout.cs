﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookout : DefaultBuilding
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
    public Lookout()
    {
        this.ObjectName = "Lookout";
        this.ObjectDescription = "This is a lookout, with high view range.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Lookout";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.Armor = 1.0f;
        this.Protection = 5.0f;

        this.MaxHitpoints = 100.0f;
        this.SightRange = 5.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 1.0f;
        this.PositionObstacle = 1.0f;
        this.PositionDanger = 2.5f;

        this.BaseCost = new DataStructures.Cost(50.0f, 15.0f, 5.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 5;
    }
    /*
    public override string ObjectName { get; protected set; } = "Lookout";
    public override string ObjectDescription { get; protected set; } = "This is a lookout, with high view range.";
    public override string ObjectType { get; protected set; } = "Building";
    public override int ObjectTypeID { get; protected set; } = 1;
    public override string ObjectSubtype { get; protected set; } = "Default Lookout";
    public override int ObjectSubtypeID { get; protected set; } = 2;

    public override bool IsMilitary { get; protected set; } = true;
    public override bool IsCivilian { get; protected set; } = false;

    public override float Armor { get; protected set; } = 1.0f;
    public override float Protection { get; protected set; } = 5.0f;

    public override float MaxHitpoints { get; protected set; } = 100.0f;
    public override float SightRange { get; protected set; } = 5.0f;
    public override bool ActiveAtNight { get; protected set; } = true;

    public override float PositionValue { get; protected set; } = 1.0f;
    public override float PositionObstacle { get; protected set; } = 1.0f;
    public override float PositionDanger { get; protected set; } = 2.5f;

    public override DataStructures.Cost BaseCost { get; protected set; } = new DataStructures.Cost(50.0f, 15.0f, 5.0f, 0.0f, 0.0f, 0.0f);
    public override float EnergyToBuild { get; protected set; } = 10.0f;
    public override int RequiredHumans { get; protected set; } = 5;
    */
    public override bool onCreate()
    {

        return base.onCreate();
    }
    public override bool onDestroy()
    {

        return base.onDestroy();
    }
}
