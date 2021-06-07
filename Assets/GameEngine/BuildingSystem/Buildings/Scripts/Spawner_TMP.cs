using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_TMP : Building
{
    //public float timeBetweenWaves = 10f;
    //private float countdown = 2f;
    //private int waveInWave = 1; //nalicza fale przeciwników w fali
    //private int wave = 2; //nalicza fale przeciwników 

    [SerializeField]
    GameObject[] enemyArray;

    public Spawner_TMP()
    {
        this.PlayerObjectID = 1004;
    }

    protected override void Start()
    {
        base.Start();

        this.PlayerObjectID = 1004;
    }
    public void Spawn()
    {
        foreach (var enemy in enemyArray)
        {
            GameObject enemyObj = Instantiate(enemy);
            enemyObj.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, BuilderBehaviour.defaultZEnemy);
        }
    }
    protected override void Update()
    {
        base.Update();
/*        if (countdown <= 0f && waveInWave <= wave)         //freezuje więc zakomentowane
        {
            Spawn();
            countdown = timeBetweenWaves;
            waveInWave++;
        }
        countdown -= Time.deltaTime;

        if (wave == waveInWave)
        {
            waveInWave = 0;
            wave++;
        }
*/
    }

}