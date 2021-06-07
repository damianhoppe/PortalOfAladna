using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesTest : MonoBehaviour
{
    private EconomyController economyController;
    // Start is called before the first frame update
    void Start()
    {
        economyController = GameObject.Find("PlayerDataController").GetComponent<EconomyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        float value = 1000.0f;
        economyController.ResourcesGained(new DataStructures.Cost(value, value, value, value, value, value));
        economyController.AddEnergy(5.0f);
    }
}
