using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallDeepStone : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Small Deep Stone";
        this.ObjectDescription = "This is a Small Deep Stone.";

        this.OreRichness = 0.5f;
        this.OreType = "Stone";
        this.LimitOre = 2500;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 62;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    SmallDeepStone()
    {
        this.ObjectName = "Small Deep Stone";
        this.ObjectDescription = "This is a Small Deep Stone.";

        this.OreRichness = 0.5f;
        this.OreType = "Stone";
        this.LimitOre = 2500;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 62;
    }
}
