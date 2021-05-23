using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultResource : Structure
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public DefaultResource() : base(EStructureType.Ore) { }

    public float LimitOre { get; protected set; } = 0.0f;
    public float RemainingOre { get; protected set; } = 0.0f;
    //public Resource OreType { get; protected set; } = "none";
    public string OreType { get; protected set; } = "none";
    public bool Infinite { get; protected set; } = false;
    public bool Depleted { get; protected set; } = false;
    public bool Deep { get; protected set; } = false;
    public float OreRichness { get; protected set; } = 1.0f;

    public DataStructures.Cost Mine(float power)
    {
        DataStructures.Cost yield = new DataStructures.Cost();
        if (this.Depleted) { return yield; }

        float efficiency = power * this.OreRichness;
        if (efficiency > this.RemainingOre)
        {
            efficiency = this.RemainingOre;
            this.Depleted = true;
            this.RemainingOre = 0.0f;
        }
        else this.RemainingOre -= efficiency;

        switch (this.OreType)
        {
            case "Gold":
                yield = DataStructures.Cost.ChangeGold(yield, efficiency);
                break;
            case "Wood":
                yield = DataStructures.Cost.ChangeWood(yield, efficiency);
                break;
            case "Stone":
                yield = DataStructures.Cost.ChangeStone(yield, efficiency);
                break;
            case "Metal":
                yield = DataStructures.Cost.ChangeMetal(yield, efficiency);
                break;
            case "Crystal":
                yield = DataStructures.Cost.ChangeCrystal(yield, efficiency);
                break;
            case "Human":
                yield = DataStructures.Cost.ChangeHumans(yield, efficiency);
                break;
        }
        

        return yield;
    }

}
