using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingStructure : MonoBehaviour
{
    EStructureType type;
    SpriteRenderer spriteRenderer;

    protected void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    protected void Update()
    {
    }

    protected void setTexture(string textureName)
    {
        spriteRenderer.sprite = Resources.Load<Sprite>(textureName);
        spriteRenderer.drawMode = SpriteDrawMode.Sliced;
        spriteRenderer.size = new Vector2(0.4f, 0.4f);
    }
}
