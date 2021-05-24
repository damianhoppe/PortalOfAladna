using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeDeepCrystal : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Large Deep Crystal";
        this.ObjectDescription = "This is a Large Deep Crystal.";

        this.OreRichness = 2.5f;
        this.OreType = "Crystal";
        this.LimitOre = 25000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = true;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 70;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    LargeDeepCrystal()
    {
        this.ObjectName = "Large Deep Crystal";
        this.ObjectDescription = "This is a Large Deep Crystal.";

        this.OreRichness = 2.5f;
        this.OreType = "Crystal";
        this.LimitOre = 25000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = true;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 70;
    }
}
