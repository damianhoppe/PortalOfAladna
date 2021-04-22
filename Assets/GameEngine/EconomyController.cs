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
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public bool CanAffordTEST(DataStructures.Cost koszt)
    {
        
        return true;
    }
    public bool CanAfford(DataStructures.Cost koszt)
    {
        if (koszt.Gold > PlayerResources.Gold) return false;
        else if (koszt.Wood > PlayerResources.Wood) return false;
        else if (koszt.Stone > PlayerResources.Stone) return false;
        else if (koszt.Metal > PlayerResources.Metal) return false;
        else if (koszt.Crystals > PlayerResources.Crystals) return false;
        else if (koszt.Humans > PlayerResources.Humans) return false;
        else return true;
    }
    public void ResourcesSpent(DataStructures.Cost koszt)
    {
        this.PlayerResources -= koszt;
    }
    public void ResourcesGained (DataStructures.Cost zysk)
    {
        this.PlayerResources -= zysk;
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
}
