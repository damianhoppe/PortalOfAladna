using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumShallowStone : DefaultResource
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Medium Shallow Stone";
        this.ObjectDescription = "This is a Medium Shallow Stone.";

        this.OreRichness = 1.0f;
        this.OreType = "Stone";
        this.LimitOre = 2000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 48;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    MediumShallowStone()
    {
        this.ObjectName = "Medium Shallow Stone";
        this.ObjectDescription = "This is a Medium Shallow Stone.";

        this.OreRichness = 1.0f;
        this.OreType = "Stone";
        this.LimitOre = 2000;
        this.RemainingOre = this.LimitOre;

        this.Infinite = false;
        this.Depleted = false;
        this.Deep = false;

        this.PlayerObjectID = 48;
    }
}
