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

    public static int Inventors = 0;
    public static int Researchers = 0;
    public static int Academies = 0;

    public static bool AllowMetalBuildings = false;
    public static bool AllowCrystalBuildings = false;
    public static bool AllowMagicBuildings = false;

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

    public void InventorBuilt()
    {
        Inventors++;
        AllowMetalBuildings = true;
    }
    public void InventorDestroyed()
    {
        Inventors--;
        if (Inventors <= 0)
        {
            AllowMetalBuildings = false;
        }
    }
    public void ResearcherBuilt()
    {
        Researchers++;
        AllowCrystalBuildings = true;
    }
    public void ResearcherDestroyed()
    {
        Researchers--;
        if (Researchers <= 0)
        {
            AllowCrystalBuildings = false;
        }
    }
    public void AcademyBuilt()
    {
        Academies++;
        AllowMagicBuildings = true;
    }
    public void AcademyDestroyed()
    {
        Academies--;
        if (Academies <= 0)
        {
            AllowMagicBuildings = false;
        }
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
