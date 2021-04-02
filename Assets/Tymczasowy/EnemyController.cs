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
    [SerializeField]
    GameObject[] Targets;
    List<GameObject> TargetsLocations = new List<GameObject>();
    Rigidbody2D rb2D;
    float speed;
    float time = 0;
    void Start()
    {
        foreach(var Target in Targets)
        {
            TargetsLocations.Add(GameObject.Find(Target.name));
        }
        ai = this.GetComponent<AIPath>();
        //ai.canMove = false;
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ai.canMove = true;
            DayNightController.ScanPathfinding();
        }

    }

    private void LateUpdate()
    {
        if (TargetsLocations.Count() != 0 || TargetsLocations != null)
        {
            TargetSelection(TargetsLocations);
        }
    }
    void TargetSelection(List<GameObject> Targets)
    {

        List<float> aggro = new List<float>();
        
        int min=0;
        for (int i=0;i<Targets.Count();i++)
        {
            GetComponent<AIPath>().destination = Targets[i].transform.position;
            aggro.Add(ai.remainingDistance - Targets[i].GetComponent<Building>().Danger);
            Debug.Log("Danger: " + Targets[i].GetComponent<Building>().Danger+" Target: "+Targets[i].name);
            min = Array.IndexOf(aggro.ToArray(),aggro.Min());
            
        }
        Debug.Log(Targets[min].transform.position);
        GetComponent<AIPath>().destination = Targets[min].transform.position;
        
    }
}
