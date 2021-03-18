using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSpecialObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public class DefaultObject
    {
        public string ObjectName { get; protected set; } = "Default object";
        public string ObjectDescription { get; protected set; } = "Default object description";
        public string ObjectType { get; protected set; } = "Special";
        public int ObjectTypeID { get; protected set; } = 0;
        public string ObjectSubtype { get; protected set; } = "Default";
        public int ObjectSubtypeID { get; protected set; } = 0;

        public bool IsFriendly { get; protected set; } = false;
        public bool IsHostile { get; protected set; } = false;
        public bool CanSelect { get; protected set; } = false;
        public bool IsAlive { get; protected set; } = false;
        public bool IsDead { get; protected set; } = false;
        public bool CanDie { get; protected set; } = false;
        
        public virtual bool OnSelect()
        {
            if (CanSelect) { return true; }
            else { return false; }
        }
        public virtual bool OnDeath()
        {
            if (IsDead) return false;
            if (CanDie)
            {
                IsAlive = false;
                IsDead = true;
                return true;
            }
            else return false;
        }
    }
}
