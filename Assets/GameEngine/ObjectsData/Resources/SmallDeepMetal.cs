using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallDeepMetal : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Small Deep Metal";
        this.ObjectDescription = "This is a Small Deep Metal.";

        this.OreRichness = 0.5f;
        this.OreType = "Metal";
        this.LimitOre = 2500;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 65;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    SmallDeepMetal()
    {
        this.ObjectName = "Small Deep Metal";
        this.ObjectDescription = "This is a Small Deep Metal.";

        this.OreRichness = 0.5f;
        this.OreType = "Metal";
        this.LimitOre = 2500;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 65;
    }
}
