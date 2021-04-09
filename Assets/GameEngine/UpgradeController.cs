using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    IDictionary<int, Upgrade> upgrades;
    public const int ARMOR_BUILDING = 0;
    public const int ARMOR_TROOPS = 1;
    public const int HP_BUILDING = 2;
    public const int HP_TROOPS = 3;
    public const int BUILDING_SPEED = 4;

    public UpgradeController()
    {
        this.upgrades = new Dictionary<int, Upgrade>();
        this.upgrades.Add(ARMOR_BUILDING, new Upgrade("Building armor upgrade", 0));
        this.upgrades.Add(ARMOR_TROOPS, new Upgrade("Troops armor upgrade", 0));
        this.upgrades.Add(HP_BUILDING, new Upgrade("Bonus building health points", 0));
        this.upgrades.Add(HP_TROOPS, new Upgrade("Bonus troops health points", 0));
        this.upgrades.Add(BUILDING_SPEED, new Upgrade("Building speed", 0));
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public bool CanAffordTEST(DataStructures.Cost koszt)
    {
        return true;
    }

    public float calculateArmor(float objectArmor)
    {
        //return objectArmor + this.upgrades.Get(ARMOR);
        //return objectArmor * this.upgrades.Get(ARMOR);
        return objectArmor;
    }

    public Upgrade getUpgrade(int upgradeId)
    {
        return this.upgrades[upgradeId];
    }
}
