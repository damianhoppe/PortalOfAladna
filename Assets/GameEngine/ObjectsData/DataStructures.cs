﻿using System.Collections;
using System.Collections.Generic;
//using System.Math;
using UnityEngine;

public class DataStructures : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public class Cost
    {
        public float Gold { get; protected set; } = 0.0f;
        public float Wood { get; protected set; } = 0.0f;
        public float Stone { get; protected set; } = 0.0f;
        public float Metal { get; protected set; } = 0.0f;
        public float Crystals { get; protected set; } = 0.0f;
        public float Humans { get; protected set; } = 0.0f;

        public Cost()
        {
            this.Gold = 0.0f; 
            this.Wood = 0.0f; 
            this.Stone = 0.0f;
            this.Metal = 0.0f;
            this.Crystals = 0.0f;
            this.Humans = 0.0f;
        }
        public Cost(int G, int W, int S, int M, int C, int H)
        {
            this.Gold = (float)G;
            this.Wood = (float)W;
            this.Stone = (float)S;
            this.Metal = (float)M;
            this.Crystals = (float)C;
            this.Humans = (float)H;
        }
        public Cost(float G, float W, float S, float M, float C, float H)
        {
            this.Gold = G;
            this.Wood = W;
            this.Stone = S;
            this.Metal = M;
            this.Crystals = C;
            this.Humans = H;
        }

        public static Cost operator +(Cost a, Cost b)
        {
            return new Cost(
                a.Gold + b.Gold,
                a.Wood+b.Wood,
                a.Stone+b.Stone,
                a.Metal+b.Metal,
                a.Crystals+b.Crystals,
                a.Humans+b.Humans
                );
        }
        public static Cost operator -(Cost a, Cost b)
        {
            return new Cost(
                a.Gold - b.Gold,
                a.Wood - b.Wood,
                a.Stone - b.Stone,
                a.Metal - b.Metal,
                a.Crystals - b.Crystals,
                a.Humans - b.Humans
                );
        }
        public static Cost operator *(Cost a,float f)
        {

            return new Cost(
                a.Gold * f,
                a.Wood * f,
                a.Stone * f,
                a.Metal * f,
                a.Crystals * f,
                a.Humans*f
                );
        }
        public static bool IsGreater(Cost a, Cost b)
        {
            if (a.Gold < b.Gold || a.Wood < b.Wood || a.Stone < b.Stone || a.Metal < b.Metal || a.Crystals < b.Crystals) return false;
            else return true;
        }
        public static bool IsLesser(Cost a, Cost b)
        {
            if (a.Gold > b.Gold || a.Wood > b.Wood || a.Stone > b.Stone || a.Metal > b.Metal || a.Crystals > b.Crystals) return false;
            else return true;
        }
        public void RoundUpAll()
        {
            this.Gold = Mathf.Ceil(this.Gold);
            this.Wood = Mathf.Ceil(this.Wood);
            this.Stone = Mathf.Ceil(this.Stone);
            this.Metal = Mathf.Ceil(this.Metal);
            this.Crystals = Mathf.Ceil(this.Crystals);
            this.Humans = Mathf.Ceil(this.Humans);
            return;
        }
        public void RoundDownAll()
        {
            this.Gold = Mathf.Floor(this.Gold);
            this.Wood = Mathf.Floor(this.Wood);
            this.Stone = Mathf.Floor(this.Stone);
            this.Metal = Mathf.Floor(this.Metal);
            this.Crystals = Mathf.Floor(this.Crystals);
            this.Humans = Mathf.Floor(this.Humans);
        }
        public double[] ToArray()
        {
            double[] CostArray = new double[6];
            CostArray[0] = this.Gold;
            CostArray[1] = this.Wood;
            CostArray[2] = this.Stone;
            CostArray[3] = this.Metal;
            CostArray[4] = this.Crystals;
            CostArray[5] = this.Humans;
            return CostArray;
        }
        public new string ToString()
        {
            string CostString = "";
            CostString += "Gold:" + this.Gold.ToString() +";";
            CostString += "Wood:" + this.Wood.ToString() + ";";
            CostString += "Stone:" + this.Stone.ToString() + ";";
            CostString += "Metal:" + this.Metal.ToString() + ";";
            CostString += "Crystals:" + this.Crystals.ToString() + ";";
            CostString += "Humans:" + this.Humans.ToString() + ";";
            return CostString;
        }
        public static Cost ChangeGold(Cost koszt,float gold)
        {
            koszt.Gold += gold;
            return koszt;
        }
        public static Cost ChangeWood(Cost koszt, float wood)
        {
            koszt.Wood += wood;
            return koszt;
        }
        public static Cost ChangeStone(Cost koszt, float stone)
        {
            koszt.Stone += stone;
            return koszt;
        }
        public static Cost ChangeMetal(Cost koszt, float metal)
        {
            koszt.Metal += metal;
            return koszt;
        }
        public static Cost ChangeCrystal(Cost koszt, float crystal)
        {
            koszt.Crystals += crystal;
            return koszt;
        }
        public static Cost ChangeHumans(Cost koszt, float humans)
        {
            koszt.Humans += humans;
            return koszt;
        }
        public static Cost ChangeGold(Cost koszt, int gold)
        {
            koszt.Gold += (float)gold;
            return koszt;
        }
        public static Cost ChangeWood(Cost koszt, int wood)
        {
            koszt.Wood += (float)wood;
            return koszt;
        }
        public static Cost ChangeStone(Cost koszt, int stone)
        {
            koszt.Stone += (float)stone;
            return koszt;
        }
        public static Cost ChangeMetal(Cost koszt, int metal)
        {
            koszt.Metal += (float)metal;
            return koszt;
        }
        public static Cost ChangeCrystal(Cost koszt, int crystal)
        {
            koszt.Crystals += (float)crystal;
            return koszt;
        }
        public static Cost ChangeHumans(Cost koszt, int humans)
        {
            koszt.Humans += (float)humans;
            return koszt;
        }
    }
}
