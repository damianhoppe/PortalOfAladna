using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Easy_Boss : Building
{
    public float timeBetweenWaves = 10f;
    private float countdown = 2f;

    [SerializeField]
    GameObject[] enemyArray;

    public Spawner_Easy_Boss()
    {
        this.PlayerObjectID = 1010;
    }

    protected override void Start()
    {
        base.Start();
        this.PlayerObjectID = 1010;
    }
    public void Spawn()
    {
        foreach (var enemy in enemyArray)
        {
            Debug.Log("SPAWN");
            Instantiate(enemy).transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, BuilderBehaviour.defaultZEnemy);
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
