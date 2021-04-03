using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool CanAffordTEST(DataStructures.Cost koszt)
    {
        return true;
    }

    public float ArmorUpgrade = 1;

    public float calculateArmor(float objectArmor)
    {
        //return objectArmor + this.ArmorUpgrade;
        //return objectArmor * this.ArmorUpgrade;
        return objectArmor;
    }
}
