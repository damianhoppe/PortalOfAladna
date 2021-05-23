using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeDeepMetal : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Large Deep Metal";
        this.ObjectDescription = "This is a Large Deep Metal.";

        this.OreRichness = 2.5f;
        this.OreType = "Metal";
        this.LimitOre = 25000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = true;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 67;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    LargeDeepMetal()
    {
        this.ObjectName = "Large Deep Metal";
        this.ObjectDescription = "This is a Large Deep Metal.";

        this.OreRichness = 2.5f;
        this.OreType = "Metal";
        this.LimitOre = 25000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = true;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 67;
    }
}
