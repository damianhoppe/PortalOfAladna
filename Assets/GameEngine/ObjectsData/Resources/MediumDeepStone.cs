using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumDeepStone : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Medium Deep Stone";
        this.ObjectDescription = "This is a Medium Deep Stone.";

        this.OreRichness = 1.0f;
        this.OreType = "Stone";
        this.LimitOre = 10000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 63;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    MediumDeepStone()
    {
        this.ObjectName = "Medium Deep Stone";
        this.ObjectDescription = "This is a Medium Deep Stone.";

        this.OreRichness = 1.0f;
        this.OreType = "Stone";
        this.LimitOre = 10000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 63;
    }
}
