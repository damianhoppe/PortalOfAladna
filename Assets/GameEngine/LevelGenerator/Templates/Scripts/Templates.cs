using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Templates : MonoBehaviour
{

    bool Load = false;


    [SerializeField]
    private List<Ore> ores;

    private SpriteRenderer oreReqSprite;

    public GameObject OreTypo1, OreTypo2, OreTypo3;
    private GridManager gridManager;
    private Ore ore;


    void Start()
    {
       this.gridManager = FindObjectOfType<GridManager>();
       this.oreReqSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Load == false)
        {
            //this.oreReqSprite.size = new Vector2((float)this.ore.requiredMinimalDistance * 2 + 1, (float)this.ore.requiredMinimalDistance * 2 + 1);
            //this.oreReqSprite.enabled = true;

            GameObject OreObject1 = Instantiate(OreTypo1);
            Ore StaticOre1 = OreObject1.GetComponent<Ore>();

            GameObject OreObject2 = Instantiate(OreTypo2);
            Ore StaticOre2 = OreObject2.GetComponent<Ore>();

            GameObject OreObject3 = Instantiate(OreTypo3);
            Ore StaticOre3 = OreObject3.GetComponent<Ore>();


            gridManager.addStructure((Structure)StaticOre1, (int)1, (int)1);


            gridManager.addStructure((Structure)StaticOre2, (int)-1, (int)-1);


            gridManager.addStructure((Structure)StaticOre3, (int)2, (int)0);




            //ore = (Ore)this.gridManager.getStructure((int)1, (int)1);










            Load = true;
        }
    }
}
