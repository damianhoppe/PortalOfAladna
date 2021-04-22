using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnergyCapacitor : SmallEnergyCapacitor
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
    public MediumEnergyCapacitor()
    {
        this.ObjectName = "Medium Energy Capacitor";
        this.ObjectDescription = "This is a medium energy capacitor that can store 150 energy.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Medium Energy Capacitor";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 750.0f;
        this.ActiveAtNight = true;
        this.Armor = 10.0f;
        this.Protection = 15.0f;

        this.PositionValue = 5.0f;
        this.PositionObstacle = 5.0f;
        this.PositionDanger = 5.0f;

        this.BaseCost = new DataStructures.Cost(600.0f, 0.0f, 0.0f, 150.0f, 75.0f, 0.0f);
        this.RequiredHumans = 10;
        this.EnergyToBuild = 50.0f;
        this.EnergyStorage = 150.0f;

        this.PlayerObjectID = 26;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
        this.RequiresAcademy = true;
    }
}
