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

    public Dictionary<string, float> SaveMe()
    {
        Dictionary<string, float> save = new Dictionary<string, float>();

        save.Add("Inventors", Inventors);
        save.Add("Researchers", Researchers);
        save.Add("Academies", Academies);
        if(AllowMetalBuildings) save.Add("AllowMetalBuildings", 1f);
        else save.Add("AllowMetalBuildings", 0f);
        if (AllowCrystalBuildings) save.Add("AllowCrystalBuildings", 1f);
        else save.Add("AllowCrystalBuildings", 0f);
        if (AllowMagicBuildings) save.Add("AllowMagicBuildings", 1f);
        else save.Add("AllowMagicBuildings", 0f);

        return save;
    }
    public void LoadMe(Dictionary<string,float> save)
    {
        float data;
        save.TryGetValue("Inventors", out data);
        Inventors = (int)data;
        save.TryGetValue("Researchers", out data);
        Researchers = (int)data;
        save.TryGetValue("Academies", out data);
        Academies = (int)data;
        save.TryGetValue("AllowMetalBuildings", out data);
        if (data == 1) AllowMetalBuildings = true;
        else AllowMetalBuildings = false;
        save.TryGetValue("AllowCrystalBuildings", out data);
        if (data == 1) AllowCrystalBuildings = true;
        else AllowCrystalBuildings = false;
        save.TryGetValue("AllowMagicBuildings", out data);
        if (data == 1) AllowMagicBuildings = true;
        else AllowMagicBuildings = false;
    }

    public bool CanBuild(bool metal, bool crystal, bool magic)
    {
        if(metal == true)
        {
            if (AllowMetalBuildings == false) return false;
        }
        if(crystal == true)
        {
            if (AllowCrystalBuildings == false) return false;
        }
        if(magic == true)
        {
            if (AllowMagicBuildings == false) return false;
        }
        return true;
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
