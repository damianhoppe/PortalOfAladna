using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenGate : DefaultBuilding
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
    public WoodenGate()
    {
        this.ObjectName = "Wooden Gate";
        this.ObjectDescription = "This is a wooden gate.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Wooden Gate";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 200.0f;
        this.Armor = 5.0f;
        this.Protection = 5.0f;

        this.PositionValue = -3.0f;
        this.PositionObstacle = 1.5f;
        this.PositionDanger = -3.0f;

        this.BaseCost = new DataStructures.Cost(30.0f, 30.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 5;
        this.PlayerObjectID = 95;

        this.BlocksPlayerUnits = false;
    }
}
