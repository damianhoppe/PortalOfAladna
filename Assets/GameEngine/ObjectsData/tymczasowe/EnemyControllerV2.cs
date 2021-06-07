using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerV2 : MonoBehaviour
{
    public List<GameObject> Prefabs=new List<GameObject>();
    public int spawnedUnits = 0;

    public List<GameObject> Enemies = new List<GameObject>();
    public List<defaultEnemy> EnemyScripts = new List<defaultEnemy>();
    public bool isBossDead=false;

    // Start is called before the first frame update
    void Start()
    {
        Prefabs.Add(Resources.Load<GameObject>("Przeciwnik"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            GameObject tmpEnemy = Instantiate(Prefabs[0]);
            defaultEnemy tmpEnemyScript = tmpEnemy.GetComponent<defaultEnemy>();

            Enemies.Add(tmpEnemy);
            EnemyScripts.Add(tmpEnemyScript);

            Enemies[spawnedUnits].transform.position = new Vector3(5.0f, 0.0f, -0.5f);
            //Enemies.Add(Instantiate(Prefabs[0]).transform.position = new Vector3(0.0f, 0.0f, 0.5f));
            spawnedUnits++;
            Debug.Log("Spawned enemies: " + Enemies.Count.ToString());
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            
            Destroy(Enemies[0],1.0f);
            Enemies.RemoveAt(0);
            EnemyScripts.RemoveAt(0);
            spawnedUnits--;
            Debug.Log("Spawned enemies: " + spawnedUnits.ToString());
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
    Vector3 kursor()
    {
        Vector3 pozycja = Input.mousePosition;
        return pozycja; 
    }
    public virtual void RegisterEnemy(GameObject enemy)
    {
        GameObject tmpEnemy = enemy;
        defaultEnemy tmpEnemyScript = tmpEnemy.GetComponent<defaultEnemy>();

        Enemies.Add(tmpEnemy);
        EnemyScripts.Add(tmpEnemyScript);
    }
}
