using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //this.PlayerResources = LOAD POSIADANE SUROWCE xD
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public DataStructures.Cost PlayerResources { get; protected set; }// = new DataStructures.Cost();

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
        PlayerResources -= koszt;
    }
    public void ResourcesGained (DataStructures.Cost zysk)
    {
        PlayerResources -= zysk;
    }
}
