using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tmpEnemyController : MonoBehaviour
{
    public List<GameObject> Prefabs=new List<GameObject>();
    public int spawnedUnits = 0;

    public List<GameObject> Enemies = new List<GameObject>();

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
            Enemies.Add(Instantiate(Prefabs[0]));
            Enemies[spawnedUnits].transform.position = new Vector3(0.0f, 5.0f, -0.5f);
            //Enemies.Add(Instantiate(Prefabs[0]).transform.position = new Vector3(0.0f, 0.0f, 0.5f));
            spawnedUnits++;
            Debug.Log("Spawned enemies: " + Enemies.Count.ToString());
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            
            Destroy(Enemies[0],1.0f);
            Enemies.RemoveAt(0);
            spawnedUnits--;
            Debug.Log("Spawned enemies: " + spawnedUnits.ToString());
        }
    }
    Vector3 kursor()
    {
        Vector3 pozycja = Input.mousePosition;
        return pozycja; 
    }
}
