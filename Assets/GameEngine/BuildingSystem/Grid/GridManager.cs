using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridManager : MonoBehaviour, IOnCursorPositionChanged
{
    Grid grid;
    [SerializeField]
    int width = 11;
    [SerializeField]
    int height = 11;

    private CursorBehaviour cursor;

    public void Start()
    {
        if (width % 2 == 0)
            width++;
        if (height % 2 == 0)
            height++;
        grid = new Grid(width, height);
        this.cursor = GameObject.Find("Cursor").GetComponent<CursorBehaviour>();
        this.cursor.addOnPositionChangedListener(this);
    }

    public void Update()
    {
        Structure structure = getStructure(this.cursor.getPosition());
        if (structure != null)
            structure.onCursorOver();
    }

    public bool isInGrid(int x, int y)
    {
        if (x > width / 2 || x < -width / 2)
            return false;
        if (y > height / 2 || y < -height / 2)
            return false;
        return true;
    }

    public bool isInGrid(Position p)
    {
        return isInGrid(p.x, p.y);
    }

    public int getWidth()
    {
        return this.width;
    }

    public int getHeight()
    {
        return this.height;
    }

    public bool isEmpty(int x, int y)
    {
        return getStructure(x, y) == null;
    }

    public bool isEmpty(float x, float y)
    {
        return isEmpty((int)x, (int)y);
    }

    public bool isEmpty(Position position)
    {
        return isEmpty(position.x, position.y);
    }

    public Structure getStructure(int x, int y)
    {
        if(!isInGrid(x,y)) return null;
        return grid.getGameObject(x, y);
    }

    public Structure getStructure(Position position)
    {
        return getStructure(position.x, position.y);
    }

    public Structure getStructure(float x, float y)
    {
        return getStructure((int)x, (int)y);
    }

    public void addStructure(Structure structure, int x, int y)
    {
        grid.setGameObject(structure, x, y);
    }

    public void addStructure(Structure structure, Position position)
    {
        addStructure(structure, position.x, position.y);
    }

    public void addStructure(Structure structure, float x, float y)
    {
        addStructure(structure, (int)x, (int)y);
    }

    public void destroyStructure(int x, int y, bool callOnDestroy = true)
    {
        Structure structure = getStructure(x, y);
        if(structure != null)
        {
            if (callOnDestroy)
                structure.onDestroy();
            Destroy(structure.gameObject);
            grid.setGameObject(null, x, y);
        }
    }

    public void destroyStructure(Position position, bool callOnDestroy = true)
    {
        destroyStructure(position.x, position.y, callOnDestroy);
    }

    public void destroyStructure(float x, float y, bool callOnDestroy = true)
    {
        destroyStructure((int)x, (int)y, callOnDestroy);
    }

    public void onPositionChanged(Position oldPosition, Position newPosition)
    {
        Structure structure1 = getStructure(oldPosition);
        if (structure1 != null)
            structure1.onCursorLeft();
        Structure structure2 = getStructure(newPosition);
        if (structure2 != null)
            structure2.onCursorEnter();
    }
}