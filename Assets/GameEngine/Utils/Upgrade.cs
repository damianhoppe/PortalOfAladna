using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade
{
    private string name;
    private int value = 0;
    private int maxValue = 0;

    public Upgrade(string name, int value = 0, int maxValue = 10)
    {
        this.name = name;
        this.value = value;
        this.maxValue = maxValue;
    }

    public string getName()
    {
        return this.name;
    }

    public int getValue()
    {
        return this.value;
    }

    public void setValue(int value)
    {
        this.value = value;
    }

    public bool add()
    {
        if(maxValue > this.value)
        {
            this.value++;
            return true;
        }
        return false;
    }
}
