using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour, IStructure
{
    [SerializeField] string Name;
    protected EStructureType type;
    protected SpriteRenderer spriteRenderer;

    Position position;

    public Structure(EStructureType type)
    {
        this.type = type;
    }

    protected virtual void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
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

    public EStructureType getType()
    {
        return this.type;
    }
}