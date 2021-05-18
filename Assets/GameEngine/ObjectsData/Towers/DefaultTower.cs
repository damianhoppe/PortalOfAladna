using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultTower : DefaultBuilding
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.AttackRange = this.GetComponent<CircleCollider2D>();
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
            //collision.gameObject.
        }
    }
    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {

        }
    }
}
