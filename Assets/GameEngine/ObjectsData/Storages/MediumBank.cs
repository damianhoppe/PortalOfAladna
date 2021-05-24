using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBank : SmallBank
{
    public MediumBank()
    {
        this.ObjectName = "Medium Bank";
        this.ObjectDescription = "This is medium bank. Gold is stored here.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Medium Default Bank";
        this.ObjectSubtypeID = 3;

        this.MaxHitpoints = 500.0f;
        this.Armor = 5.0f;
        this.Protection = 10.0f;

        this.PositionValue = 6.0f;
        this.PositionObstacle = 4.0f;

        this.PlayerObjectID = 8;
        this.BuildingStorage = new DataStructures.Cost(1000.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.BaseCost = new DataStructures.Cost(250.0f, 100.0f, 50.0f, 25.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 15.0f;
        this.RequiredHumans = 5;

        this.RequiresInventor = true;
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.ObjectName = "Medium Bank";
        this.ObjectDescription = "This is medium bank. Gold is stored here.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Medium Default Bank";
        this.ObjectSubtypeID = 3;

        this.MaxHitpoints = 500.0f;
        this.Armor = 5.0f;
        this.Protection = 10.0f;

        this.PositionValue = 6.0f;
        this.PositionObstacle = 4.0f;

        this.PlayerObjectID = 8;
        this.BuildingStorage = new DataStructures.Cost(1000.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.BaseCost = new DataStructures.Cost(250.0f, 100.0f, 50.0f, 25.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 15.0f;
        this.RequiredHumans = 5;

        this.RequiresInventor = true;

        this.CurrentHitpoints = this.MaxHitpoints;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
