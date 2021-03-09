using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid
{
    private int width;
    private int height;
    private GameObject[,] gridArray;
    private Vector2 centerPoint;

    public Grid()
    {
        
    }

    public Grid(int width, int height)
    {
        this.width = width;
        this.height = height;
        centerPoint = new Vector2(this.width/2, this.height/2);

        gridArray = new GameObject[this.width, this.height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                Vector3 v = GetWorldPosition(x, y);
                Debug.DrawLine(GetWorldPositionLine(x, y), GetWorldPositionLine(x, y + 1), Color.white, 9999f);
                Debug.DrawLine(GetWorldPositionLine(x, y), GetWorldPositionLine(x + 1, y), Color.white, 9999f);
            }
        }
        Debug.DrawLine(GetWorldPositionLine(0, height), GetWorldPositionLine(width, height), Color.white, 9999f);
        Debug.DrawLine(GetWorldPositionLine(width, 0), GetWorldPositionLine(width, height), Color.white, 9999f);

    }

    private Vector3 GetWorldPositionLine(int x, int y)
    {
        return new Vector3(x - 0.5f - centerPoint.x, y - 0.5f - centerPoint.y);
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x - centerPoint.x, y - centerPoint.y);
    }

    private void getXY(int wx, int wy, out int x, out int y)
    {
        x = wx + (int)centerPoint.x;
        y = wy + (int)centerPoint.y;
    }

    public GameObject getGameObject(int x, int y)
    {
        getXY(x, y, out x, out y);
        return gridArray[x, y];
    }

    public void setGameObject(GameObject gameObject, int x, int y)
    {
        getXY(x, y, out x, out y);
        gridArray[x, y] = gameObject;
    }
}
