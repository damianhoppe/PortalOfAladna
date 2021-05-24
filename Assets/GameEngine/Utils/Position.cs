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
    public bool Equals(int x, int y)
    {
        return (this.x == x && this.y == y);
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

    public float distanceTo(Position position)
    {
        return Position.distanceBetween(this, position);
    }

    public static float distanceBetween(Position pos1, Position pos2)
    {
        float distanceX = Mathf.Abs((float)(pos1.x - pos2.x));
        float distanceY = Mathf.Abs((float)(pos1.y - pos2.y));
        return Mathf.Sqrt(distanceX * distanceX + distanceY * distanceY);
    }
    public static Position operator +(Position A, int[] B)
    {
        return new Position(A.x + B[0], A.y + B[1]);
    }
    public static Position operator -(Position A, int[] B)
    {
        return new Position(A.x - B[0], A.y - B[1]);
    }
    public static Position operator +(Position A, Vector2Int B)
    {
        return new Position(A.x + B.x, A.y + B.y);
    }    
    public static Position operator -(Position A, Vector2Int B)
    {
        return new Position(A.x - B.x, A.y - B.y);
    }
    public Position ShiftPosition(int X, int Y)
    {
        return new Position(this.x+X, this.y+Y);
    }
}
