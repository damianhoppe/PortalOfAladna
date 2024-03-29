﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Bonus : DefaultBuilding
{
    
    public float timeBetweenWaves = 10f;
    public float countdown = 5f;
    public float fala = 0;
    public float liczfale = 0;
    public float dni = 0;

    public List<GameObject> Prefabs = new List<GameObject>();
    public int spawnedUnits = 0;

    public List<GameObject> Enemies = new List<GameObject>();
    public List<defaultEnemy> EnemyScripts = new List<defaultEnemy>();
    public bool isBossDead = false;

    EnemyControllerV2 EC;
    DayNightController DNC;

    public Spawner_Bonus()
    {
        this.PlayerObjectID = 1012;
    }

    protected override void Start()
    {
        Prefabs.Add(Resources.Load<GameObject>("EnemyEasy"));

        DNC = GameObject.Find("PlayerDataController").GetComponent<DayNightController>();
        EC = GameObject.Find("EnemyControllerV2").GetComponent<EnemyControllerV2>();
        base.Start();
        this.PlayerObjectID = 1012;
    }

    public void enemySpawn1()
    {
        GameObject tmpEnemy = Instantiate(Prefabs[0]);
        defaultEnemy tmpEnemyScript = tmpEnemy.GetComponent<defaultEnemy>();

        Enemies.Add(tmpEnemy);
        EnemyScripts.Add(tmpEnemyScript);
        EC.RegisterEnemy(tmpEnemy);

        tmpEnemy.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, BuilderBehaviour.defaultZEnemy);
        spawnedUnits++;
    }

    public void Spawn()
    {
        if (DNC.IsDay() == false)
        {
            dni = DNC.GetDayNum();
            if (dni == liczfale)
            {
                if (countdown <= 0)
                {
                    for (int i = 0; i <= 40; i++)
                    {
                        if (fala <= 40 && fala == i && countdown <= 0)
                        {
                            enemySpawn1();
                            countdown = 5;

                            if (fala == 5)
                            {
                                liczfale++;
                            }
                            fala++;
                        }
                    }
                }

                if (fala < 40)
                {
                    countdown -= Time.deltaTime;
                }
            }
        }

    }
    public virtual void ReportDeath(defaultEnemy enemy)
    {
        if (this.EnemyScripts.Contains(enemy))
        {
            int tmp = EnemyScripts.IndexOf(enemy);

            Destroy(Enemies[tmp], 0.2f);

            this.Enemies.RemoveAt(tmp);
            this.EnemyScripts.RemoveAt(tmp);
        }
    }
    protected override void Update()
    {
        base.Update();
        Spawn();
    }
}
