using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
    [SerializeField]
    BuilderBehaviour builderBehaviour;

    IOnBuildingSelected onBuildingSelectedListener;
    List<IOnCursorPositionChanged> onPositionChangedListeners;

    Position position;

    GridManager gridManager;

    void Start()
    {
        this.onPositionChangedListeners = new List<IOnCursorPositionChanged>();
        this.position = new Position();
        this.gridManager = FindObjectOfType<GridManager>();
    }

    void Update()
    {
        Position oldPosition = this.position;
        this.position = getCursorPosition();
        if(this.position != oldPosition)
        {
            foreach (IOnCursorPositionChanged listener in this.onPositionChangedListeners)
            {
                listener.onPositionChanged(this.position, oldPosition);
            }
            this.gameObject.transform.position = this.position.toVector3(0);
        }
        if(Input.GetKeyDown("1"))
        {
            if (this.onBuildingSelectedListener != null)
                this.onBuildingSelectedListener.onBuildingSelected(builderBehaviour.getBuildings()[0].gameObject);
        }
        if (Input.GetKeyDown("2"))
        {
            if (this.onBuildingSelectedListener != null)
                this.onBuildingSelectedListener.onBuildingSelected(builderBehaviour.getBuildings()[1].gameObject);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (this.builderBehaviour.allowsToClick())
            {
                Structure structure = this.gridManager.getStructure(this.position.getX(), this.position.getY());
                if (structure != null)
                    structure.onClick();
            }
        }
    }

    Position getCursorPosition()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Position newPosition = new Position(convert(position.x), convert(position.y));
        if (this.gridManager.isInGrid(newPosition.getX(), newPosition.getY()))
            return newPosition;
        else
            return this.position;
    }

    int convert(float v)
    {
        if(v < 0)
        {
            v = -v;
            return -round(v);
        }
        return round(v);
    }
    
    int round(float v)
    {
        if (v % 1 > 0.5)
        {
            return (int)v + 1;
        }
        else
        {
            return (int)v;
        }
    }

    public void registerOnBuildSelectedListener(IOnBuildingSelected listener)
    {
        this.onBuildingSelectedListener = listener;
    }

    public void addOnPositionChangedListener(IOnCursorPositionChanged listener)
    {
        this.onPositionChangedListeners.Add(listener);
    }

    public void removeOnPositionChangedListener(IOnCursorPositionChanged listener)
    {
        this.onPositionChangedListeners.Remove(listener);
    }

    public Position getPosition()
    {
        return this.position;
    }
}
