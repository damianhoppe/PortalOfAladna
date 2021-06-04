using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Easy_Med : DefaultBuilding
{

    public float timeBetweenWaves = 10f;
    public float countdown = 5f;
    public float fala = 1;

    public List<GameObject> Prefabs = new List<GameObject>();
    public int spawnedUnits = 0;

    public List<GameObject> Enemies = new List<GameObject>();
    public List<defaultEnemy> EnemyScripts = new List<defaultEnemy>();
    public bool isBossDead = false;


    DayNightController DNC;
    protected override void Start()
    {
        Prefabs.Add(Resources.Load<GameObject>("EnemyEasy"));
        Prefabs.Add(Resources.Load<GameObject>("EnemyEasyTank"));
        Prefabs.Add(Resources.Load<GameObject>("BossEasy"));

        DNC = GameObject.Find("PlayerDataController").GetComponent<DayNightController>();
        base.Start();
    }
    public void enemySpawn1()
    {
        GameObject tmpEnemy = Instantiate(Prefabs[0]);
        defaultEnemy tmpEnemyScript = tmpEnemy.GetComponent<defaultEnemy>();

        Enemies.Add(tmpEnemy);
        EnemyScripts.Add(tmpEnemyScript);

        Enemies[spawnedUnits].transform.position = this.transform.position;
        spawnedUnits++;
    }

    public void enemySpawn2()
    {
        GameObject tmpEnemy = Instantiate(Prefabs[1]);
        defaultEnemy tmpEnemyScript = tmpEnemy.GetComponent<defaultEnemy>();

        Enemies.Add(tmpEnemy);
        EnemyScripts.Add(tmpEnemyScript);

        Enemies[spawnedUnits].transform.position = this.transform.position;
        spawnedUnits++;
    }
    public void enemySpawn3()
    {
        GameObject tmpEnemy = Instantiate(Prefabs[2]);
        defaultEnemy tmpEnemyScript = tmpEnemy.GetComponent<defaultEnemy>();

        Enemies.Add(tmpEnemy);
        EnemyScripts.Add(tmpEnemyScript);

        Enemies[spawnedUnits].transform.position = this.transform.position;
        spawnedUnits++;
    }
    public void Spawn()
    {
        if (DNC.IsDay() == false)
        {
            if (countdown <= 0)
            {
                for (int i = 0; i <= 25; i++)
                {
                    if (fala <= 5 && fala == i && countdown <= 0)
                    {
                        enemySpawn1();
                        fala++;
                        countdown = 15;
                    }
                    else if (fala <= 8 && fala == i && countdown <= 0)
                    {
                        enemySpawn1();
                        fala++;
                        countdown = 1;
                    }
                    else if (fala <= 12 && fala == i && countdown <= 0)
                    {
                        enemySpawn2();
                        fala++;
                        countdown = 10;
                    }
                    else if (fala <= 23 && fala == i && countdown <= 0)
                    {
                        enemySpawn1();
                        fala++;
                        countdown = 8;
                    }
                    else if (fala <= 25 && fala == i && countdown <= 0)
                    {
                        enemySpawn3();
                        fala++;
                        countdown = 1;
                    }
                    countdown -= Time.deltaTime;
                }


            }
            if (fala < 25)
            {
                countdown -= Time.deltaTime;
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
