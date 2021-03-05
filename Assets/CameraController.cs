using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int Boundary = 50;
    [SerializeField]
    private int speed = 20;
 
    private int theScreenWidth;
    private int theScreenHeight;

    [SerializeField]
    private int sprint = 0;
    [SerializeField]
    private float minZoom = 10f;
    [SerializeField]
    private float maxZoom = 80f;
    [SerializeField]
    private float zoomSpeed = 10f;
    [SerializeField]
    private float currentZoom = 10f;
    [SerializeField]
    Camera camera = new Camera();
    private bool canMoveCamera;
    void Start()
    {
        canMoveCamera = false;
        camera = Camera.main;
        theScreenWidth = Screen.width;
        theScreenHeight = Screen.height;
    }
    void Update()
    {
        if (canMoveCamera)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                sprint = 30;
            }
            else
            {
                sprint = 1;
            }

            if (Input.mousePosition.x > theScreenWidth - Boundary)
            {
                transform.position += new Vector3((sprint + speed) * Time.deltaTime, 0, 0);
            }

            if (Input.mousePosition.x < 0 + Boundary)
            {

                transform.position -= new Vector3((sprint + speed) * Time.deltaTime, 0, 0);
            }

            if (Input.mousePosition.y > theScreenHeight - Boundary)
            {
                transform.position += new Vector3(0, (sprint + speed) * Time.deltaTime, 0);
            }

            if (Input.mousePosition.y < 0 + Boundary)
            {
                transform.position -= new Vector3(0, (sprint + speed) * Time.deltaTime, 0);
            }


        }
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        camera.orthographicSize = currentZoom;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canMoveCamera = !canMoveCamera;
        }

    }

}

