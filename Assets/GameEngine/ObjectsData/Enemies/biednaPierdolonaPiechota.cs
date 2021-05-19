using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biednaPierdolonaPiechota : defaultEnemy
{
    //[SerializeField]


    protected override void Start()
    {
        this.moveSpeed = 0.0025f;
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
