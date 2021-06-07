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

    public Dictionary<string, float> SaveMe()
    {
        Dictionary<string, float> save = new Dictionary<string, float>();

        save.Add("MaxPopulation", MaxPopulation);
        save.Add("CurrentPopulation", CurrentPopulation);
        save.Add("FreePopulation", FreePopulation);
        save.Add("BusyPopulation", BusyPopulation);
        save.Add("Efficiency", Efficiency);

        return save;
    }
    public void LoadMe(Dictionary<string,float> save)
    {
        float data;
        save.TryGetValue("MaxPopulation",out data);
        MaxPopulation = (int)data;
        save.TryGetValue("CurrentPopulation", out data);
        CurrentPopulation = (int)data;
        save.TryGetValue("FreePopulation", out data);
        FreePopulation = (int)data;
        save.TryGetValue("BusyPopulation", out data);
        BusyPopulation = (int)data;
        save.TryGetValue("Efficiency", out data);
        Efficiency = data;

    }

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
    public void EmployHumans(int Workers)
    {
        this.BusyPopulation += Workers;
        this.FreePopulation = this.CurrentPopulation - this.BusyPopulation;
        Debug.Log("Zatrudniam 10 workerow");
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
