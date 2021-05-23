using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeShallowGold : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Large Shallow Gold";
        this.ObjectDescription = "This is a Large Shallow Gold.";

        this.OreRichness = 2.5f;
        this.OreType = "Gold";
        this.LimitOre = 10000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 43;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    LargeShallowGold()
    {
        this.ObjectName = "Large Shallow Gold";
        this.ObjectDescription = "This is a Large Shallow Gold.";

        this.OreRichness = 2.5f;
        this.OreType = "Gold";
        this.LimitOre = 10000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 43;
    }
}
