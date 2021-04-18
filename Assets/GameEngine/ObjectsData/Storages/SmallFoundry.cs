using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallFoundry : DefaultBuilding
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
    public SmallFoundry()
    {
        this.ObjectName = "Small Foundry";
        this.ObjectDescription = "This is small foundry. Metal is stored here.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Small Default Foundry";
        this.ObjectSubtypeID = 3;

        this.MaxHitpoints = 200.0f;
        this.Armor = 2.0f;
        this.Protection = 5.0f;

        this.PositionValue = 4.0f;
        this.PositionObstacle = 2.0f;

        this.PlayerObjectID = 16;
        this.BuildingStorage = new DataStructures.Cost(0.0f, 0.0f, 0.0f, 100.0f, 0.0f, 0.0f);
        this.BaseCost = new DataStructures.Cost(50.0f, 30.0f, 15.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 0;
    }
    public override void onCreate()
    {
        if (this.CreateAvailable())
        {
            //this.EC.StorageIncrease(this.BuildingStorage);
            base.onCreate();
        }
    }
    public override void onDestroy()
    {
        if (this.DestroyAvailable())
        {
            //this.EC.StorageDecrease(this.BuildingStorage);
            base.onDestroy();
        }
    }
}
