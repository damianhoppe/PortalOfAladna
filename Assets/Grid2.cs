using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid2
{
    private int width;
    private int height;
    private int[,] gridArray;
    private float cellSize;
    private TextMesh[,] DebugTextArray;
    private GameObject[,] gridObjectsArray;
    public Grid2()
    {
        
    }
    public Grid2(int width, int height, float cellSize, GameObject[] sprite)
    {
        
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        gridObjectsArray = new GameObject[width, height];
        gridArray = new int[width, height];
        DebugTextArray = new TextMesh[width, height];
  

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                DebugTextArray[x,y] = UtilsClass.CreateWorldText(x.ToString()+","+y.ToString(), null, GetWorldPosition(x, y) + new Vector3(cellSize,cellSize) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 9999f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 9999f);
                Debug.Log("LOG "+ UnityEngine.Random.Range(0, 1));
                gridObjectsArray[x, y] = GameObject.Instantiate(sprite[UnityEngine.Random.Range(0, 2)]);
                gridObjectsArray[x, y].transform.position = GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * 0.5f;


            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 9999f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 9999f);
        
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    private void getXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x / cellSize);
        y = Mathf.FloorToInt(worldPosition.y / cellSize);
    }

    public void setValue(int x, int y, int value)
    {
        if(x>=0 && y>=0 && x<width && y < height) 
        { 
            gridArray[x, y] = value;
            DebugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }
    public void setValue(Vector3 worldPosition, int value)
    {
        int x, y;
        getXY(worldPosition,out x,out y);
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            DebugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }
    public int getValue(int x,int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return 0;
        }
    }
    public int getValue(Vector3 worldPosition)
    {
        int x, y;
        getXY(worldPosition, out x, out y);
        return getValue(x, y);
    }
}
