using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public DataStructures.Cost PlayerResources = new DataStructures.Cost();

    public bool CanAffordTEST(DataStructures.Cost koszt)
    {
        
        return true;
    }
    public bool CanAfford(DataStructures.Cost koszt)
    {
        if (koszt <= PlayerResources) return true;
        else return false;
    }
    public void ResourcesSpent(DataStructures.Cost koszt)
    {
        PlayerResources -= koszt;
    }
    public void ResourcesGained (DataStructure.Cost zysk)
    {
        PlayerResources -= zysk;
    }
}
