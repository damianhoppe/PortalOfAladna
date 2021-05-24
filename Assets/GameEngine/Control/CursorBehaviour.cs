using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorBehaviour : MonoBehaviour, IOnUpdateInterpolation<Vector3>
{
    [SerializeField]
    float defaultAlpha = 0.5f;
    bool canExceedGrid = false;
    bool canEnterOnTakenPlace = true;

    BuilderBehaviour builderBehaviour;
    ObjectHolder objectHolder;
    GridManager gridManager;

    SpriteRenderer spriteRenderer;
    Color mainColor;
    List<IOnCursorPositionChanged> onPositionChangedListeners;
    Position position;
    V3Interp positionInterpolator;

    public bool cursorActionsLocked = false;
    int uiLayer;

    void Start()
    {
        this.builderBehaviour = FindObjectOfType<BuilderBehaviour>();
        this.objectHolder = GameObject.Find("SaveController").GetComponent<ObjectHolder>();
        this.gridManager = FindObjectOfType<GridManager>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.mainColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, this.defaultAlpha);
        this.spriteRenderer.color = this.mainColor;

        this.onPositionChangedListeners = new List<IOnCursorPositionChanged>();
        this.position = new Position();
        this.positionInterpolator = new V3Interp(0.02f, this);
        this.uiLayer = LayerMask.NameToLayer("UI");
    }

    void Update()
    {
        updateCursorLocked();
        if (!Input.GetMouseButton(1))
        {
            Position oldPosition = this.position;
            this.position = getCursorPosition();
            if (this.position.x != oldPosition.x || this.position.y != oldPosition.y)
            {
                this.positionInterpolator.setValues(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), this.position.toVector3(this.transform.position.z));
                this.positionInterpolator.reset();
                foreach (IOnCursorPositionChanged listener in this.onPositionChangedListeners)
                {
                    listener.onPositionChanged(oldPosition, this.position);
                }
            }
        }
        this.positionInterpolator.update();

        for(int i = 0; i < 10 && i < this.objectHolder.BuildingsList.Count; i++)
        {
            if(Input.GetKeyDown(i.ToString()))
            {
                this.builderBehaviour.setBuildingMode(BuilderBehaviour.Mode.BUILDING, this.objectHolder.BuildingsList[i].gameObject);
            }
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
        if (this.GetMouseButtonDown(0))
        {
            if (this.builderBehaviour.getBuildingMode() == BuilderBehaviour.Mode.NONE)
            {
                Structure structure = this.gridManager.getStructure(this.position.getX(), this.position.getY());
                if (structure != null)
                    structure.onClick();
            }
        }
    }

    public bool GetMouseButtonDown(int button)
    {
        return Input.GetMouseButtonDown(button) && !this.cursorActionsLocked;
    }

    private void updateCursorLocked()
    {
        this.cursorActionsLocked = IsPointerOverUIElement();
    }

    public bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }


    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == uiLayer)
                return true;
        }
        return false;
    }

    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
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
        color.a = this.defaultAlpha;
        this.spriteRenderer.color = color;
    }
}
