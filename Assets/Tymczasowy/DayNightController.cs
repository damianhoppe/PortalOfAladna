using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePathfinding()
    {
        AstarPath.active.Scan(); //temp
    }

    public static void ScanPathfinding()
    {
        AstarPath.active.Scan();
    }
    
    void BlockBuilding()
    {

    }
    void SpawnMonster()
    {

    }
    public void BuildingDestroyed()
    {
        UpdatePathfinding();
    }
    void NightTime()
    {
        ScanPathfinding();
        BlockBuilding();
        SpawnMonster();
    }
}
