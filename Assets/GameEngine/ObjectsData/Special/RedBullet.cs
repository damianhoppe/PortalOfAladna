using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour
{
    public defaultTower BulletSource { get; protected set; }
    public defaultEnemy BulletTarget { get; protected set; }
    // Start is called before the first frame update

    public void setSource(defaultTower source)
    {
        this.BulletSource = source;
    }
    public void enemyDestroyed(defaultEnemy enemy)
    {
        if (enemy == this.BulletTarget)
        {

        }
    }
    public void moveToTarget()
    {

    }
    public void checkDistance()
    {

    }
    public void recalculateVector()
    {

    }
    public void hitTarget()
    {

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
