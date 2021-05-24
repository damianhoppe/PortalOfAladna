using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Academy : DefaultBuilding
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.RequiresInventor = true;
        this.RequiresResearcher = true;

        this.ObjectName = "Academy";
        this.ObjectDescription = "This is an Academy. It unlocks magic buildings.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Academy";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 3000.0f;
        this.Armor = 10.0f;
        this.Protection = 15.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 15.0f;
        this.PositionObstacle = 10.0f;
        this.PositionDanger = 10.0f;

        this.BaseCost = new DataStructures.Cost(6000.0f, 600.0f, 500.0f, 250.0f, 100.0f, 0.0f);
        this.EnergyToBuild = 100.0f;
        this.PlayerObjectID = 30;
        this.RequiredHumans = 80;

        this.IsCivilian = false;
        this.IsMilitary = true;
        this.CurrentHitpoints = this.MaxHitpoints;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public Academy()
    {
        this.RequiresInventor = true;
        this.RequiresResearcher = true;

        this.ObjectName = "Academy";
        this.ObjectDescription = "This is an Academy. It unlocks magic buildings.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Academy";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 3000.0f;
        this.Armor = 10.0f;
        this.Protection = 15.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 15.0f;
        this.PositionObstacle = 10.0f;
        this.PositionDanger = 10.0f;

        this.BaseCost = new DataStructures.Cost(6000.0f, 600.0f, 500.0f, 250.0f, 100.0f, 0.0f);
        this.EnergyToBuild = 100.0f;
        this.PlayerObjectID = 30;
        this.RequiredHumans = 80;
    }
    public override void onCreate()
    {
        if (this.CreateAvailable())
        {
            this.UC.AcademyBuilt();
            base.onCreate();
        }
    }
    public override void onDestroy()
    {
        if (this.DestroyAvailable())
        {
            this.UC.AcademyDestroyed();
            base.onDestroy();
        }
    }
    public override void onSell()
    {
        if (this.SellAvailable())
        {
            this.UC.AcademyDestroyed();
            base.onSell();
        }
    }
}
