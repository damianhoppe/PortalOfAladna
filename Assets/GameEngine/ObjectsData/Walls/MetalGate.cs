using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalGate : StoneGate
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
    public MetalGate()
    {
        this.ObjectName = "Metal Gate";
        this.ObjectDescription = "This is a metal gate.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Metal Gate";
        this.ObjectSubtypeID = 2;

        this.MaxHitpoints = 900.0f;
        this.Armor = 10.0f;
        this.Protection = 10.0f;

        this.PositionValue = -5.0f;
        this.PositionObstacle = 3.0f;
        this.PositionDanger = -5.0f;

        this.BaseCost = new DataStructures.Cost(120.0f, 30.0f, 30.0f, 60.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 15;
        this.PlayerObjectID = 97;

        this.RequiresInventor = true;
    }
}
