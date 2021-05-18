using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultTower : DefaultBuilding

{
    public CircleCollider2D AttackRange;
    public List<defaultEnemy> DetectedEnemies = new List<defaultEnemy>();

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.AttackRange = this.GetComponent<CircleCollider2D>();
        AttackRange.radius = 3.0f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            defaultEnemy detected = collision.gameObject.GetComponent<defaultEnemy>();
            detected.HelloWorld();
            //if()
            //this.DetectedEnemies.Add((defaultEnemy)collision.gameObject);
        }
    }
    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Bai bai.");
        }
    }
}
