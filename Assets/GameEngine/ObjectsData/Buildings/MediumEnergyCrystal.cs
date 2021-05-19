using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnergyCrystal : SmallEnergyCrystal
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.ObjectName = "Medium Energy Crystal";
        this.ObjectDescription = "This is a medium energy crystal that can generate extra 50 energy per day";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Medium Energy Crystal";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 500.0f;
        this.ActiveAtNight = true;
        this.Armor = 8.0f;
        this.Protection = 10.0f;

        this.PositionValue = 8.0f;
        this.PositionObstacle = 4.0f;
        this.PositionDanger = 8.0f;

        this.BaseCost = new DataStructures.Cost(1000.0f, 0.0f, 0.0f, 150.0f, 150.0f, 0.0f);
        this.RequiredHumans = 10;
        this.EnergyToBuild = 50.0f;
        this.EnergyUse = -50.0f;

        this.PlayerObjectID = 22;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
        this.RequiresAcademy = true;

        this.CurrentHitpoints = this.MaxHitpoints;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public MediumEnergyCrystal()
    {
        this.ObjectName = "Medium Energy Crystal";
        this.ObjectDescription = "This is a medium energy crystal that can generate extra 50 energy per day";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Medium Energy Crystal";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 500.0f;
        this.ActiveAtNight = true;
        this.Armor = 8.0f;
        this.Protection = 10.0f;

        this.PositionValue = 8.0f;
        this.PositionObstacle = 4.0f;
        this.PositionDanger = 8.0f;

        this.BaseCost = new DataStructures.Cost(1000.0f, 0.0f, 0.0f, 150.0f, 150.0f, 0.0f);
        this.RequiredHumans = 10;
        this.EnergyToBuild = 50.0f;
        this.EnergyUse = -50.0f;

        this.PlayerObjectID = 22;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
        this.RequiresAcademy = true;
    }
}
