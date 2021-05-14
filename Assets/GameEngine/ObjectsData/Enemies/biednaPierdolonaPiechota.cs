using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biednaPierdolonaPiechota : defaultEnemy
{
    [SerializeField]
    public Vector3 MoveSpeed { get; protected set; }
    public Vector3 DestinationPosition { get; protected set; }
    public Vector3 StartPosition { get; protected set; }
    public bool forward = true;
    public bool back = false;
    protected override void Start()
    {
        StartPosition = this.transform.position;
        DestinationPosition = this.transform.position+new Vector3(1.0f,0.0f,0.0f);
        MoveSpeed= new Vector3(0.01f, 0.0f, 0.0f);
        base.Start();
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (forward)
        {
            this.transform.position += MoveSpeed;
            if (Vector3.Distance(this.transform.position, this.DestinationPosition) < 0.05f) forward = false;
        }
        else
        {
            this.transform.position -= MoveSpeed;
            if (Vector3.Distance(this.transform.position, this.StartPosition) < 0.05f) forward = true;
        }
        
    }
    public void NextDestination()
    {

    }
    public void Arrived()
    {

    }
}
