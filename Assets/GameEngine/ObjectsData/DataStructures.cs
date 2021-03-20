using System.Collections;
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

        public Cost(float G, float W, float S, float M, float C, float H)
        {
            this.Gold = G;
            this.Wood = W;
            this.Stone = S;
            this.Metal = M;
            this.Crystals = C;
            this.Humans = H;
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
    }
}
