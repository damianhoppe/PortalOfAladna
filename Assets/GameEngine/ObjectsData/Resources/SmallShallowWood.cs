using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallShallowWood : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Small Shallow Wood";
        this.ObjectDescription = "This is a Small Shallow Wood.";

        this.OreRichness = 0.5f;
        this.OreType = "Wood";
        this.LimitOre = 500;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 44;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    SmallShallowWood()
    {
        this.ObjectName = "Small Shallow Wood";
        this.ObjectDescription = "This is a Small Shallow Wood.";

        this.OreRichness = 0.5f;
        this.OreType = "Wood";
        this.LimitOre = 500;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 44;
    }
}
