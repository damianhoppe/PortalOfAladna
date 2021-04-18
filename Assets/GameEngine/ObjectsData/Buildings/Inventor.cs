using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventor : DefaultBuilding
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
    public Inventor()
    {
        this.ObjectName = "Inventor";
        this.ObjectDescription = "This is an Inventor. Allows extraction of metal and unlocks metal buildings.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Inventor";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 50.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 2.0f;
        this.PositionObstacle = 1.0f;

        this.BaseCost = new DataStructures.Cost(50.0f, 10.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.PlayerObjectID = 28;
        
    }
}
