using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenWall : DefaultBuilding
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
    public WoodenWall()
    {
        this.ObjectName = "Wooden Wall";
        this.ObjectDescription = "This is a wooden wall.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Wooden Wall";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 200.0f;
        this.Armor = 5.0f;
        this.Protection = 5.0f;

        this.PositionValue = -5.0f;
        this.PositionObstacle = 2.0f;
        this.PositionDanger = -5.0f;

        this.BaseCost = new DataStructures.Cost(25.0f, 20.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 5.0f;
        this.RequiredHumans = 0;
        this.PlayerObjectID = 91;

        this.RequiresAccess = false;
    }
}
