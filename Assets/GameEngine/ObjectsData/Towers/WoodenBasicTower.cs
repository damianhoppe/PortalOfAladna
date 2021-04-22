using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBasicTower : DefaultBuilding
{
    CircleCollider2D AttackRange;
    // Start is called before the first frame update
    protected override void Start()
    {
        this.AttackRange = this.GetComponent<CircleCollider2D>();
        base.Start();
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    WoodenBasicTower()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {

        }
    }
}
