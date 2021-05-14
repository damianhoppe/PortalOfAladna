using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour, IStructure
{
    [SerializeField] string Name;
    protected EStructureType type;
    protected SpriteRenderer spriteRenderer;

    Position position;
    public bool cursorOver = true;

    public virtual bool IsPlayerBuilding { get; protected set; } = false;

    public virtual int PlayerObjectID { get; protected set; } = 0;
    public virtual int DistanceToCenter { get; protected set; } = 0;
    public virtual int DistanceToPortal { get; protected set; } = 999;

    public Structure(EStructureType type)
    {
        this.type = type;
    }

    protected virtual void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        if(this.cursorOver)
        {
            this.onCursorOver();
            this.cursorOver = false;
        }
    }

    protected virtual void Update()
    {
    }

    public string getName()
    {
        return this.Name;
    }

    public Position getPosition()
    {
        return this.position;
    }

    public void setPosition(Position position)
    {
        this.position = position;
    }

    public virtual void onClick()
    {
        Debug.Log(this.Name + " - onClick()");
    }

    public virtual void onDestroy()
    {
    }

    public virtual void destroy(bool forceDestruction = false)
    {
        this.onDestroy();
        GridManager gridManager = GameObject.Find("BuildingSystem").GetComponent<GridManager>();
        if(gridManager != null)
        {
            gridManager.destroyStructure(this.getPosition(), false);
        }
    }

    public EStructureType getType()
    {
        return this.type;
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
    public virtual void setDistanceToCenter()
    {
        this.DistanceToCenter = (Mathf.Abs(this.position.x) + Mathf.Abs(this.position.y));
    }
}