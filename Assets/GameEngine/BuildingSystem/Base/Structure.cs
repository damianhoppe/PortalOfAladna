using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour, IStructure
{

    public bool PlayerBuildable = true;
    public bool DebugBuildable = true;
    
    public virtual string ObjectName { get; protected set; } = "Structure";
    protected EStructureType type;
    public SpriteRenderer spriteRenderer;

    Position position;
    public bool cursorOver = true;

    public virtual bool IsPlayerBuilding { get; protected set; } = false;
    [SerializeField]
    public virtual int PlayerObjectID { get; protected set; } = 0;
    public virtual int DistanceToCenter { get; protected set; } = 0;
    public virtual int DistanceToPortal { get; protected set; } = 999;

    protected GridManager gridManager;

    public Structure(EStructureType type)
    {
        this.type = type;
    }

    protected virtual void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    protected virtual void Start()
    {
        this.gridManager = FindObjectOfType<GridManager>();
        if (this.cursorOver)
        {
            this.onCursorOver();
            this.cursorOver = false;
        }
    }

    protected virtual void Update()
    {
    }
    public virtual BuildingStatusBehaviour.Status canBuild()
    {
        if (gridManager == null)
            this.gridManager = FindObjectOfType<GridManager>();
        if (!gridManager.isInGrid(getPosition()) || !gridManager.isEmpty(getPosition()))
        {
            return BuildingStatusBehaviour.Status.INCORRECT_PLACE;
        }
        return BuildingStatusBehaviour.Status.ALLOW_BUILDING;
    }

    public string getName()
    {
        return this.ObjectName;
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
        if (BuilderBehaviour._DEBUG) Debug.Log(this.ObjectName + " - onClick()");
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