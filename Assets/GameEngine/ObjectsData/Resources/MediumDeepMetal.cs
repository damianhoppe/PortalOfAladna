using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumDeepMetal : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Medium Deep Metal";
        this.ObjectDescription = "This is a Medium Deep Metal.";

        this.OreRichness = 1.0f;
        this.OreType = "Metal";
        this.LimitOre = 10000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 66;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    MediumDeepMetal()
    {
        this.ObjectName = "Medium Deep Metal";
        this.ObjectDescription = "This is a Medium Deep Metal.";

        this.OreRichness = 1.0f;
        this.OreType = "Metal";
        this.LimitOre = 10000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 66;
    }
}
