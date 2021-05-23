using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeShallowWood : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Large Shallow Wood";
        this.ObjectDescription = "This is a Large Shallow Wood.";

        this.OreRichness = 2.5f;
        this.OreType = "Wood";
        this.LimitOre = 10000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 46;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    LargeShallowWood()
    {
        this.ObjectName = "Large Shallow Wood";
        this.ObjectDescription = "This is a Large Shallow Wood.";

        this.OreRichness = 2.5f;
        this.OreType = "Wood";
        this.LimitOre = 10000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 46;
    }
}
