using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicGate : MetalGate
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
    public MagicGate()
    {
        this.ObjectName = "Metal Gate";
        this.ObjectDescription = "This is a metal gate.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Metal Gate";
        this.ObjectSubtypeID = 2;

        this.MaxHitpoints = 1500.0f;
        this.Armor = 20.0f;
        this.Protection = 15.0f;

        this.PositionValue = -6.0f;
        this.PositionObstacle = 4.0f;
        this.PositionDanger = -6.0f;

        this.BaseCost = new DataStructures.Cost(250.0f, 45.0f, 45.0f, 45.0f, 60.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 10;
        this.PlayerObjectID = 98;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
    }
}
