using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour, IStructure
{
    [SerializeField] string name;
    protected EStructureType type;
    SpriteRenderer spriteRenderer;

    Position position;

    public Structure(EStructureType type)
    {
        this.type = type;
    }

    protected void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public string getName()
    {
        return this.name;
    }

    public Position getPosition()
    {
        return this.position;
    }

    public void setPosition(Position position)
    {
        this.position = position;
    }
    public void onClick()
    {
        Debug.Log(this.name + " onClick");
    }
}
