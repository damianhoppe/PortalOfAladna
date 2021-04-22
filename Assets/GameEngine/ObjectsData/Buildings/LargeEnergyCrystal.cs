using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeEnergyCrystal : MediumEnergyCrystal
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
    public LargeEnergyCrystal()
    {
        this.ObjectName = "Large Energy Crystal";
        this.ObjectDescription = "This is a large energy crystal that can generate extra 100 energy per day";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Large Energy Crystal";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 1000.0f;
        this.ActiveAtNight = true;
        this.Armor = 12.0f;
        this.Protection = 15.0f;

        this.PositionValue = 15.0f;
        this.PositionObstacle = 8.0f;
        this.PositionDanger = 15.0f;

        this.BaseCost = new DataStructures.Cost(400.0f, 0.0f, 0.0f, 300.0f, 500.0f, 0.0f);
        this.RequiredHumans = 15;
        this.EnergyToBuild = 100.0f;
        this.EnergyUse = -100.0f;

        this.PlayerObjectID = 24;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
        this.RequiresAcademy = true;
    }
}
