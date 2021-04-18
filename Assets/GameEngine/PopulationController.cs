using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int MaxPopulation { get; protected set; }
    public int CurrentPopulation { get; protected set; }
    public int FreePopulation { get; protected set; }
    public int BusyPopulation { get; protected set; }
    public float Efficiency { get; protected set; }

    public bool EnoughPeopleTEST(int ludzie)
    {

        return true;
    }
    public void KillHumans(int Casualities) 
    {
        this.MaxPopulation -= Casualities;
        this.BusyPopulation -= Casualities;
        this.FreePopulation = this.CurrentPopulation - this.BusyPopulation;
        EfficiencyCalculation();
    }
    public void FireHumans(int Workers)
    {
        this.BusyPopulation -= Workers;
        this.FreePopulation = this.CurrentPopulation - this.BusyPopulation;
        EfficiencyCalculation();
    }
    public void IncreasePopulation(int Population)
    {
        this.CurrentPopulation += Population;
        this.FreePopulation = this.CurrentPopulation - this.BusyPopulation;
        EfficiencyCalculation();
    }
    public void DecreasePopulation(int Population)
    {
        this.CurrentPopulation -= Population;
        this.FreePopulation = this.CurrentPopulation - this.BusyPopulation;
        EfficiencyCalculation();
    }
    public void EfficiencyCalculation()
    {
        if (this.FreePopulation < 0)
        {
            this.Efficiency = this.CurrentPopulation / this.BusyPopulation;
        }
        else this.Efficiency = 100.0f;
    }
}
