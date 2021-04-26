using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject
{
    public int posX;
    public int posY;
    public Structure structure;

    public SaveObject(int posX, int posY, Structure structure)
    {
        this.posX = posX;
        this.posY = posY;
        this.structure = structure;
    }
}
