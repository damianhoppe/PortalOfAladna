using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMines : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public class DefaultMine : DataSpecialObjects.DefaultObject
    {
        public new string ObjectName { get; protected set; } = "Default Mine";
        public new string ObjectDescription { get; protected set; } = "Default Mine Description";
        public new string ObjectType { get; protected set; } = "Mine";
        public new int ObjectTypeID { get; protected set; } = 3;

        public new bool IsFriendly { get; protected set; } = true;
        public new bool CanSelect { get; protected set; } = true;
        public new bool IsAlive { get; protected set; } = true;
        public new bool CanDie { get; protected set; } = true;

        public bool CanBuild { get; protected set; } = false;
        public bool CanUpgrade { get; protected set; } = false;
        public bool CanRepair { get; protected set; } = false;
        public bool CanSell { get; protected set; } = false;

        public bool HasEnergy { get; protected set; } = false;
        public bool HasAbilities { get; protected set; } = false;
        public bool HasHealth { get; protected set; } = true;

        public float MaxHitpoints { get; protected set; } = 100.0f;
        public float CurrentHitpoints { get; protected set; }
        public float Armor { get; protected set; } = 0.0f;
        public float Protection { get; protected set; } = 0.0f;

        public override bool OnSelect()
        {
            return base.OnSelect();
        }
        public override bool OnDeath()
        {
            return base.OnDeath();
        }
    }
}
