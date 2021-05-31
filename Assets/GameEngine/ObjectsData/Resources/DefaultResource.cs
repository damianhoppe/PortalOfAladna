using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultResource : Structure
{
    // Start is called before the first frame update
    protected override void Start()
    {
        this.PlayerBuildable = false;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public DefaultResource() : base(EStructureType.Ore) {
        this.category = EStructureCategory.Ores;
    }

    
    public virtual string ObjectDescription { get; protected set; } = "Default Ore description";
    public virtual string ObjectType { get; protected set; } = "Default Ore";

    public float LimitOre { get; protected set; } = 0.0f;
    public float RemainingOre { get; protected set; } = 0.0f;
    //public Resource OreType { get; protected set; } = "none";
    public string OreType { get; protected set; } = "none";
    public bool Infinite { get; protected set; } = false;
    public bool Depleted { get; protected set; } = false;
    public bool Deep { get; protected set; } = false;
    public float OreRichness { get; protected set; } = 1.0f;

    

    public void SetProperties(float Limit, float Remaining, string Type, bool In, bool Depl, bool Dee, float Rich)
    {
        this.LimitOre = Limit;
        this.RemainingOre = Remaining;
        SetType(Type);
        this.Infinite = In;
        this.Depleted = Depl;
        this.Deep = Dee;
        this.OreRichness = Rich;
    }
    public void SetLimit(float Limit)
    {
        this.LimitOre = Limit;
    }
    public void SetRemaining(float Remaining)
    {
        this.RemainingOre = Remaining;
    }
    public void SetType(string Type)
    {
        switch (Type)
        {
            case "Wood":
                this.OreType = Type;
                break;
            case "Stone":
                this.OreType = Type;
                break;
            case "Metal":
                this.OreType = Type;
                break;
            case "Crystal":
                this.OreType = Type;
                break;
            default:
                this.OreType = "Gold";
                break;
        }
    }
    public void SetInfinite(bool Infi)
    {
        this.Infinite = Infi;
    }
    public void SetDeep(bool Deepth)
    {
        this.Deep = Deepth;
    }
    public void SetDepleted(bool Depl)
    {
        this.Depleted = Depl;
    }
    public void SetRichness(float Rich)
    {
        this.OreRichness = Rich;
    }
    public DataStructures.Cost Mine(float power)
    {
        DataStructures.Cost yield = new DataStructures.Cost();
        if (this.Depleted) { return yield; }

        float efficiency = power * this.OreRichness;
        if (this.Infinite)
        {

        }
        else
        {
            if (efficiency > this.RemainingOre)
            {
                efficiency = this.RemainingOre;
                this.Depleted = true;
                this.RemainingOre = 0.0f;
            }
            else this.RemainingOre -= efficiency;
        }
        

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
