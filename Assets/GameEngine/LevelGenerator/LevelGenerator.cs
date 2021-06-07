using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    bool Spawn = false;
    public GameObject prefab1, prefab2, prefab3;
    int WhatToSpawn;
    void Start()
    {
        if (MainMenu.newGame)
        {
            Instantiate(prefab1, transform.position, Quaternion.identity);
        }
        Instantiate(prefab2, transform.position, Quaternion.identity);
    }


    void Update()
    {
        if (Spawn == false)
        {
            
            Spawn = true;
            /*
            Instantiate(prefab1, transform.position, Quaternion.identity);
            WhatToSpawn = Random.Range(1, 3);
            Debug.Log(WhatToSpawn);

            switch (1)
            {
                case 1:
                    Instantiate(prefab1, transform.position, Quaternion.identity);
                    Spawn = true;
                    break;
                case 2:
                    Instantiate(prefab2, transform.position, Quaternion.identity);
                    Spawn = true;
                    break;
            }*/
        }
    }
}