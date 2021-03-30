using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_TMP : Building
{
    float HP;
    [SerializeField]
    GameObject[] enemyArray;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.K))
        {
            foreach(var enemy in enemyArray){
                Instantiate(enemy).transform.position = this.transform.position;
            }
        }
    }


}
