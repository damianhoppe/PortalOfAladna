using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;

public class GridManager : MonoBehaviour, IOnCursorPositionChanged
{
    [SerializeField]
    public bool DEBUG = false;
    [SerializeField]
    public int width = 11;
    [SerializeField]
    public int height = 11;
    Grid grid;

    private CursorBehaviour cursor;
    private List<Position> changedPositionsInFrame;
    private List<OnGridChangedPerFrame> onGridChangedListeners;

    public GridManager()
    {
        this.changedPositionsInFrame = new List<Position>();
        this.onGridChangedListeners = new List<OnGridChangedPerFrame>();
    }

    public void Awake()
    {
        if (width % 2 == 0)
            width++;
        if (height % 2 == 0)
            height++;
        grid = new Grid(width, height);
    }

    public void Start()
    {
        this.cursor = GameObject.Find("Cursor").GetComponent<CursorBehaviour>();
        this.cursor.addOnPositionChangedListener(this);
    }

    public void Update()
    {
        Structure structure = getStructure(this.cursor.getPosition());
        if (structure != null)
            structure.onCursorOver();
    }

    public void LateUpdate()
    {
        if(DEBUG) Debug.Log(this.changedPositionsInFrame.Count);
        if (this.changedPositionsInFrame.Count > 0)
        {
            foreach (OnGridChangedPerFrame listener in this.onGridChangedListeners)
            {
                Position pos = listener.getPosition();
                listener.onGridChanged(this.changedPositionsInFrame);
            }
        }
        this.changedPositionsInFrame.Clear();
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
        if (!isEmpty(x, y))
            return;
        grid.setGameObject(structure, x, y);
        positionChanged(x, y);
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
            positionChanged(x, y);
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

    public void addOnGridChangedListener(OnGridChangedPerFrame listener)
    {
        this.onGridChangedListeners.Add(listener);
    }

    public void removeOnGridChangedListener(OnGridChangedPerFrame listener)
    {
        this.onGridChangedListeners.Remove(listener);
    }

    private void positionChanged(int x, int y)
    {
        if (containtPosition(x, y))
            return;
        this.changedPositionsInFrame.Add(new Position(x, y));
    }

    private bool containtPosition(int x, int y)
    {
        foreach (Position position in this.changedPositionsInFrame)
        {
            if (position.x == x && position.y == y)
                return true;
        }
        return false;
    }

    private bool containtPosition(Position position)
    {
        return containtPosition(position.x, position.y);
    }
}