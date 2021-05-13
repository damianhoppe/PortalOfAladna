using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitObject : MonoBehaviour
{
    // Start is called before the first frame update
    protected virtual void Start()
    {
        GM = GameObject.FindObjectOfType<GridManager>();
        DNC = GameObject.Find("PlayerDataController").GetComponent<DayNightController>();
        EC = GameObject.Find("PlayerDataController").GetComponent<EconomyController>();
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

    public virtual DayNightController DNC { get; protected set; }
    public virtual GridManager GM { get; protected set; }
    public virtual EconomyController EC { get; protected set; }

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
}
