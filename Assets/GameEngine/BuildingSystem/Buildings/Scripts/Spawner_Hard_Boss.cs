﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Hard_Boss : Building
{
    public float timeBetweenWaves = 10f;
    private float countdown = 2f;

    [SerializeField]
    GameObject[] enemyArray;

    public Spawner_Hard_Boss()
    {
        this.PlayerObjectID = 1006;
    }

    protected override void Start()
    {
        base.Start();
        this.PlayerObjectID = 1006;
    }
    public void Spawn()
    {
        foreach (var enemy in enemyArray)
        {
            Instantiate(enemy).transform.position = this.transform.position;
        }
    }
    protected override void Update()
    {
        base.Update();
        if (countdown <= 0f)
        {
            Spawn();
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

    }
}
