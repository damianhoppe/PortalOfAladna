using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseController : MonoBehaviour
{
    // Start is called before the first frame update
    PopulationController PC;
    EconomyController EC;
    DayNightController DNC;
    EnemyControllerV2 ENC;
    [SerializeField]
    int survivalDays = 2;
    [SerializeField]
    int daysLimit = 0;
    [SerializeField]
    int needBossKill = 0;
    [SerializeField]
    int target_gold = 0;
    [SerializeField]
    int target_wood = 0;
    [SerializeField]
    int target_stone = 0;
    [SerializeField]
    int target_metal = 0;
    [SerializeField]
    int target_crystals = 0;
    [SerializeField]
    int target_humans = 0;
    DataStructures.Cost targetMaterial;

    public int NeedBossKill {
        get { return needBossKill; }   // get method
        set { if (value >= 1) { needBossKill = 1; }
            else { needBossKill = 0; }
        }  // set method
    }

    void Start()
    {
        PC = GameObject.Find("PlayerDataController").GetComponent<PopulationController>();
        EC = GameObject.Find("PlayerDataController").GetComponent<EconomyController>();
        DNC = GameObject.Find("PlayerDataController").GetComponent<DayNightController>();
        ENC = GameObject.Find("EnemyControllerV2").GetComponent<EnemyControllerV2>();
        targetMaterial = new DataStructures.Cost(target_gold, target_wood, target_stone, target_metal, target_crystals, target_humans);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //CheckWin();
    }
    public void CheckWin() 
    {


        if (CheckBossDead(ENC.isBossDead) && CheckWinMaterials(targetMaterial) && CheckWinTime(survivalDays) && CheckDaysLimit())
        {
            Debug.Log("WIN");
        }
        else
        {
            if (CheckBossDead(ENC.isBossDead))
            {
                Debug.Log("BOSS KILLED");
            }
            if (CheckWinMaterials(targetMaterial))
            {
                Debug.Log("Materials Gathered");
            }
            if (CheckWinTime(survivalDays))
            {
                Debug.Log("Days Survived");
            }
            if (CheckDaysLimit())
            {
                Debug.Log("In Limit");
            }
        }
    }

    bool CheckDaysLimit()
    {
        if (daysLimit != 0)
        {
            if (daysLimit <= DNC.GetDayNum())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
    bool CheckWinMaterials(DataStructures.Cost targetMaterials)
    {
        var playersMaterials = EC.PlayerResources.ToArray();
        int g = 0;
        for (int i = 0; i < playersMaterials.Length; i++)
        {
            if (playersMaterials[i] >= targetMaterials.ToArray()[i])
            {
                g++;
            }
        }
        if (g == playersMaterials.Length)
        {
            return true;
        }
        return false;

    }
    bool CheckWinTime(int survivalDays)
    {
        if (DNC.GetDayNum() >= survivalDays)
        {
            return true;
        }
        return false;
    }
    bool CheckBossDead(bool BossDead)
    {
        if (NeedBossKill==0)
        {
            return true;
        }
        else
        {
            if (ENC.isBossDead)
            {
                return true;
            }
        }
        return false;
    }
}
