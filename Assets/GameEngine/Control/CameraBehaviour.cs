using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    bool dragAndDrop = true;
    [SerializeField]
    int moveActivationLimit = 100;
    [SerializeField]
    float moveSpeed = 20;
    [SerializeField]
    float zoomSpeed = 1;
    [SerializeField]
    float zoom = 1;
    [SerializeField]
    float minZoom = 2F;
    [SerializeField]
    float maxZoom = 10F;

    Camera cameraObj;
    GridManager gridManager;

    void Start()
    {
        cameraObj = GetComponent<Camera>();
        gridManager = FindObjectOfType<GridManager>();
        maxZoom += Mathf.Max(gridManager.getWidth(), gridManager.getHeight()) * 0.2f;
        if (maxZoom < minZoom)
            minZoom = maxZoom + 1;
    }

    // Update is called once per frame
    void Update()
    {
        zoom -= Input.mouseScrollDelta.y * zoomSpeed;
        if(zoom < minZoom)
        {
            zoom = minZoom;
        }else if(zoom > maxZoom)
        {
            zoom = maxZoom;
        }
        cameraObj.orthographicSize = zoom;

        moveCamera(getMoveVector());
    }

    Vector3 getMoveVector()
    {
        Vector3 moveVector = new Vector3();
        Vector3 mousePosition = Input.mousePosition;
        if (dragAndDrop)
        {
            if (Input.GetMouseButton(1))
            {
                moveVector = new Vector3(-Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"), 0);
            }
        }
        else
        {
            if (mousePosition.x < moveActivationLimit)
            {
                moveVector.x = -(100 - mousePosition.x) / 100;
            }
            else if (mousePosition.x > Screen.width - moveActivationLimit)
            {
                moveVector.x = (mousePosition.x - Screen.width + moveActivationLimit) / 100;
            }
            if (mousePosition.y < moveActivationLimit)
            {
                moveVector.y = -(100 - mousePosition.y) / 100;
            }
            else if (mousePosition.y > Screen.height - moveActivationLimit)
            {
                moveVector.y = (mousePosition.y - Screen.height + moveActivationLimit) / 100;
            }
        }
        return moveVector;
    }

    void moveCamera(Vector3 moveVector)
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
        if (dragAndDrop)
            newPos += moveVector * moveSpeed * zoom * 0.02f;
        else
            newPos += moveVector * moveSpeed * zoom * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, -gridManager.getWidth()/2, gridManager.getWidth()/2);
        newPos.y = Mathf.Clamp(newPos.y, -gridManager.getWidth()/2, gridManager.getWidth()/2);
        transform.position = newPos;
    }
}
