using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeShallowMetal : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Large Shallow Metal";
        this.ObjectDescription = "This is a Large Shallow Metal.";

        this.OreRichness = 2.5f;
        this.OreType = "Metal";
        this.LimitOre = 10000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 52;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    LargeShallowMetal()
    {
        this.ObjectName = "Large Shallow Metal";
        this.ObjectDescription = "This is a Large Shallow Metal.";

        this.OreRichness = 2.5f;
        this.OreType = "Metal";
        this.LimitOre = 10000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 52;
    }
}
