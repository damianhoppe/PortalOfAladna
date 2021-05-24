using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallShallowCrystal : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Small Shallow Crystal";
        this.ObjectDescription = "This is a Small Shallow Crystal.";

        this.OreRichness = 0.5f;
        this.OreType = "Crystal";
        this.LimitOre = 500;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 53;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    SmallShallowCrystal()
    {
        this.ObjectName = "Small Shallow Crystal";
        this.ObjectDescription = "This is a Small Shallow Crystal.";

        this.OreRichness = 0.5f;
        this.OreType = "Crystal";
        this.LimitOre = 500;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 53;
    }
}
