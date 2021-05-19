using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitObject : MonoBehaviour
{

    public virtual DayNightController DNC { get; protected set; }
    public virtual GridManager GM { get; protected set; }
    public virtual EconomyController EC { get; protected set; }


    // Start is called before the first frame update
    protected virtual void Start()
    {
        this.GM = GameObject.FindObjectOfType<GridManager>();
        this.DNC = GameObject.Find("PlayerDataController").GetComponent<DayNightController>();
        this.EC = GameObject.Find("PlayerDataController").GetComponent<EconomyController>();
        this.movePrecision = 0.2f;
        this.moveSpeed = 10.0f;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    [SerializeField] 
    public string Name { get; protected set; }
    protected EStructureType Type;
    public virtual Position CurrentPosition { get; protected set; }
    public virtual Position TargetPosition { get; protected set; }

    public Vector3 DestinationPosition { get; protected set; }
    public Vector3 StartPosition { get; protected set; }
    public Vector3 moveVector { get; protected set; }

    //public Position[] trasa = { new Position(2, 0), new Position(2, 2), new Position(0, 2), new Position(0, 0) };
    public Vector2Int[] moveRange = { new Vector2Int(0, 1), new Vector2Int(0, -1), new Vector2Int(1, 0), new Vector2Int(-1, 0) };

    public float movePrecision = 0.2f;

    public float moveSpeed = 10.0f;


    public virtual int UnitObjectID { get; protected set; } = 0;
    public unitObject(EStructureType Type = EStructureType.Unit)
    {

    }

    public Position getCurrentPosition()
    {
        return this.CurrentPosition;
    }
    public Position getTargetPosition()
    {
        return this.TargetPosition;
    }
    public void setCurrentPosition(Position position)
    {
        this.CurrentPosition = position;
    }
    public void setTargetPosition(Position position)
    {
        this.TargetPosition = position;
    }
    public virtual void onClick()
    {
        Debug.Log(this.Name + " - onClick()");
    }
    public EStructureType getType()
    {
        return this.Type;
    }

    public virtual void onCursorOver()
    {
    }


    public virtual void onCursorEnter()
    {
    }

    public virtual void onCursorLeft()
    {
    }
    public virtual void onSpawn()
    {

    }
    public virtual void onDespawn()
    {

    }
    public void setPosition()
    {
        int x = Mathf.RoundToInt(this.transform.position.x);
        int y = Mathf.RoundToInt(this.transform.position.y);
        this.CurrentPosition = new Position(x, y);

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
    public virtual void CheckSurroundings()
    {

    }
    public virtual void setDestination()
    {

    }
    public void calculateVector()
    {
        float proporcja = this.moveSpeed / Vector3.Distance(this.transform.position, this.DestinationPosition);
        float speedX = proporcja * (this.DestinationPosition.x - this.transform.position.x);
        float speedY = proporcja * (this.DestinationPosition.y - this.transform.position.y);
        this.moveVector = new Vector3(speedX, speedY, 0.0f);
    }
}
