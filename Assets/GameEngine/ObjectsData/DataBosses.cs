using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBosses : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public class DefaultBoss : DataEnemies.DefaultEnemy
    {
        public new string ObjectName { get; protected set; } = "Default Boss";
        public new string ObjectDescription { get; protected set; } = "Default Boss Description";
        public new string ObjectType { get; protected set; } = "Boss";
        public new int ObjectTypeID { get; protected set; } = 5;
        
        
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
