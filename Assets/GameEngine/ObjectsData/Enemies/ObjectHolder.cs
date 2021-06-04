using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class ObjectHolder : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Dictionary<int, GameObject> Buildings = new Dictionary<int, GameObject>();
    public List<GameObject> BuildingsList = new List<GameObject>();
    void Awake()
    {
        BuilderBehaviour BH = FindObjectOfType<BuilderBehaviour>();

        var prefabs = Resources.LoadAll("Prefabs");
        foreach (Object item in prefabs)
        {
            GameObject obj = item as GameObject;
            BuildingsList.Add(obj);
        }
        foreach (var building in BuildingsList)
        {

            try
            {
                //Debug.Log(building.GetComponent<Structure>().PlayerObjectID + " " + building.GetComponent<Structure>().ObjectName);
                Buildings.Add(building.GetComponent<Structure>().PlayerObjectID, building);
            }
            catch(System.ArgumentException e)
            {
                Debug.Log("ERROR:"+building.GetComponent<Structure>().PlayerObjectID+" "+ building.GetComponent<Structure>().ObjectName+":RORRE");

            }
           //Buildings.Add(building.GetComponent<Structure>().PlayerObjectID, building);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
