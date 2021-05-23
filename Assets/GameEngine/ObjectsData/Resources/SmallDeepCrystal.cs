using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallDeepCrystal : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Small Deep Crystal";
        this.ObjectDescription = "This is a Small Deep Crystal.";

        this.OreRichness = 0.5f;
        this.OreType = "Crystal";
        this.LimitOre = 2500;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 68;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    SmallDeepCrystal()
    {
        this.ObjectName = "Small Deep Crystal";
        this.ObjectDescription = "This is a Small Deep Crystal.";

        this.OreRichness = 0.5f;
        this.OreType = "Crystal";
        this.LimitOre = 2500;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 68;
    }
}
