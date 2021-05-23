using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumShallowMetal : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Medium Shallow Metal";
        this.ObjectDescription = "This is a Medium Shallow Metal.";

        this.OreRichness = 1.0f;
        this.OreType = "Metal";
        this.LimitOre = 2000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 51;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    MediumShallowMetal()
    {
        this.ObjectName = "Medium Shallow Metal";
        this.ObjectDescription = "This is a Medium Shallow Metal.";

        this.OreRichness = 1.0f;
        this.OreType = "Metal";
        this.LimitOre = 2000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 51;
    }
}
