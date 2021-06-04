using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMediumScript : defaultEnemy
{
    protected override void Start()
    {


        this.moveSpeed = 0.010f;
        this.movePrecision = 0.2f;


        this.Armor = 20.0f;
        this.Protection = 0.0f;
        this.MaxHitpoints = 1300.0f;
        this.CurrentHitpoints = this.MaxHitpoints;
        this.IsTank = false;

        this.PriorityDanger = 0.0f;
        this.PriorityObstacle = -5.0f;
        this.PriorityValue = 0.0f;

        base.Start();
        this.attackValue = 60.0f;

    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }
}
