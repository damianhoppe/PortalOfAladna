using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
    IOnBuildingSelected onBuildingSelectedListener;
    void Start()
    {
        
    }

    void Update()
    {
        
        transform.position = getCursorPosition();
        if(GlobalSettings.DEBUG)
            Debug.Log(transform.position);
        if(Input.GetMouseButtonDown(0))
        {
            if (this.onBuildingSelectedListener != null)
                this.onBuildingSelectedListener.onBuildingSelected(BuildingId.PORTAL);
        }
    }

    Vector3 getCursorPosition()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.x = convert(position.x);
        position.y = convert(position.y);
        position.z = 0;
        return position;
    }

    float convert(float v)
    {
        if(v < 0)
        {
            v = -v;
            return -round(v);
        }
        return round(v);
    }
    
    float round(float v)
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
}
