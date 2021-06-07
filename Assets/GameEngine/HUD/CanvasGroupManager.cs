using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupManager : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    void Awake()
    {
        this.canvasGroup = this.gameObject.GetComponent<CanvasGroup>();
        if (this.canvasGroup == null)
            this.enabled = false;
    }

    public void show()
    {
        this.canvasGroup.alpha = 1;
        this.canvasGroup.blocksRaycasts = true;
        this.canvasGroup.interactable = true;
    }

    public void hide()
    {
        this.canvasGroup.alpha = 0;
        this.canvasGroup.blocksRaycasts = false;
        this.canvasGroup.interactable = false;
    }

    public CanvasGroup getCanvasGroup()
    {
        return this.canvasGroup;
    }

    public void setCanvasGroup(CanvasGroup canvasGroup)
    {
        this.canvasGroup = canvasGroup;
    }
}
