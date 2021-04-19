using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicLookout : WoodenLookout
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
    public MagicLookout()
    {
        this.ObjectName = "Magic Lookout";
        this.ObjectDescription = "This is a magic lookout, with higher view range.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Magic Lookout";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 1000.0f;
        this.Armor = 10.0f;
        this.Protection = 15.0f;

        this.SightRange = 7.5f;
        this.ActiveAtNight = true;

        this.PositionValue = 3.0f;
        this.PositionObstacle = 4.0f;
        this.PositionDanger = 5.0f;

        this.BaseCost = new DataStructures.Cost(50.0f, 25.0f, 5.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 5.0f;
        this.RequiredHumans = 5;
        this.PlayerObjectID = 74;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
    }
}
