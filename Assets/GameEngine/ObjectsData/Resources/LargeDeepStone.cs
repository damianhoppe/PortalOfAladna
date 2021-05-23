using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeDeepStone : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Large Deep Stone";
        this.ObjectDescription = "This is a Large Deep Stone.";

        this.OreRichness = 2.5f;
        this.OreType = "Stone";
        this.LimitOre = 25000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = true;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 64;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    LargeDeepStone()
    {
        this.ObjectName = "Large Deep Stone";
        this.ObjectDescription = "This is a Large Deep Stone.";

        this.OreRichness = 2.5f;
        this.OreType = "Stone";
        this.LimitOre = 25000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = true;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 64;
    }
}
