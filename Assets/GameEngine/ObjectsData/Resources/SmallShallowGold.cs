using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallShallowGold : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Small Shallow Gold";
        this.ObjectDescription = "This is a Small Shallow Gold.";

        this.OreRichness = 0.5f;
        this.OreType = "Gold";
        this.LimitOre = 500;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 41;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    SmallShallowGold()
    {
        this.ObjectName = "Small Shallow Gold";
        this.ObjectDescription = "This is a Small Shallow Gold.";

        this.OreRichness = 0.5f;
        this.OreType = "Gold";
        this.LimitOre = 500;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 41;
    }
}
