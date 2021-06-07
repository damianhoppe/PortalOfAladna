using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //this.PlayerResources = LOAD POSIADANE SUROWCE xD
        this.EnergyLimit = this.DefaultEnergyLimit; //+X*EnergyLimit_UpgradeLevel
        this.EnergyRegeneration = this.DefaultEnergyRegeneration; //+ X*EnergyRegen_UpgradeLevel
        this.StartEnergy = this.DefaultStartEnergy; // + X*StartEnergy_UpgradeLevel
        this.CurrentEnergy = this.StartEnergy;
        this.PlayerResources = new DataStructures.Cost(0,0,0,0,0,0);
        this.PlayerResources = new DataStructures.Cost(300, 100, 100, 25, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Dictionary<string, float> SaveMe()
    {
        Dictionary<string, float> save = new Dictionary<string, float>();
        save.Add("EnergyLimit",EnergyLimit);
        save.Add("EnergyRegeneration", EnergyRegeneration);
        save.Add("StartEnergy", StartEnergy);
        save.Add("CurrentEnergy", CurrentEnergy);
        save.Add("Crystals", PlayerResources.Crystals);
        save.Add("Gold", PlayerResources.Gold);
        save.Add("Humans", PlayerResources.Humans);
        save.Add("Metal", PlayerResources.Metal);
        save.Add("Stone", PlayerResources.Stone);
        save.Add("Wood", PlayerResources.Wood);

        return save;
    }
    public void LoadMe(Dictionary<string, float> save)
    {
        float data;
        save.TryGetValue("EnergyLimit", out data);
        EnergyLimit = data;
        save.TryGetValue("EnergyRegeneration", out data);
        EnergyRegeneration = data;
        save.TryGetValue("StartEnergy", out data);
        StartEnergy = data;
        save.TryGetValue("Crystals", out data);
        float Crystals = data;
        save.TryGetValue("Gold", out data);
        float Gold = data;
        save.TryGetValue("Humans", out data);
        float Humans = data;
        save.TryGetValue("Metal", out data);
        float Metal = data;
        save.TryGetValue("Stone", out data);
        float Stone = data;
        save.TryGetValue("Wood", out data);
        float value;
        if(save.TryGetValue("Wood", out value))
        {
            Debug.Log("EEE "+ value);
        }
        else
        {
            Debug.Log("NOPE");
        }
        float Wood = data;
        Debug.Log(Wood);
        this.PlayerResources = new DataStructures.Cost((int)Gold,(int)Wood,(int)Stone,(int)Metal,(int)Crystals,(int)Humans);


    }
    public DataStructures.Cost PlayerResources { get; protected set; }// = new DataStructures.Cost();
    //portal może mieć pewną wartość magazynu - wtedy TotalStorage powinno być (0,0,0,0,0,0,)
    public DataStructures.Cost TotalStorage { get; protected set; } = new DataStructures.Cost(500.0f, 50.0f, 50.0f, 50.0f, 50.0f, 0.0f);
    
    public float DefaultEnergyLimit { get; protected set; } = 100.0f;
    public float DefaultEnergyRegeneration { get; protected set; } = 50.0f;
    public float DefaultStartEnergy { get; protected set; } = 100.0f;

    public float EnergyLimit { get; protected set; }
    public float EnergyRegeneration { get; protected set; }
    public float StartEnergy { get; protected set; }
    public float CurrentEnergy { get; protected set; }

    public bool CanAffordTEST(DataStructures.Cost koszt, float energy_cost)
    {
        
        return true;
    }
    public bool CanAfford(DataStructures.Cost koszt,float energy_cost)
    {
        if (koszt.Gold > PlayerResources.Gold) return false;
        else if (koszt.Wood > PlayerResources.Wood) return false;
        else if (koszt.Stone > PlayerResources.Stone) return false;
        else if (koszt.Metal > PlayerResources.Metal) return false;
        else if (koszt.Crystals > PlayerResources.Crystals) return false;
        else if (koszt.Humans > PlayerResources.Humans) return false;
        else if (this.EnoughEnergy(energy_cost) != true) return false;
        else return true;
    }
    public void ResourcesSpent(DataStructures.Cost koszt)
    {
        this.PlayerResources -= koszt;
    }
    public void ResourcesGained (DataStructures.Cost zysk)
    {
        this.PlayerResources += zysk;
    }
    public void StorageIncrease(DataStructures.Cost storage)
    {
        this.TotalStorage += storage;
    }
    public void StorageDecrease(DataStructures.Cost storage)
    {
        this.TotalStorage -= storage;
    }
    public void AddEnergy(float energy)
    {
        this.CurrentEnergy += energy;
    }
    public void DrainEnergy(float energy)
    {
        this.CurrentEnergy -= energy;
        if (this.CurrentEnergy >= this.EnergyLimit)
        {
            this.CurrentEnergy = this.EnergyLimit;
        }
    }
    public void IncreaseEnergyLimit(float energy)
    {
        this.DefaultEnergyLimit += energy;
    }
    public void DecreaseEnergyLimit(float energy)
    {
        this.DefaultEnergyLimit -= energy;
    }
    public void IncreaseEnergyRegeneration(float energy)
    {
        this.EnergyRegeneration += energy;
    }
    public void DecreaseEnergyRegeneration(float energy)
    {
        this.EnergyRegeneration -= energy;
    }
    public bool EnoughEnergy(float energy)
    {
        if (this.CurrentEnergy > energy) return true;
        else return false;
    }
    public void DailyEnergyGain()
    {
        this.CurrentEnergy += this.EnergyRegeneration;
        if (this.CurrentEnergy >= this.EnergyLimit)
        {
            this.CurrentEnergy = this.EnergyLimit;
        }
    }

}
