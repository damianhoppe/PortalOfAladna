using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnergyCrystal : DefaultBuilding
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
    public SmallEnergyCrystal()
    {
        this.ObjectName = "Small Energy Crystal";
        this.ObjectDescription = "This is a small energy crystal that can generate extra 20 energy per day";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Small Energy Crystal";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 200.0f;
        this.ActiveAtNight = true;
        this.Armor = 4.0f;
        this.Protection = 5.0f;

        this.PositionValue = 4.0f;
        this.PositionObstacle = 2.0f;
        this.PositionDanger = 4.0f;

        this.BaseCost = new DataStructures.Cost(250.0f, 0.0f, 0.0f, 50.0f, 50.0f, 0.0f);
        this.RequiredHumans = 5;
        this.EnergyToBuild = 25.0f;
        this.EnergyUse = -20.0f;

        this.PlayerObjectID = 22;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
    }

    public override void onCreate()
    {
        if (this.CreateAvailable())
        {
            this.EC.IncreaseEnergyRegeneration(-1.0f*this.EnergyUse);
            base.onCreate();
        }
    }
    public override void onDestroy()
    {
        if (this.DestroyAvailable())
        {
            this.EC.DecreaseEnergyRegeneration(-1.0f*this.EnergyUse);
            base.onDestroy();
        }
    }
    public override void onSell()
    {
        if (this.SellAvailable())
        {
            this.EC.DecreaseEnergyRegeneration(-1.0f * this.EnergyUse);
            base.onSell();
        }
        
    }
}
