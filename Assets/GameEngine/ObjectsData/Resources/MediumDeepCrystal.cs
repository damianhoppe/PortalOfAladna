using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumDeepCrystal : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Medium Deep Crystal";
        this.ObjectDescription = "This is a Medium Deep Crystal.";

        this.OreRichness = 1.0f;
        this.OreType = "Crystal";
        this.LimitOre = 10000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 69;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    MediumDeepCrystal()
    {
        this.ObjectName = "Medium Deep Crystal";
        this.ObjectDescription = "This is a Medium Deep Crystal.";

        this.OreRichness = 1.0f;
        this.OreType = "Crystal";
        this.LimitOre = 10000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 69;
    }
}
