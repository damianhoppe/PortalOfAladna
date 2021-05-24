using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallDeepWood : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Small Deep Wood";
        this.ObjectDescription = "This is a Small Deep Wood.";

        this.OreRichness = 0.5f;
        this.OreType = "Wood";
        this.LimitOre = 2500;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 59;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    SmallDeepWood()
    {
        this.ObjectName = "Small Deep Wood";
        this.ObjectDescription = "This is a Small Deep Wood.";

        this.OreRichness = 0.5f;
        this.OreType = "Wood";
        this.LimitOre = 2500;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 59;
    }
}
