using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class SaveController : MonoBehaviour
{
    string savePath;
    string saveMap;
    string saveUpgrades;
    string saveEconomy;
    string saveDayNight;
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
    List<SaveObject> mapStructures = new List<SaveObject>();
    ObjectHolder OH;
    // Start is called before the first frame update
    void Start()
    {
        savePath = Application.dataPath + "/Save/";
        saveDayNight = savePath+ "/DayNight.dat";
        saveMap = savePath + "/Map.dat";
        saveUpgrades = savePath + "/Upgrades.dat";
        saveEconomy = savePath + "/Economy.dat";
        SaveLocations.Add(saveDayNight);
        SaveLocations.Add(saveMap);
        SaveLocations.Add(saveUpgrades);
        SaveLocations.Add(saveEconomy);
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
            GetDataFromGrid();
            SaveMap();
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadMap();
        }
    }
    void GetDataFromGrid()
    {
        
        int width = GM.getWidth();
        int height = GM.getHeight();
        mapStructures.Clear();
        for (int x = -width / 2; x <= width / 2; x++) {

            for (int y = -height / 2; y <= height / 2; y++)
            {
                Debug.Log(x + " " + y);
                Structure objectOnGrid = GM.getStructure(x, y);
                if (objectOnGrid != null)
                {
                    mapStructures.Add(new SaveObject(x, y, objectOnGrid));
                }

            }

        }

    }

    void SaveMap()
    {
        Debug.Log("Saving...");
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
                sw.WriteLine(ob.posX + "|" + ob.posY +"|"+ JsonUtility.ToJson(ob.structure));
            }
            sw.Close();
        }
        Debug.Log("Saved");

        
    }

    void LoadMap()
    {
        Debug.Log("Loading...");
        List<SaveObject> readedObjects = new List<SaveObject>();
        using (FileStream fs = new FileStream(saveMap, FileMode.Open, FileAccess.Read))
        using (StreamReader sr = new StreamReader(fs))
        {
            int width = int.Parse(sr.ReadLine());
            int height = int.Parse(sr.ReadLine());
            string line;
            while((line = sr.ReadLine())!= "\n")
            {
                Debug.Log(line);
                var vars = line.Split('|');
                var posX = int.Parse(vars[0]);
                var posY = int.Parse(vars[1]);
                var obj = JsonConvert.DeserializeObject(vars[2]);
                string name = obj.ToString();
                name = name.Split(':')[1];
                name = name.Split(',')[0];
                name = name.Split('"')[1];
                Debug.Log(name);
                GameObject myObj = null;
                OH.Buildings.TryGetValue(name,out myObj);
                Debug.Log(myObj);
                BB.LoadBuilding(posX, posY, myObj);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
               
            };
            sr.Close();
        }
        foreach(var ob in readedObjects)
        {
            GM.addStructure(ob.structure, new Position(ob.posX, ob.posY));
        }
         
    }

    void Save()
    {
        Debug.Log("Saving...");
        File.WriteAllText(saveEconomy, string.Empty);
        using (FileStream fs = new FileStream(saveEconomy, FileMode.Open, FileAccess.Write))
        using (StreamWriter sw = new StreamWriter(fs))
        {

            sw.Close();
        }
        Debug.Log("Saved");

    }

}
