using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Template : MonoBehaviour
{

    bool Load = false;


    [SerializeField]
    private List<Ore> ores;



    public GameObject OreTypo1, OreTypo2, OreTypo3;
    private GridManager gridManager;
    private Ore ore;
    //
    private SpriteRenderer buildingReqSprite;
    //
    // Start is called before the first frame update
    void Start()
    {
        this.gridManager = FindObjectOfType<GridManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Load == false)
        {

            GameObject OreObject1 = Instantiate(OreTypo1);
            Ore StaticOre1 = OreObject1.GetComponent<Ore>();

            GameObject OreObject2 = Instantiate(OreTypo2);
            Ore StaticOre2 = OreObject2.GetComponent<Ore>();

            GameObject OreObject3 = Instantiate(OreTypo3);
            Ore StaticOre3 = OreObject3.GetComponent<Ore>();


            gridManager.addStructure((Structure)StaticOre1, (int)1, (int)1);
            gridManager.addStructure((Structure)StaticOre1, (int)2, (int)1);

            gridManager.addStructure((Structure)StaticOre2, (int)-1, (int)-1);
            gridManager.addStructure((Structure)StaticOre2, (int)-2, (int)-1);

            gridManager.addStructure((Structure)StaticOre3, (int)2, (int)2);
            gridManager.addStructure((Structure)StaticOre3, (int)-2, (int)-2);



            ore = (Ore)this.gridManager.getStructure((int)1, (int)1);










            Load = true;
        }
    }
}
