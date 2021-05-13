using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Dictionary<int, GameObject> Buildings = new Dictionary<int, GameObject>();
    [SerializeField]
    List<GameObject> BuildingsList = new List<GameObject>();
    void Start()
    {
        BuilderBehaviour BH = FindObjectOfType<BuilderBehaviour>();
        
        foreach(var building in BuildingsList)
        {
            Debug.Log(building);
            Buildings.Add(building.GetComponent<Building>().PlayerObjectID, building);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
