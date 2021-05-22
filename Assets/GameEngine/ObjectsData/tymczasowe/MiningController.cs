using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningController : MonoBehaviour
{
    List<DefaultMine> RegisteredMines = new List<DefaultMine>();
    public virtual EconomyController EC { get; protected set; }
    public virtual DayNightController DNC { get; protected set; }

    // Start is called before the first frame update
    void Start()
    {
        EC = GameObject.Find("PlayerDataController").GetComponent<EconomyController>();
        DNC = GameObject.Find("PlayerDataController").GetComponent<DayNightController>();
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
}
