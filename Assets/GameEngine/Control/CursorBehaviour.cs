using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehaviour : MonoBehaviour, IOnUpdateInterpolation<Vector3>
{
    bool canExceedGrid = false;
    bool canEnterOnTakenPlace = true;

    BuilderBehaviour builderBehaviour;
    GridManager gridManager;

    SpriteRenderer spriteRenderer;
    Color mainColor;
    List<IOnCursorPositionChanged> onPositionChangedListeners;
    Position position;
    V3Interp positionInterpolator;

    void Start()
    {
        this.builderBehaviour = FindObjectOfType<BuilderBehaviour>();
        this.gridManager = FindObjectOfType<GridManager>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.mainColor = spriteRenderer.color;

        this.onPositionChangedListeners = new List<IOnCursorPositionChanged>();
        this.position = new Position();
        this.positionInterpolator = new V3Interp(0.02f, this);
    }

    void Update()
    {
        if (!Input.GetMouseButton(1))
        {
            Position oldPosition = this.position;
            this.position = getCursorPosition();
            if (this.position != oldPosition)
            {
                this.positionInterpolator.setValues(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), this.position.toVector3(this.transform.position.z));
                this.positionInterpolator.reset();
                foreach (IOnCursorPositionChanged listener in this.onPositionChangedListeners)
                {
                    listener.onPositionChanged(this.position, oldPosition);
                }
            }
        }
        this.positionInterpolator.update();

        if (Input.GetKeyDown("1"))
        {
            this.builderBehaviour.setBuildingMode(BuilderBehaviour.Mode.BUILDING, this.builderBehaviour.getBuildings()[0].gameObject);
            //this.canEnterOnTakenPlace = false;
        }
        if (Input.GetKeyDown("2"))
        {
            this.builderBehaviour.setBuildingMode(BuilderBehaviour.Mode.BUILDING, this.builderBehaviour.getBuildings()[1].gameObject);
            //this.canEnterOnTakenPlace = false;
        }
        if (Input.GetKeyDown("3"))
        {
            this.builderBehaviour.setBuildingMode(BuilderBehaviour.Mode.BUILDING, this.builderBehaviour.getBuildings()[2].gameObject);
            //this.canEnterOnTakenPlace = false;
        }
        if (Input.GetKeyDown("4"))
        {
            this.builderBehaviour.setBuildingMode(BuilderBehaviour.Mode.BUILDING, this.builderBehaviour.getBuildings()[3].gameObject);
            //this.canEnterOnTakenPlace = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.builderBehaviour.setBuildingMode(BuilderBehaviour.Mode.NONE);
            this.canEnterOnTakenPlace = true;
        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            this.builderBehaviour.setBuildingMode(BuilderBehaviour.Mode.DESTRUCTION);
            this.canEnterOnTakenPlace = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (this.builderBehaviour.getBuildingMode() == BuilderBehaviour.Mode.NONE)
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
        if (!this.canExceedGrid && !this.gridManager.isInGrid(newPosition.getX(), newPosition.getY()))
            return this.position;
        if (!this.canEnterOnTakenPlace && !this.gridManager.isEmpty(newPosition.getX(), newPosition.getY()))
            return this.position;
        return newPosition;
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

    public void onUpdateInterpolation(Interpolator<Vector3> interpolator, Vector3 value)
    {
        this.transform.position = value;
    }

    public void resetColor()
    {
        this.spriteRenderer.color = this.mainColor;
    }

    public void setColor(Color color)
    {
        color.a = 0.5f;
        this.spriteRenderer.color = color;
    }
}
