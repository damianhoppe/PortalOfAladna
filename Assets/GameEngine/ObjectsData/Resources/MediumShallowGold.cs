using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumShallowGold : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Medium Shallow Gold";
        this.ObjectDescription = "This is a Medium Shallow Gold.";

        this.OreRichness = 1.0f;
        this.OreType = "Gold";
        this.LimitOre = 2000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 42;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    MediumShallowGold()
    {
        this.ObjectName = "Medium Shallow Gold";
        this.ObjectDescription = "This is a Medium Shallow Gold.";

        this.OreRichness = 1.0f;
        this.OreType = "Gold";
        this.LimitOre = 2000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 42;
    }
}
