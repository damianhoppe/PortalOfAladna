using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeDeepWood : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Large Deep Wood";
        this.ObjectDescription = "This is a Large Deep Wood.";

        this.OreRichness = 2.5f;
        this.OreType = "Wood";
        this.LimitOre = 25000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = true;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 61;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    LargeDeepWood()
    {
        this.ObjectName = "Large Deep Wood";
        this.ObjectDescription = "This is a Large Deep Wood.";

        this.OreRichness = 2.5f;
        this.OreType = "Wood";
        this.LimitOre = 25000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = true;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 61;
    }
}
