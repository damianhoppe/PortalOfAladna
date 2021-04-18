using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeHouse : MediumHouse
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
    LargeHouse()
    {
        this.ObjectName = "Large House";
        this.ObjectDescription = "This is a large house for 40 people.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Large House";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 50.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 3.0f;
        this.PositionObstacle = 1.0f;

        this.BaseCost = new DataStructures.Cost(600.0f, 150.0f, 60.0f, 25.0f, 5.0f, 0.0f);
        this.EnergyToBuild = 20.0f;

        this.PlayerObjectID = 3;

        this.LivingSpace = 40;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
    }
}
