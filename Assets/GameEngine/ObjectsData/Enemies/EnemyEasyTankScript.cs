using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEasyTankScript : defaultEnemy
{
    protected override void Start()
    {


        this.moveSpeed = 0.010f;
        this.movePrecision = 0.2f;


        this.Armor = 4.0f;
        this.Protection = 0.0f;
        this.MaxHitpoints = 200.0f;
        this.CurrentHitpoints = this.MaxHitpoints;
        this.IsTank = true;

        this.PriorityDanger = 0.0f;
        this.PriorityObstacle = -5.0f;
        this.PriorityValue = 0.0f;

        base.Start();
        this.attackValue = 10.0f;

    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }
}
