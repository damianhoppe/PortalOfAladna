using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeEnergyCapacitor : MediumEnergyCapacitor
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.ObjectName = "Large Energy Capacitor";
        this.ObjectDescription = "This is a Large energy capacitor that can store 400 energy.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Large Energy Capacitor";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 1500.0f;
        this.ActiveAtNight = true;
        this.Armor = 15.0f;
        this.Protection = 20.0f;

        this.PositionValue = 8.0f;
        this.PositionObstacle = 8.0f;
        this.PositionDanger = 8.0f;

        this.BaseCost = new DataStructures.Cost(2400.0f, 0.0f, 0.0f, 300.0f, 250.0f, 0.0f);
        this.RequiredHumans = 15;
        this.EnergyToBuild = 100.0f;
        this.EnergyStorage = 400.0f;

        this.PlayerObjectID = 27;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
        this.RequiresAcademy = true;

        this.IsMilitary = true;
        this.IsCivilian = false;
        this.CurrentHitpoints = this.MaxHitpoints;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public LargeEnergyCapacitor()
    {
        this.ObjectName = "Large Energy Capacitor";
        this.ObjectDescription = "This is a Large energy capacitor that can store 400 energy.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Large Energy Capacitor";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 1500.0f;
        this.ActiveAtNight = true;
        this.Armor = 15.0f;
        this.Protection = 20.0f;

        this.PositionValue = 8.0f;
        this.PositionObstacle = 8.0f;
        this.PositionDanger = 8.0f;

        this.BaseCost = new DataStructures.Cost(2400.0f, 0.0f, 0.0f, 300.0f, 250.0f, 0.0f);
        this.RequiredHumans = 15;
        this.EnergyToBuild = 100.0f;
        this.EnergyStorage = 400.0f;

        this.PlayerObjectID = 27;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
        this.RequiresAcademy = true;
    }
}
