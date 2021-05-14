using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biednaPierdolonaPiechota : defaultEnemy
{
    [SerializeField]

    public Vector3 DestinationPosition { get; protected set; }
    public Vector3 StartPosition { get; protected set; }
    public Vector3 moveVector { get; protected set; }

    public Position[] trasa = { new Position(2, 0), new Position(2, 2), new Position(0, 2), new Position(0, 0) };
    public int elementTrasy = 0;
    public float movePrecision = 0.2f;

    public float moveSpeed = 10.0f;
    protected override void Start()
    {
        this.moveSpeed = 0.0025f;
        setDestination();
        setPosition();
        calculateVector();
        base.Start();

    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        this.transform.position += moveVector;
        if (Vector3.Distance(this.transform.position, this.DestinationPosition) < movePrecision)
        {
            setDestination();
            setPosition();
            calculateVector();
        }
    }
    public void setPosition()
    {
        int x = Mathf.RoundToInt(this.transform.position.x);
        int y = Mathf.RoundToInt(this.transform.position.y);
        this.CurrentPosition = new Position(x, y);
        elementTrasy++;
        if (elementTrasy == 4) elementTrasy = 0;
    }
    public void setDestination()
    {
        Position target = trasa[elementTrasy];
        Vector3 punkt_docelowy = new Vector3((float)target.x, (float)target.y, -0.5f);
        punkt_docelowy.x += Random.Range(-movePrecision, movePrecision);
        punkt_docelowy.y += Random.Range(-movePrecision, movePrecision);
        this.DestinationPosition = punkt_docelowy;
    }
    public void calculateVector()
    {
        float proporcja = this.moveSpeed / Vector3.Distance(this.transform.position, this.DestinationPosition);
        float speedX = proporcja * (this.DestinationPosition.x - this.transform.position.x);
        float speedY = proporcja * (this.DestinationPosition.y - this.transform.position.y);
        this.moveVector = new Vector3(speedX, speedY, 0.0f);

    }
    public void NextDestination()
    {

    }
    public void Arrived()
    {

    }
}
