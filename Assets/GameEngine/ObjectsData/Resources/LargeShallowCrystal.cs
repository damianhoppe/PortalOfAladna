using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeShallowCrystal : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Large Shallow Crystal";
        this.ObjectDescription = "This is a Large Shallow Crystal.";

        this.OreRichness = 2.5f;
        this.OreType = "Crystal";
        this.LimitOre = 10000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 55;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    LargeShallowCrystal()
    {
        this.ObjectName = "Large Shallow Crystal";
        this.ObjectDescription = "This is a Large Shallow Crystal.";

        this.OreRichness = 2.5f;
        this.OreType = "Crystal";
        this.LimitOre = 10000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 55;
    }
}
