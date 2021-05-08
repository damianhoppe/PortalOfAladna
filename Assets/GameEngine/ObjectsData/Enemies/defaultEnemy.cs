using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindObjectOfType<GridManager>();
        DNC = GameObject.Find("PlayerDataController").GetComponent<DayNightController>();
        EC = GameObject.Find("PlayerDataController").GetComponent<EconomyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [SerializeField] string Name;
    protected EStructureType Type;
    Position CurrentPosition;
    Position TargetPosition;

    public virtual DayNightController DNC { get; protected set; }
    public virtual GridManager GM { get; protected set; }
    public virtual EconomyController EC { get; protected set; }

    public virtual int PlayerObjectID { get; protected set; } = 0;
    public virtual string ObjectName { get; protected set; } = "Default Building";
    public virtual string ObjectDescription { get; protected set; } = "Default Building description";
    public virtual string ObjectType { get; protected set; } = "Building";

    public virtual bool IsFriendly { get; protected set; } = true;
    public virtual bool IsHostile { get; protected set; } = false;
    public virtual bool CanSelect { get; protected set; } = true;
    public virtual bool IsAlive { get; protected set; } = true;
    public virtual bool IsDead { get; protected set; } = false;
    public virtual bool CanDie { get; protected set; } = true;

    public virtual float MaxHitpoints { get; protected set; } = 100.0f;
    public virtual float CurrentHitpoints { get; protected set; }
    public virtual float Armor { get; protected set; } = 0.0f;
    public virtual float Protection { get; protected set; } = 0.0f;

    public virtual float PriorityDanger { get; protected set; } = 1.0f;
    public virtual float PriorityValue { get; protected set; } = 1.0f;
    public virtual float PriorityObstacle { get; protected set; } = 1.0f;

    public virtual DataStructures.Cost KillReward { get; protected set; } = new DataStructures.Cost(100.0f, 10.0f, 5.0f, 0.0f, 0.0f, 5.0f);

    public defaultEnemy(EStructureType Type=EStructureType.Enemy)
    {
        //this.type = type;
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
    public virtual void onHit()
    {

    }
    public virtual void onDeath()
    {

    }
    public virtual void onSpawn()
    {

    }
    public virtual void onDespawn()
    {

    }
    public virtual void AttackTarget()
    {

    }
}
