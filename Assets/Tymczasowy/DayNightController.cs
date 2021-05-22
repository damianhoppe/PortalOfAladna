using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DayNightController : MonoBehaviour
{
    bool day = true;
    int DayNum;
    [SerializeField]
    List<Spawner_TMP> spawners;
    Light light;

    public MiningController MC { get; protected set; } = null;

    // Start is called before the first frame update
    void Start()
    {
        DayNum = 0;
        light = GameObject.Find("Light").GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Home))
        {
            ChangeTime();
        }
    }
    private void LateUpdate()
    {
    }

    public Dictionary<string, float> SaveMe()
    {
        Dictionary<string, float> save = new Dictionary<string, float>();
        save.Add("DayNum", DayNum);



        return save;
    }
    public void LoadMe(Dictionary<string, float> save)
    {
        float data;
        save.TryGetValue("DayNym", out data);
        DayNum = (int)data;


    }

    public void UpdatePathfinding()
    {
        ScanPathfinding();
    }

    public static void ScanPathfinding()
    {
        AstarPath.active.Scan();
    }

    public bool IsDay()
    {
        return day;
    }
    void ChangeTime()
    {
        this.day = !this.day;
        if (day == false)
        {
            NightTime();
        }
        if (day == true)
        {
            DayTime();
        }
    }
    void GetSpawners()
    {
        GameObject[] array = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (var a in array)
        {
            spawners.Add(a.GetComponent<Spawner_TMP>());
        }
    }
    void SpawnMonsters()
    {
        foreach(var spawner in spawners)
        {
            spawner.Spawn();
        }
    }
    public void BuildingDestroyed()
    {
        UpdatePathfinding();
    }
    void DayTime()
    {
        DayNum++;
        light.intensity = 5;
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(var enemy in enemys)
        {
            Destroy(enemy);
        }
        spawners.Clear();
        
        EconomyController EC = GameObject.Find("PlayerDataController").GetComponent<EconomyController>();
        EC.DailyEnergyGain();

        this.MC.DeliverResources();
        this.MC.MineDay();
    }
    void NightTime()
    {
        GetSpawners();
        ScanPathfinding();
        SpawnMonsters();
        light.intensity = 1;

        this.MC.DeliverResources();
        this.MC.MineNight();

    }
    public bool ConnectMiningController()
    {
        if (this.MC == null)
        {
            MiningController tmpMC = GameObject.Find("MiningController").GetComponent<MiningController>();
            if (tmpMC == null)
            {
                Debug.Log("DNC: Cannot find Mining Controller!");
                return false;
            }
            else
            {
                this.MC = tmpMC;
                Debug.Log("DNC: Mining Controller connected!");
                return true;
            }
        }
        else
        {
            Debug.Log("DNC: Mining Controller already connected!");
            return false;
        }
        
    }
}
