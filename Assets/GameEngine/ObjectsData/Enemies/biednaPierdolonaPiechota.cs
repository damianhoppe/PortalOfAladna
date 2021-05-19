using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biednaPierdolonaPiechota : defaultEnemy
{
    //[SerializeField]


    protected override void Start()
    {
        this.moveSpeed = 0.0025f;
        this.movePrecision = 0.2f;
        

        this.Armor = 1.0f;
        this.Protection = 0.0f;
        this.MaxHitpoints = 100.0f;
        this.CurrentHitpoints = this.MaxHitpoints;
        this.IsTank = false;
        this.attackValue = 10.0f;

        this.PriorityDanger = 0.0f;
        this.PriorityObstacle = 20.0f;
        this.PriorityValue = 0.0f;

        base.Start();

    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }

    

    
    
    
}
