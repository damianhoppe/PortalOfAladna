using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeDeepGold : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Large Deep Gold";
        this.ObjectDescription = "This is a Large Deep Gold.";

        this.OreRichness = 2.5f;
        this.OreType = "Gold";
        this.LimitOre = 25000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = true;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 58;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    LargeDeepGold()
    {
        this.ObjectName = "Large Deep Gold";
        this.ObjectDescription = "This is a Large Deep Gold.";

        this.OreRichness = 2.5f;
        this.OreType = "Gold";
        this.LimitOre = 2500;
        this.RemainingOre = this.LimitOre;

        this.Infinite = true;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 58;
    }
}
