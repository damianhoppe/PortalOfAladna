using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position
{
    public int x;
    public int y;

    public Position() : this(0,0) { }
    public Position(Position position) : this(position.x, position.y) { }
    public Position(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public virtual bool Equals(Position other)
    {
        return (this.x == other.x && this.y == other.y);
    }

    public Vector3 toVector3(float z = 0)
    {
        return new Vector3(this.x, this.y, z);
    }

    public string toString()
    {
        return this.x + " ; " + this.y;
    }

    public int getX()
    {
        return this.x;
    }
    public int getY()
    {
        return this.y;
    }

    public void setX(int x)
    {
        this.x = x;
    }

    public void setY(int y)
    {
        this.y = y;
    }
}
