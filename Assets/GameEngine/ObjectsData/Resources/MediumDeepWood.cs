using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumDeepWood : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Medium Deep Wood";
        this.ObjectDescription = "This is a Medium Deep Wood.";

        this.OreRichness = 1.0f;
        this.OreType = "Wood";
        this.LimitOre = 10000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 60;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    MediumDeepWood()
    {
        this.ObjectName = "Medium Deep Wood";
        this.ObjectDescription = "This is a Medium Deep Wood.";

        this.OreRichness = 1.0f;
        this.OreType = "Wood";
        this.LimitOre = 10000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 60;
    }
}
