using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumDeepGold : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Medium Deep Gold";
        this.ObjectDescription = "This is a Medium Deep Gold.";

        this.OreRichness = 1.0f;
        this.OreType = "Gold";
        this.LimitOre = 10000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 57;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    MediumDeepGold()
    {
        this.ObjectName = "Medium Deep Gold";
        this.ObjectDescription = "This is a Medium Deep Gold.";

        this.OreRichness = 1.0f;
        this.OreType = "Gold";
        this.LimitOre = 10000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = true;

        this.PlayerObjectID = 57;
    }
}
