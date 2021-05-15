using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class SaveController : MonoBehaviour
{
    string savePath;
    string saveMap;
    string saveUpgrades;
    string saveEconomy;
    string saveDayNight;
    string savePopulation;
    List<string> SaveLocations = new List<string>();
    [SerializeField]
    GridManager GM;
    [SerializeField]
    BuilderBehaviour BB;
    EconomyController EC;
    PopulationController PC;
    UpgradeController UC;
    DayNightController DNC;
    [SerializeField]
    List<string> jsons;
    ObjectHolder OH;
    // Start is called before the first frame update
    void Start()
    {
        savePath = Application.dataPath + "/Save/";
        saveDayNight = savePath+ "/DayNight.dat";
        saveMap = savePath + "/Map.dat";
        saveUpgrades = savePath + "/Upgrades.dat";
        saveEconomy = savePath + "/Economy.dat";
        savePopulation = savePath + "/Population.dat";
        SaveLocations.Add(saveDayNight);
        SaveLocations.Add(saveMap);
        SaveLocations.Add(saveUpgrades);
        SaveLocations.Add(saveEconomy);
        SaveLocations.Add(savePopulation);
        GM = GameObject.FindObjectOfType<GridManager>();
        BB = GameObject.FindObjectOfType < BuilderBehaviour>();
        EC = GameObject.FindObjectOfType<EconomyController>();
        UC = GameObject.FindObjectOfType<UpgradeController>();
        PC = GameObject.FindObjectOfType<PopulationController>();
        DNC = GameObject.FindObjectOfType<DayNightController>();
        OH = GameObject.FindObjectOfType<ObjectHolder>();
        if (!CreateSaveFiles())
        {
            Debug.LogError("Błąd zapisu!");
        }
        
    }

    bool CreateSaveFiles()
    {
        FileStream file;
        try
        {
            if (!File.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
                foreach (var destination in SaveLocations)
            {
                if (!File.Exists(destination))
                {
                    file = File.Create(destination);
                }
            }
            return true;
        }
        catch (DirectoryNotFoundException dirEx)
        {
            // Let the user know that the directory did not exist.
            Debug.Log("Directory not found: " + dirEx.Message,this);
            return false;
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
            return false;
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            
            SaveMap();
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            load();
            Debug.Log(EC.PlayerResources.ToString());
            LoadMap();
                        
        }
    }
    List<SaveObject> GetDataFromGrid()
    {
        
        int width = GM.getWidth();
        int height = GM.getHeight();
        List<SaveObject> mapStructures = new List<SaveObject>();
        for (int x = -width / 2; x <= width / 2; x++) {

            for (int y = -height / 2; y <= height / 2; y++)
            {
                Debug.Log(x + " " + y);
                Structure objectOnGrid = GM.getStructure(x, y);
                if (objectOnGrid != null)
                {
                    DefaultBuilding DB = (DefaultBuilding)objectOnGrid;

                    mapStructures.Add(new SaveObject(x, y, DB.PlayerObjectID, DB.save()));
                }
            }

        }

        return mapStructures;

    }

    void SaveMap()
    {
        
        Debug.Log("Saving...");
        List<SaveObject> mapStructures = GetDataFromGrid();
        int width = GM.getWidth();
        int height = GM.getHeight();
        File.WriteAllText(saveMap, string.Empty);
        using (FileStream fs = new FileStream(saveMap, FileMode.Open, FileAccess.Write))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            
            sw.WriteLine(width);
            sw.WriteLine(height);
            foreach(var ob in mapStructures)
            {
                sw.WriteLine(ob.posX + "|" + ob.posY +"|"+ob.id+"|" + SaveObject(ob.save));
            }
            sw.Close();
        }
        Debug.Log("Saved");

        
    }

    void LoadMap()
    {
        Debug.Log("Loading...");
        ClearMap();
        using (FileStream fs = new FileStream(saveMap, FileMode.Open, FileAccess.Read))
        using (StreamReader sr = new StreamReader(fs))
        {
            int width = int.Parse(sr.ReadLine());
            int height = int.Parse(sr.ReadLine());
            string[] lines;

            lines = File.ReadAllLines(saveMap);
            Debug.Log(lines.Length);
            for (int i = 2; i < lines.Length; i += 1)
            {
                string[] vars = lines[i].Split('|');
                var posX = int.Parse(vars[0]);
                var posY = int.Parse(vars[1]);
                int id = int.Parse(vars[2]);
                Dictionary<string,float> save = LoadObject(vars[3]);
                Debug.Log(name);
                GameObject myObj = null;
                OH.Buildings.TryGetValue(id, out myObj);
                BB.LoadBuilding(posX, posY, myObj);
                GM.getStructure(posX, posY).gameObject.GetComponent<DefaultBuilding>().load(save);
            }
            sr.Close();
        }
         
    }

    private Dictionary<string, float> LoadObject(string data)
    {
        Dictionary<string, float> save = new Dictionary<string, float>();

        string[] line = data.Split(';');

        for (int i = 0; i < line.Length; i += 1)
        {
            string[] x = line[i].Split(':');
            save.Add(x[0], float.Parse(x[1]));
        }
        return save;
    }

    string SaveObject(Dictionary<string,float> data)
    {
        string save = "";

        int i = 0;

        foreach (KeyValuePair<string, float> kvp in data)
        {
            if (i != 0) save += ";";
            save += (kvp.Key + ":" + kvp.Value);
            i++;
        }


        return save;
    }

    void Save()
    {
        Debug.Log("Saving...");
        Dictionary<string, float> saveEC = EC.SaveMe();
        Dictionary<string, float> savePC = PC.SaveMe();
        Dictionary<string, float> saveUC = UC.SaveMe();
        Dictionary<string, float> saveDNC = DNC.SaveMe();

        File.WriteAllText(saveEconomy, string.Empty);
        using (FileStream fs = new FileStream(saveEconomy, FileMode.Open, FileAccess.Write))
        using (StreamWriter sw = new StreamWriter(fs))
        {

            foreach (KeyValuePair<string,float> kvp in EC.SaveMe())
            {
                sw.WriteLine(kvp.Key + ":" + kvp.Value);
            }


            sw.Close();
        }
        Debug.Log("EC Saved");


        File.WriteAllText(savePopulation, string.Empty);
        using (FileStream fs = new FileStream(savePopulation, FileMode.Open, FileAccess.Write))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            foreach (KeyValuePair<string, float> kvp in PC.SaveMe())
            {
                sw.WriteLine(kvp.Key + ":" + kvp.Value);
            }
            sw.Close();
        }
        Debug.Log("PC Saved");

        File.WriteAllText(saveUpgrades, string.Empty);
        using (FileStream fs = new FileStream(saveUpgrades, FileMode.Open, FileAccess.Write))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            foreach (KeyValuePair<string, float> kvp in UC.SaveMe())
            {
                sw.WriteLine(kvp.Key + ":" + kvp.Value);
            }
            sw.Close();
        }
        Debug.Log("UC Saved");
        
        File.WriteAllText(saveDayNight, string.Empty);
        using (FileStream fs = new FileStream(saveDayNight, FileMode.Open, FileAccess.Write))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            foreach (KeyValuePair<string, float> kvp in DNC.SaveMe())
            {
                sw.WriteLine(kvp.Key + ":" + kvp.Value);
            }
            sw.Close();
        }
        Debug.Log("DNC Saved");
    }

    void load()
    {
       
        var ec = new Dictionary<string, float>();
        var uc = new Dictionary<string, float>();
        var pc = new Dictionary<string, float>();
        var dnc = new Dictionary<string, float>();


        var lines = File.ReadAllLines(saveDayNight);
        for (int i = 0; i < lines.Length; i += 1)
        {
            string[] x = lines[i].Split(':');
            dnc.Add(x[0], float.Parse(x[1]));
        }
        lines = File.ReadAllLines(saveEconomy);
        for (int i = 0; i < lines.Length; i += 1)
        {
            string[] x = lines[i].Split(':');
            ec.Add(x[0], float.Parse(x[1]));
        }
        lines = File.ReadAllLines(savePopulation);
        for (int i = 0; i < lines.Length; i += 1)
        {
            string[] x = lines[i].Split(':');
            pc.Add(x[0], float.Parse(x[1]));
        }
        lines = File.ReadAllLines(saveUpgrades);
        for (int i = 0; i < lines.Length; i += 1)
        {
            string[] x = lines[i].Split(':');
            uc.Add(x[0], float.Parse(x[1]));
        }
        EC.LoadMe(ec);
        PC.LoadMe(pc);
        UC.LoadMe(uc);
        DNC.LoadMe(dnc);
    }

    void ClearMap()
    {
        int width = GM.getWidth();
        int height = GM.getHeight();
        List<SaveObject> mapStructures = new List<SaveObject>();
        for (int x = -width / 2; x <= width / 2; x++)
        {

            for (int y = -height / 2; y <= height / 2; y++)
            {
                Debug.Log(x + " " + y);
                Structure objectOnGrid = GM.getStructure(x, y);
                if (objectOnGrid != null)
                {
                    DefaultBuilding DB = (DefaultBuilding)objectOnGrid;
                    DB.destroy();
                }
            }

        }
    }
}
