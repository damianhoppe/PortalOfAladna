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

    void Update()
    {
    }

    public bool canBuild(float x, float y)
    {
        return canBuild((int)x, (int)y);
    }

    public bool isEmpty(float x, float y)
    {
        return isEmpty((int)x, (int)y);
    }

    public GameObject getBuilding(float x, float y)
    {
        return getBuilding((int)x, (int)y);
    }

    public void addBuilding(GameObject building, float x, float y)
    {
        addBuilding(building, (int)x, (int)y);
    }

    public bool canBuild(int x, int y)
    {
        if (x > width / 2 || x < -width / 2)
            return false;
        if (y > height / 2 || y < -height / 2)
            return false;
        return isEmpty(x,y);
    }

    public bool isEmpty(int x, int y)
    {
        return getBuilding(x,y) == null;
    }

    public GameObject getBuilding(int x, int y)
    {
        return grid.getGameObject(x,y);
    }

    public void addBuilding(GameObject building, int x, int y)
    {
        grid.setGameObject(building, x, y);
    }
}
