using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGate : WoodenGate
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
    public StoneGate()
    {
        this.ObjectName = "Stone Gate";
        this.ObjectDescription = "This is a stone gate.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Stone Gate";
        this.ObjectSubtypeID = 2;

        this.MaxHitpoints = 500.0f;
        this.Armor = 7.5f;
        this.Protection = 7.5f;

        this.PositionValue = -4.0f;
        this.PositionObstacle = 2.0f;
        this.PositionDanger = -4.0f;

        this.BaseCost = new DataStructures.Cost(60.0f, 15.0f, 45.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 10;
        this.PlayerObjectID = 96;

    }
}
