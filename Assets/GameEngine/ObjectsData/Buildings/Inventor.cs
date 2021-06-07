using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventor : DefaultBuilding
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.ObjectName = "Inventor";
        this.ObjectDescription = "This is an Inventor. Allows extraction of metal and unlocks metal buildings.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Inventor";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 500.0f;
        this.Armor = 3.0f;
        this.Protection = 5.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 5.0f;
        this.PositionObstacle = 3.0f;
        this.PositionDanger = 4.0f;

        this.BaseCost = new DataStructures.Cost(500.0f, 200.0f, 150.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 50.0f;
        this.PlayerObjectID = 28;
        this.RequiredHumans = 25;

        this.CurrentHitpoints = this.MaxHitpoints;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public Inventor()
    {
        this.ObjectName = "Inventor";
        this.ObjectDescription = "This is an Inventor. Allows extraction of metal and unlocks metal buildings.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Inventor";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 500.0f;
        this.Armor = 3.0f;
        this.Protection = 5.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 5.0f;
        this.PositionObstacle = 3.0f;
        this.PositionDanger = 4.0f;

        this.BaseCost = new DataStructures.Cost(500.0f, 200.0f, 150.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 50.0f;
        this.PlayerObjectID = 28;
        this.RequiredHumans = 25;
        
    }
    public override void onCreate()
    {
        base.onCreate();
        if (this.CreateAvailable())
        {
            this.UC.InventorBuilt();
        }
    }
    public override void onDestroy()
    {
        base.onDestroy();
        if (this.DestroyAvailable())
        {
            this.UC.InventorDestroyed();
        }
    }
    public override void onSell()
    {
        if (this.SellAvailable())
        {
            this.UC.InventorDestroyed();
            base.onSell();
        }
    }
}
