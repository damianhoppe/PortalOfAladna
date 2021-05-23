using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeShallowStone : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Large Shallow Stone";
        this.ObjectDescription = "This is a Large Shallow Stone.";

        this.OreRichness = 2.5f;
        this.OreType = "Stone";
        this.LimitOre = 10000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 49;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    LargeShallowStone()
    {
        this.ObjectName = "Large Shallow Stone";
        this.ObjectDescription = "This is a Large Shallow Stone.";

        this.OreRichness = 2.5f;
        this.OreType = "Stone";
        this.LimitOre = 10000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 49;
    }
}
