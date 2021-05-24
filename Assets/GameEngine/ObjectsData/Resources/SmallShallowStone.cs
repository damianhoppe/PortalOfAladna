using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallShallowStone : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Small Shallow Stone";
        this.ObjectDescription = "This is a Small Shallow Stone.";

        this.OreRichness = 0.5f;
        this.OreType = "Stone";
        this.LimitOre = 500;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 47;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    SmallShallowStone()
    {
        this.ObjectName = "Small Shallow Stone";
        this.ObjectDescription = "This is a Small Shallow Stone.";

        this.OreRichness = 0.5f;
        this.OreType = "Stone";
        this.LimitOre = 500;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 47;
    }
}
