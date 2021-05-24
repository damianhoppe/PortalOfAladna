using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallDeepGold : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Small Deep Gold";
        this.ObjectDescription = "This is a Small Deep Gold.";

        this.OreRichness = 0.5f;
        this.OreType = "Gold";
        this.LimitOre = 2500;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 56;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    SmallDeepGold()
    {
        this.ObjectName = "Small Deep Gold";
        this.ObjectDescription = "This is a Small Deep Gold.";

        this.OreRichness = 0.5f;
        this.OreType = "Gold";
        this.LimitOre = 2500;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 56;
    }
}
