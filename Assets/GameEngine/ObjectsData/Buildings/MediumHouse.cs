using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumHouse : SmallHouse
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.ObjectName = "Medium House";
        this.ObjectDescription = "This is a medium house for 25 people.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Medium House";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 200.0f;
        this.ActiveAtNight = true;
        this.Armor = 2.0f;
        this.Protection = 5.0f;

        this.PositionValue = 6.0f;
        this.PositionObstacle = 2.0f;

        this.BaseCost = new DataStructures.Cost(200.0f, 60.0f, 25.0f, 5.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 15.0f;

        this.PlayerObjectID = 2;

        this.LivingSpace = 25;

        this.RequiresInventor = true;

        this.CurrentHitpoints = this.MaxHitpoints;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public MediumHouse()
    {
        this.ObjectName = "Medium House";
        this.ObjectDescription = "This is a medium house for 25 people.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Medium House";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 200.0f;
        this.ActiveAtNight = true;
        this.Armor = 2.0f;
        this.Protection = 5.0f;

        this.PositionValue = 6.0f;
        this.PositionObstacle = 2.0f;

        this.BaseCost = new DataStructures.Cost(200.0f, 60.0f, 25.0f, 5.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 15.0f;

        this.PlayerObjectID = 2;

        this.LivingSpace = 25;

        this.RequiresInventor = true;
    }
}
