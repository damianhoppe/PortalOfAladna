using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningController : MonoBehaviour
{
    List<DefaultMine> RegisteredMines = new List<DefaultMine>();
    public virtual EconomyController EC { get; protected set; }
    public virtual DayNightController DNC { get; protected set; }

    public DataStructures.Cost AccumulatedResources { get; protected set; } = new DataStructures.Cost();

    // Start is called before the first frame update
    void Start()
    {
        EC = GameObject.Find("PlayerDataController").GetComponent<EconomyController>();
        DNC = GameObject.Find("PlayerDataController").GetComponent<DayNightController>();
        if (DNC.ConnectMiningController())
        {

        }
        else
        {
            Debug.Log("FATAL ERROR: DNC<->MC CONNECTION PROBLEM!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool RegisterMine(DefaultMine Mine)
    {
        if (this.RegisteredMines.Contains(Mine))
        {
            return false;
        }
        else
        {
            this.RegisteredMines.Add(Mine);
            return true;
        }
    }
    public bool UnregisterMine(DefaultMine Mine)
    {
        if (this.RegisteredMines.Contains(Mine))
        {
            this.RegisteredMines.Remove(Mine);
            return true;
        }
        else
        {
            return false;
        }
    }
    public void MineDay()
    {
        foreach(DefaultMine mine in RegisteredMines)
        {
            mine.MineResources();
        }
    }
    public void MineNight()
    {
        foreach (DefaultMine mine in RegisteredMines)
        {
            if (mine.ActiveAtNight)
            {
                mine.MineResources();
            }
        }
    }
    public void DeliverResources()
    {
        this.AccumulatedResources = new DataStructures.Cost();
        foreach (DefaultMine mine in RegisteredMines)
        {
            AccumulatedResources += mine.DeliverResources();
        }
        EC.ResourcesGained(this.AccumulatedResources);
        this.AccumulatedResources = new DataStructures.Cost();
    }
}
