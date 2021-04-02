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

    public bool EnoughPeopleTEST(int ludzie)
    {

        return true;
    }
    public void KillHumans(int Casualities) 
    {
        this.MaxPopulation -= Casualities;
        this.BusyPopulation -= Casualities;
        this.FreePopulation = this.CurrentPopulation - this.BusyPopulation;
    }
}
