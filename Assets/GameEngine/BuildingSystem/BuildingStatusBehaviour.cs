using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingStatusBehaviour : MonoBehaviour
{
    [SerializeField]
    private Vector3 shift;

    private GameObject cursor;
    private GameObject canvas;
    private CameraBehaviour cameraB;
    private Image image;
    private Status status;

    void Start()
    {
        this.cursor = FindObjectsOfType<CursorBehaviour>()[0].gameObject;
        this.canvas = FindObjectsOfType<Canvas>()[0].gameObject;
        this.cameraB = FindObjectsOfType<CameraBehaviour>()[0];
        this.image = GameObject.FindWithTag("UI.Building.Status").GetComponent<Image>();
        updateImage();
        setStatus(Status.NONE);
    }

    void Update()
    {
        this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, shift + this.cursor.transform.position, Time.deltaTime*30);
    }

    public void setStatus(Status status)
    {
        if (status == Status.NONE || status == Status.ALLOW_BUILDING)
        {
            this.canvas.SetActive(false);
            return;
        }
        Debug.Log(status);
        if (this.status != status)
        {
            this.status = status;
            updateImage();
        }
        this.canvas.SetActive(true);
    }

    public Status getStatus()
    {
        return this.status;
    }

    public void updateImage()
    {
        Debug.Log(this.status.ToString());
        switch(this.status)
        {
            case Status.LACK_OF_REQUIRED_BUILDING:
                this.image.sprite = Resources.Load<Sprite>("BuildingStatus/1");
                break;
            case Status.LACK_OF_MATERIALS:
                this.image.sprite = Resources.Load<Sprite>("BuildingStatus/1");
                break;
            case Status.DESTRUCTION:
                this.image.sprite = Resources.Load<Sprite>("BuildingStatus/2");
                break;
            case Status.ALLOW_BUILDING:
                this.image.sprite = Resources.Load<Sprite>("BuildingStatus/3");
                break;
        }
    }

    public enum Status
    {
        NONE, LACK_OF_REQUIRED_BUILDING, LACK_OF_MATERIALS, DESTRUCTION, ALLOW_BUILDING
    }
}
