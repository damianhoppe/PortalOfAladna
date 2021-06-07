using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Template1 : MonoBehaviour
{

    bool Load = false;


    [SerializeField]
    public List<DefaultResource> DefaultResource;

    public List<DefaultBuilding> DefaultBuilding;

    public SpriteRenderer oreReqSprite;

    public GameObject SmallShallowWood, SmallShallowGold, SmallShallowStone, SmallShallowCrystal, SmallShallowMetal, MediumDeepWood, MediumDeepGold, MediumDeepStone, MediumDeepCrystal, MediumDeepMetal, PortalPrefab;
    private GridManager gridManager;
    public DefaultResource ore;
    public DefaultBuilding portal;


    void Start()
    {
        this.gridManager = FindObjectOfType<GridManager>();
        this.oreReqSprite = gameObject.GetComponent<SpriteRenderer>();
        foreach (Transform child in transform)
        {
            GameObject gameObject = child.gameObject;
            Structure structure = gameObject.GetComponent<Structure>();
            Position structPos = new Position(structure.transform.position);
            structure.setPosition(structPos);
            gameObject.name = structure.getName();
            gridManager.addStructure(structure, (int)structPos.x, (int)structPos.y);
        }
    }
    /*
    void Update()
    {
        if (Load == false)
        {
            GameObject OreObject1 = Instantiate(SmallShallowWood);
            DefaultResource smallWood = OreObject1.GetComponent<DefaultResource>();

            GameObject OreObject2 = Instantiate(SmallShallowGold);
            DefaultResource smallGold = OreObject2.GetComponent<DefaultResource>();

            GameObject OreObject3 = Instantiate(SmallShallowStone);
            DefaultResource smallStone = OreObject3.GetComponent<DefaultResource>();

            GameObject OreObject4 = Instantiate(SmallShallowCrystal);
            DefaultResource smallCrystal = OreObject4.GetComponent<DefaultResource>();

            GameObject OreObject5 = Instantiate(SmallShallowMetal);
            DefaultResource smallMetal = OreObject5.GetComponent<DefaultResource>();

            GameObject OreObject6 = Instantiate(MediumDeepWood);
            DefaultResource mediumWood = OreObject6.GetComponent<DefaultResource>();

            GameObject OreObject7 = Instantiate(MediumDeepGold);
            DefaultResource mediumGold = OreObject7.GetComponent<DefaultResource>();

            GameObject OreObject8 = Instantiate(MediumDeepStone);
            DefaultResource mediumStone = OreObject8.GetComponent<DefaultResource>();

            GameObject OreObject9 = Instantiate(MediumDeepCrystal);
            DefaultResource mediumCrystal = OreObject9.GetComponent<DefaultResource>();

            GameObject OreObject10 = Instantiate(MediumDeepMetal);
            DefaultResource mediumMetal = OreObject10.GetComponent<DefaultResource>();

            GameObject PortalObject = Instantiate(PortalPrefab);
            DefaultBuilding Portal = PortalObject.GetComponent<DefaultBuilding>();


            gridManager.addStructure((Structure)smallWood, (int)1, (int)1);

            gridManager.addStructure((Structure)smallGold, (int)-1, (int)4);

            gridManager.addStructure((Structure)smallStone, (int)-3, (int)-2);

            gridManager.addStructure((Structure)smallCrystal, (int)2, (int)-5);

            gridManager.addStructure((Structure)smallMetal, (int)-2, (int)0);

            gridManager.addStructure((Structure)mediumWood, (int)9, (int)9);

            gridManager.addStructure((Structure)mediumGold, (int)14, (int)15);

            gridManager.addStructure((Structure)mediumStone, (int)-11, (int)-7);

            gridManager.addStructure((Structure)mediumCrystal, (int)-25, (int)-2);

            gridManager.addStructure((Structure)mediumMetal, (int)11, (int)-13);

            gridManager.addStructure((Structure)Portal, (int)1, (int)-1);

            Load = true;
        }
    }*/
}
