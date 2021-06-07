using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Template3 : MonoBehaviour
{

    bool Load = false;


    [SerializeField]
    public List<DefaultResource> DefaultResource;

    public List<DefaultBuilding> DefaultBuilding;

    public SpriteRenderer oreReqSprite;

    public GameObject SmallDeepCrystal, MediumShallowGold, LargeDeepStone, LargeShallowMetal, LargeShallowWood, SmallShallowWood, SmallShallowGold, SmallShallowStone, SmallShallowCrystal, SmallShallowMetal, MediumDeepWood, MediumDeepGold, MediumDeepStone, MediumDeepCrystal, MediumDeepMetal, PortalPrefab;
    private GridManager gridManager;
    public DefaultResource ore;
    public DefaultBuilding portal;


    void Start()
    {
        this.gridManager = FindObjectOfType<GridManager>();
        this.oreReqSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Load == false)
        {
            //dodatkowe surowce

            GameObject OreObject11 = Instantiate(SmallDeepCrystal);
            DefaultResource smallCrystalDeep= OreObject11.GetComponent<DefaultResource>();

            GameObject OreObject12 = Instantiate(MediumShallowGold);
            DefaultResource mediumGoldShallow = OreObject12.GetComponent<DefaultResource>();

            GameObject OreObject13 = Instantiate(LargeDeepStone);
            DefaultResource largeStone = OreObject13.GetComponent<DefaultResource>();

            GameObject OreObject14 = Instantiate(LargeShallowMetal);
            DefaultResource largeMetal = OreObject14.GetComponent<DefaultResource>();

            GameObject OreObject15 = Instantiate(LargeShallowWood);
            DefaultResource largeWood = OreObject15.GetComponent<DefaultResource>();

            //domyslne surowce

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


            gridManager.addStructure((Structure)smallWood, (int)-4, (int)2);

            gridManager.addStructure((Structure)smallGold, (int)0, (int)-2);

            gridManager.addStructure((Structure)smallStone, (int)-7, (int)-1);

            gridManager.addStructure((Structure)smallCrystal, (int)0, (int)0);

            gridManager.addStructure((Structure)smallMetal, (int)0, (int)2);

            gridManager.addStructure((Structure)mediumWood, (int)-17, (int)7);

            gridManager.addStructure((Structure)mediumGold, (int)-5, (int)22);

            gridManager.addStructure((Structure)mediumStone, (int)20, (int)0);

            gridManager.addStructure((Structure)mediumCrystal, (int)12, (int)-12);

            gridManager.addStructure((Structure)mediumMetal, (int)10, (int)10);

            gridManager.addStructure((Structure)Portal, (int)-5, (int)0);

            //dodatkowe

            gridManager.addStructure((Structure)smallCrystalDeep, (int)7, (int)-8);

            gridManager.addStructure((Structure)mediumGoldShallow, (int)-22, (int)-5);

            gridManager.addStructure((Structure)largeStone, (int)-2, (int)-18);

            gridManager.addStructure((Structure)largeMetal, (int)25, (int)9);

            gridManager.addStructure((Structure)largeWood, (int)-13, (int)-14);

            Load = true;
        }
    }
}
