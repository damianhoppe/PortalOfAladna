using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Dictionary<string, GameObject> Buildings = new Dictionary<string, GameObject>();
    [SerializeField]
    List<GameObject> BuildingsList = new List<GameObject>();
    void Start()
    {
        BuilderBehaviour BH = FindObjectOfType<BuilderBehaviour>();
        
        foreach(var building in BuildingsList)
        {
            Debug.Log(building);
            Buildings.Add(building.GetComponent<Building>().name, building);

        }
        foreach (string key in Buildings.Keys)
        {
            Debug.Log(key);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
