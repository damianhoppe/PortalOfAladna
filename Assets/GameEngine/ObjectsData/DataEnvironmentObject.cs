using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataEnvironmentObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public class DefaultEnvironmentObject : DataSpecialObjects.DefaultObject
    {
        public new string ObjectName { get; protected set; } = "Default Environment Object";
        public new string ObjectDescription { get; protected set; } = "Default Environment Object Description";
        public new string ObjectType { get; protected set; } = "Environment Object";
        public new int ObjectTypeID { get; protected set; } = 8;

        public new bool CanSelect { get; protected set; } = true;


        public override bool OnSelect()
        {
            return base.OnSelect();
        }
    }
}
