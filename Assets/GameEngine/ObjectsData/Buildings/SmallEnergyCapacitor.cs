using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnergyCapacitor : DefaultBuilding
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
    public SmallEnergyCapacitor()
    {
        this.ObjectName = "Small Energy Capacitor";
        this.ObjectDescription = "This is a small energy capacitor that can store 50 energy.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Small Energy Capacitor";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 300.0f;
        this.ActiveAtNight = true;
        this.Armor = 5.0f;
        this.Protection = 10.0f;

        this.PositionValue = 3.0f;
        this.PositionObstacle = 3.0f;
        this.PositionDanger = 3.0f;

        this.BaseCost = new DataStructures.Cost(150.0f, 0.0f, 0.0f, 50.0f, 25.0f, 0.0f);
        this.RequiredHumans = 5;
        this.EnergyToBuild = 25.0f;
        this.EnergyStorage = 50.0f;

        this.PlayerObjectID = 25;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
    }

    public override void onCreate()
    {
        if (this.CreateAvailable())
        {
            this.EC.IncreaseEnergyLimit(this.EnergyStorage);
            base.onCreate();
        }
    }
    public override void onDestroy()
    {
        if (this.DestroyAvailable())
        {
            this.EC.DecreaseEnergyLimit(this.EnergyStorage);
            base.onDestroy();
        }
    }
    public override void onSell()
    {
        if (this.SellAvailable())
        {
            this.EC.DecreaseEnergyLimit(this.EnergyStorage);
            base.onSell();
        }
    }
}
