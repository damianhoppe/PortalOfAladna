using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHardTankScript : defaultEnemy
{
    protected override void Start()
    {


        this.moveSpeed = 0.015f;
        this.movePrecision = 0.2f;


        this.Armor = 10.0f;
        this.Protection = 0.0f;
        this.MaxHitpoints = 600.0f;
        this.CurrentHitpoints = this.MaxHitpoints;
        this.IsTank = true;

        this.PriorityDanger = 0.0f;
        this.PriorityObstacle = -5.0f;
        this.PriorityValue = 0.0f;

        base.Start();
        this.attackValue = 30.0f;

    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }
}
