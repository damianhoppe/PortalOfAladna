using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumShallowWood : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Medium Shallow Wood";
        this.ObjectDescription = "This is a Medium Shallow Wood.";

        this.OreRichness = 1.0f;
        this.OreType = "Wood";
        this.LimitOre = 2000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 45;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    MediumShallowWood()
    {
        this.ObjectName = "Medium Shallow Wood";
        this.ObjectDescription = "This is a Medium Shallow Wood.";

        this.OreRichness = 1.0f;
        this.OreType = "Wood";
        this.LimitOre = 2000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 45;
    }
}
