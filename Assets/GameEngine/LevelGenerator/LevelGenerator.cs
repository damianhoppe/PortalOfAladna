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
        this.Spawn = !MainMenu.newGame;
    }


    void Update()
    {
        if (Spawn == false)
        {
            WhatToSpawn = Random.Range(1, 3);
            Debug.Log(WhatToSpawn);

            switch (WhatToSpawn)
            {
                case 1:
                    Instantiate(prefab1, transform.position, Quaternion.identity);
                    Spawn = true;
                    break;
                case 2:
                    Instantiate(prefab2, transform.position, Quaternion.identity);
                    Spawn = true;
                    break;
            }
        }
    }
}