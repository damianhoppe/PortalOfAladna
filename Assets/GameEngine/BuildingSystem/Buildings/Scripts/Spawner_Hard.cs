using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Hard : DefaultBuilding
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
    protected override void Start()
    {
        Prefabs.Add(Resources.Load<GameObject>("EnemyMedium"));
        Prefabs.Add(Resources.Load<GameObject>("EnemyMediumTank"));
        Prefabs.Add(Resources.Load<GameObject>("EnemyHard"));
        Prefabs.Add(Resources.Load<GameObject>("EnemyHardTank"));
        Prefabs.Add(Resources.Load<GameObject>("BossHard"));

        DNC = GameObject.Find("PlayerDataController").GetComponent<DayNightController>();
        EC = GameObject.Find("EnemyControllerV2").GetComponent<EnemyControllerV2>();
        base.Start();
    }
    public void enemySpawn1()
    {
        GameObject tmpEnemy = Instantiate(Prefabs[0]);
        defaultEnemy tmpEnemyScript = tmpEnemy.GetComponent<defaultEnemy>();

        Enemies.Add(tmpEnemy);
        EnemyScripts.Add(tmpEnemyScript);
        EC.RegisterEnemy(tmpEnemy);

        Enemies[spawnedUnits].transform.position = this.transform.position;
        spawnedUnits++;
    }

    public void enemySpawn2()
    {
        GameObject tmpEnemy = Instantiate(Prefabs[1]);
        defaultEnemy tmpEnemyScript = tmpEnemy.GetComponent<defaultEnemy>();

        Enemies.Add(tmpEnemy);
        EnemyScripts.Add(tmpEnemyScript);
        EC.RegisterEnemy(tmpEnemy);

        Enemies[spawnedUnits].transform.position = this.transform.position;
        spawnedUnits++;
    }
    public void enemySpawn3()
    {
        GameObject tmpEnemy = Instantiate(Prefabs[2]);
        defaultEnemy tmpEnemyScript = tmpEnemy.GetComponent<defaultEnemy>();

        Enemies.Add(tmpEnemy);
        EnemyScripts.Add(tmpEnemyScript);
        EC.RegisterEnemy(tmpEnemy);

        Enemies[spawnedUnits].transform.position = this.transform.position;
        spawnedUnits++;
    }
    public void enemySpawn4()
    {
        GameObject tmpEnemy = Instantiate(Prefabs[3]);
        defaultEnemy tmpEnemyScript = tmpEnemy.GetComponent<defaultEnemy>();

        Enemies.Add(tmpEnemy);
        EnemyScripts.Add(tmpEnemyScript);
        EC.RegisterEnemy(tmpEnemy);

        Enemies[spawnedUnits].transform.position = this.transform.position;
        spawnedUnits++;
    }
    public void enemySpawn5()
    {
        GameObject tmpEnemy = Instantiate(Prefabs[4]);
        defaultEnemy tmpEnemyScript = tmpEnemy.GetComponent<defaultEnemy>();

        Enemies.Add(tmpEnemy);
        EnemyScripts.Add(tmpEnemyScript);
        EC.RegisterEnemy(tmpEnemy);

        Enemies[spawnedUnits].transform.position = this.transform.position;
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
                    for (int i = 0; i <= 25; i++)
                    {
                        if (fala <= 5 && fala == i && countdown <= 0)
                        {
                            enemySpawn1();
                            countdown = 5;

                            if (fala == 5)
                            {
                                liczfale++;
                            }
                            fala++;
                        }
                        else if (fala <= 8 && fala == i && countdown <= 0)
                        {
                            enemySpawn4();

                            countdown = 1;
                            if (fala == 8)
                            {
                                liczfale++;
                            }
                            fala++;
                        }
                        else if (fala <= 12 && fala == i && countdown <= 0)
                        {
                            enemySpawn1();
                            countdown = 5;
                            if (fala == 12)
                            {
                                liczfale++;
                            }
                            fala++;
                        }
                        else if (fala <= 19 && fala == i && countdown <= 0)
                        {
                            enemySpawn1();
                            countdown = 5;
                            if (fala == 19)
                            {
                                liczfale++;
                            }
                            fala++;
                        }
                        else if (fala <= 23 && fala == i && countdown <= 0)
                        {
                            enemySpawn3();
                            countdown = 5;
                            if (fala == 23)
                            {
                                liczfale++;
                            }
                            fala++;
                        }
                        else if (fala <= 25 && fala == i && countdown <= 0)
                        {
                            enemySpawn5();
                            countdown = 1;
                            if (fala == 25)
                            {
                                liczfale++;
                            }
                            fala++;
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

