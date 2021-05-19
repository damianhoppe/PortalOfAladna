using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBasicTower : defaultTower
{
    //CircleCollider2D AttackRange;
    

    // Start is called before the first frame update
    protected override void Start()
    {

        base.Start();

        this.AttackRange.radius = 3.0f;
        this.TowerBulletDamage = 10.0f;
        this.TowerBulletSpeed = 0.0125f;
        this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletSize = 1.0f;

        this.canAttack = true;

        this.attackSpeed = 200;
        this.attackReady = 0;

}

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    WoodenBasicTower()
    {

    }
}
