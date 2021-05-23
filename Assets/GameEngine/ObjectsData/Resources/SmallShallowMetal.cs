using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallShallowMetal : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Small Shallow Metal";
        this.ObjectDescription = "This is a Small Shallow Metal.";

        this.OreRichness = 0.5f;
        this.OreType = "Metal";
        this.LimitOre = 500;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 50;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    SmallShallowMetal()
    {
        this.ObjectName = "Small Shallow Metal";
        this.ObjectDescription = "This is a Small Shallow Metal.";

        this.OreRichness = 0.5f;
        this.OreType = "Metal";
        this.LimitOre = 500;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 50;
    }
}
