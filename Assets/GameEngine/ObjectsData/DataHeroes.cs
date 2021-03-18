using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHeroes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public class DefaultTroop : DataTroops.DefaultTroop
    {
        public new string ObjectName { get; protected set; } = "Default Hero";
        public new string ObjectDescription { get; protected set; } = "Default Hero Description";
        public new string ObjectType { get; protected set; } = "Hero";
        public new int ObjectTypeID { get; protected set; } = 7;


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
