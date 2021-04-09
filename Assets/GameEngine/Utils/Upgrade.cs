using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade
{
    private string name;
    private int value = 0;

    public Upgrade(string name)
    {
        this.name = name;
    }

    public Upgrade(string name, int value)
    {
        this.name = name;
        this.value = value;
    }
}
