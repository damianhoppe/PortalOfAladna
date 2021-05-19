using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public List<defaultTower> ActiveTowers { get; protected set; } = new List<defaultTower>();

    public void RegisterTower(defaultTower tower)
    {
        this.ActiveTowers.Add(tower);
    }
    public void UnregisterTower(defaultTower tower)
    {
        if (ActiveTowers.Contains(tower)) this.ActiveTowers.Remove(tower);
        else Debug.Log("Error! Unknown tower got delet.");
    }
    public void EnemyKilled(defaultEnemy enemy)
    {
        foreach(defaultTower tower in ActiveTowers)
        {
            tower.reportKill(enemy);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
