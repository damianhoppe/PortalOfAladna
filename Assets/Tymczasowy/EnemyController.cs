using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    AIPath ai;
    GameObject portal;
    AIDestinationSetter destination;
    [SerializeField]
    GameObject[] Targets;
    void Start()
    {
        destination = GetComponent<AIDestinationSetter>();
        portal = GameObject.FindWithTag("Portal");
        ai = this.GetComponent<AIPath>();
        ai.canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ai.canMove = true;
            destination.target = TargetSelection(Targets);
            DayNightController.ScanPathfinding();
        }
    }

    Transform TargetSelection(GameObject[] Targets)
    {

        /*List<float> aggro = new List<float>();
        
        int min=0;
        for (int i=0;i<Targets.Length;i++)
        {
            destination.target = TargetSelection(Targets);
            aggro.Add(ai.remainingDistance - Targets[i].GetComponent<Building>().Danger);
            Debug.Log("Danger: " + Targets[i].GetComponent<Building>().Danger);
            min = Array.IndexOf(aggro.ToArray(),aggro.Min());
            
        }

                return Targets[min].transform;*/
        ;
        return GameObject.Find(Targets[0].name).transform;
    }
}
