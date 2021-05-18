using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biednaPierdolonaPiechota : defaultEnemy
{
    //[SerializeField]

    public Vector3 DestinationPosition { get; protected set; }
    public Vector3 StartPosition { get; protected set; }
    public Vector3 moveVector { get; protected set; }

    public Position[] trasa = { new Position(2, 0), new Position(2, 2), new Position(0, 2), new Position(0, 0) };
    public Vector2Int[] moveRange = { new Vector2Int(0, 1), new Vector2Int(0, -1), new Vector2Int(1, 0), new Vector2Int(-1, 0) };
    public Vector2Int[] attackRange = { new Vector2Int(0, 1), new Vector2Int(0, -1), new Vector2Int(1, 0), new Vector2Int(-1, 0) };

    public List<DefaultBuilding> Surroundings = new List<DefaultBuilding>();

    public DefaultBuilding AttackTarget { get; protected set; }

    public float[] SurroundingValues { get; protected set; }
    public bool[] CanGo { get; protected set; }
    public bool IsMoving { get; protected set; } = true;
    public bool IsAttacking { get; protected set; } = false;


    public int elementTrasy = 0;
    public float movePrecision = 0.2f;

    public float moveSpeed = 10.0f;
    public int attackSpeed { get; protected set; } = 200;
    public int attackReady { get; protected set; } = 0;
    public int attackPercent { get; protected set; }



    protected override void Start()
    {
        base.Start();

        this.moveSpeed = 0.0025f;
        this.PriorityDanger = 0.0f;
        this.PriorityObstacle = 20.0f;
        this.PriorityValue = 20.0f;

        SurroundingValues = new float[moveRange.Length];
        CanGo = new bool[moveRange.Length];

        setPosition();
        CheckSurroundings();
        setDestination();
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (IsMoving)
        {
            this.Move();
        }
        if (IsAttacking)
        {
            this.Attack();
        }
    }
    public bool Move()
    {
        this.transform.position += moveVector;
        if (Vector3.Distance(this.transform.position, this.DestinationPosition) < movePrecision)
        {
            setPosition();
            CheckSurroundings();
            setDestination();
            return true;
        }
        else return false;
    }
    public bool Attack()
    {
        this.attackReady++;
        this.attackPercent = this.attackReady / this.attackSpeed;
        if (this.attackReady >= this.attackSpeed)
        {
            this.transform.localScale = new Vector3(1.0f,1.0f,1.0f);
            this.attackReady -= this.attackSpeed;
            AttackTarget.OnHit(100.0f);
            //Debug.Log("Job z paticku w " + AttackTarget);
            if (AttackTarget.IsDead)
            {
                //Destroy(AttackTarget);
                IsMoving = true;
                IsAttacking = false;
            }
            return true;
        }
        else
        {
            this.transform.localScale = new Vector3(
                1.0f + (0.5f * this.attackPercent),
                1.0f + (0.5f * this.attackPercent),
                1.0f + (0.5f * this.attackPercent));
        }

        return false;
    }
    public void setPosition()
    {
        int x = Mathf.RoundToInt(this.transform.position.x);
        int y = Mathf.RoundToInt(this.transform.position.y);
        this.CurrentPosition = new Position(x, y);
        
    }
    public void setDestination()
    {

        float tmpMin=0.0f;
        int tmpIndex = -1;
        int tmpRand = -1;
        
        for (int i = 0; i < SurroundingValues.Length; i++)
        {
            tmpRand = Random.Range(0, 2);
            if (i == 0) { tmpMin = SurroundingValues[i];tmpIndex = i; continue; }
            if (SurroundingValues[i] < tmpMin) tmpIndex = i; tmpMin = SurroundingValues[i];
            if (SurroundingValues[i] == tmpMin)
            {
                if (tmpRand == 1) tmpIndex = i; tmpMin = SurroundingValues[i];
            }
        }

        //Debug.Log("Going to:" + (CurrentPosition + moveRange[tmpIndex]));
        //Debug.Log("Trace value:" + SurroundingValues[tmpIndex]);
        //Debug.Log("Can go there:" + CanGo[tmpIndex]);

        if (CanGo[tmpIndex])
        {
            Position target = CurrentPosition + moveRange[tmpIndex];
            Vector3 punkt_docelowy = new Vector3((float)target.x, (float)target.y, -0.5f);
            punkt_docelowy.x += Random.Range(-movePrecision, movePrecision);
            punkt_docelowy.y += Random.Range(-movePrecision, movePrecision);
            this.DestinationPosition = punkt_docelowy;

            calculateVector();
        }
        else
        {
            Position target = CurrentPosition + moveRange[tmpIndex];
            Vector3 punkt_docelowy = new Vector3((float)target.x, (float)target.y, -0.5f);
            punkt_docelowy.x += Random.Range(-movePrecision, movePrecision);
            punkt_docelowy.y += Random.Range(-movePrecision, movePrecision);
            this.DestinationPosition = punkt_docelowy;
            //Debug.Log("Target detected");
            calculateVector();

            AttackTarget = (DefaultBuilding)GM.getStructure(target);
            IsMoving = false;
            IsAttacking = true;
        }
    }
    public void calculateVector()
    {
        float proporcja = this.moveSpeed / Vector3.Distance(this.transform.position, this.DestinationPosition);
        float speedX = proporcja * (this.DestinationPosition.x - this.transform.position.x);
        float speedY = proporcja * (this.DestinationPosition.y - this.transform.position.y);
        this.moveVector = new Vector3(speedX, speedY, 0.0f);
    }
    public void CheckSurroundings()
    {
        int X = this.CurrentPosition.x;
        int Y = this.CurrentPosition.y;
        Surroundings = new List<DefaultBuilding>();

        for(int i = 0; i < moveRange.Length; i++)
        {
            if (GM.getStructure(CurrentPosition+moveRange[i]) == null)
            {
                SurroundingValues[i] = Mathf.Abs((CurrentPosition + moveRange[i]).x) + Mathf.Abs((CurrentPosition + moveRange[i]).y);
                CanGo[i] = true;
            }
            else
            {
                Structure tmpStruct = GM.getStructure(CurrentPosition + moveRange[i]);
                if (tmpStruct.IsPlayerBuilding)
                {
                    DefaultBuilding tmpBuilding = (DefaultBuilding)tmpStruct;
                    Surroundings.Add(tmpBuilding);
                    SurroundingValues[i] = Mathf.Abs((CurrentPosition + moveRange[i]).x) + Mathf.Abs((CurrentPosition + moveRange[i]).y);
                    SurroundingValues[i] += tmpBuilding.PositionDanger * this.PriorityDanger;
                    SurroundingValues[i] += tmpBuilding.PositionValue * this.PriorityValue;
                    SurroundingValues[i] += tmpBuilding.PositionObstacle * this.PriorityObstacle;
                    CanGo[i] = false;
                }
            }
        }

    }
}
