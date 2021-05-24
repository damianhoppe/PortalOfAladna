using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumShallowCrystal : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Medium Shallow Crystal";
        this.ObjectDescription = "This is a Medium Shallow Crystal.";

        this.OreRichness = 1.0f;
        this.OreType = "Crystal";
        this.LimitOre = 2000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 54;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    MediumShallowCrystal()
    {
        this.ObjectName = "Medium Shallow Crystal";
        this.ObjectDescription = "This is a Medium Shallow Crystal.";

        this.OreRichness = 1.0f;
        this.OreType = "Crystal";
        this.LimitOre = 2000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 54;
    }
}
