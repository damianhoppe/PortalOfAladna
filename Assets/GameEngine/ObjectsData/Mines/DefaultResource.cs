using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultResource : Structure
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public DefaultResource() : base(EStructureType.Ore) { }
    public DataStructures.Cost Mine()
    {
        return new DataStructures.Cost();
    }
}
