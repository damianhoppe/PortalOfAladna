using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public class DefaultEnemy : DataSpecialObjects.DefaultObject
    {
        public new string ObjectName { get; protected set; } = "Default Enemy";
        public new string ObjectDescription { get; protected set; } = "Default Enemy Description";
        public new string ObjectType { get; protected set; } = "Enemy";
        public new int ObjectTypeID { get; protected set; } = 4;

        public new bool IsHostile { get; protected set; } = true;
        public new bool CanSelect { get; protected set; } = true;
        public new bool IsAlive { get; protected set; } = true;
        public new bool CanDie { get; protected set; } = true;

        public bool CanSpawn { get; protected set; } = false;
        public bool CanDespawn { get; protected set; } = false;

        public bool HasEnergy { get; protected set; } = false;
        public bool HasAbilities { get; protected set; } = false;
        public bool HasHealth { get; protected set; } = true;

        public double MaxHitpoints { get; protected set; } = 100.0;
        public double CurrentHitpoints { get; protected set; }
        public double Armor { get; protected set; } = 0.0;
        public double Protection { get; protected set; } = 0.0;

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
