using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Dictionary<int, GameObject> Buildings = new Dictionary<int, GameObject>();
    public List<GameObject> BuildingsList = new List<GameObject>();
    void Start()
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

            

           Buildings.Add(building.GetComponent<Building>().PlayerObjectID, building);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
