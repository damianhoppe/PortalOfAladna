using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumJeweler : SmallJeweler
{
    public MediumJeweler()
    {
        this.ObjectName = "Medium Jeweler";
        this.ObjectDescription = "This is medium jeweler. Crystal is stored here.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Medium Default Jeweler";
        this.ObjectSubtypeID = 3;

        this.MaxHitpoints = 500.0f;
        this.Armor = 5.0f;
        this.Protection = 10.0f;

        this.PositionValue = 6.0f;
        this.PositionObstacle = 4.0f;

        this.PlayerObjectID = 20;
        this.BuildingStorage = new DataStructures.Cost(0.0f, 0.0f, 0.0f, 0.0f, 400.0f, 0.0f);
        this.BaseCost = new DataStructures.Cost(200.0f, 100.0f, 50.0f, 25.0f, 25.0f, 0.0f);
        this.EnergyToBuild = 15.0f;
        this.RequiredHumans = 5;

        this.RequiresInventor = true;
    }
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
}
