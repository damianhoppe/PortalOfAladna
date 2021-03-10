using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridManager : MonoBehaviour
{
    Grid grid;
    [SerializeField]
    int width = 11;
    [SerializeField]
    int height = 11;
    private void Start()
    {
        if (width % 2 == 0)
            width++;
        if (height % 2 == 0)
            height++;
        grid = new Grid(width, height);
    }
    public bool isInGrid(int x, int y)
    {
        if (x > width / 2 || x < -width / 2)
            return false;
        if (y > height / 2 || y < -height / 2)
            return false;
        return true;
    }

    public bool isEmpty(int x, int y)
    {
        return getStructure(x, y) == null;
    }

    public Structure getStructure(int x, int y)
    {
        if(!isInGrid(x,y)) return null;
        return grid.getGameObject(x, y);
    }

    public void addStructure(Structure structure, int x, int y)
    {
        grid.setGameObject(structure, x, y);
    }
}