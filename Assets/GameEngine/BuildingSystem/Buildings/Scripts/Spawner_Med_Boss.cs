using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Med_Boss : Building
{
    public float timeBetweenWaves = 10f;
    private float countdown = 2f;

    [SerializeField]
    GameObject[] enemyArray;

    public Spawner_Med_Boss()
    {
        this.PlayerObjectID = 1003;
    }

    protected override void Start()
    {
        base.Start();
        this.PlayerObjectID = 1003;
    }
    public void Spawn()
    {
        foreach (var enemy in enemyArray)
        {
            Debug.Log("SPAWN");
            GameObject enemyObj = Instantiate(enemy);
            enemyObj.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, BuilderBehaviour.defaultZEnemy);
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
