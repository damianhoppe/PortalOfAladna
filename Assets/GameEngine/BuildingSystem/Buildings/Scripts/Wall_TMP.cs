using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_TMP : Building
{
    float HP;
    DayNightController DNS;
    protected override void Start()
    {
        base.Start();
        DNS = GameObject.Find("DayNightSystem").GetComponent<DayNightController>();
        HP = 100;
    }

    protected override void Update()
    {
        base.Update();
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(GetDamage(5));
        
        }
    }

    IEnumerator GetDamage(float damage)
    {

        HP = HP - damage;
        if (HP < 0)
        {
            Destroy(this.gameObject);
            DNS.BuildingDestroyed();
        }
        yield return new WaitForSeconds(5);

    }
}
