using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBank : DefaultBuilding
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

    public override string ObjectName { get; protected set; } = "Small Bank";
    public override string ObjectDescription { get; protected set; } = "This is bank. You can store gold here.";
    public override string ObjectType { get; protected set; } = "Building";
    public override int ObjectTypeID { get; protected set; } = 1;
    public override string ObjectSubtype { get; protected set; } = "Small Default Bank";
    public override int ObjectSubtypeID { get; protected set; } = 3;

    public override float MaxHitpoints { get; protected set; } = 200.0f;
    public override DataStructures.Cost BuildingStorage { get; protected set; } = new DataStructures.Cost(200.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);

    public override float EnergyToBuild { get; protected set; } = 20.0f;

    public override float PositionValue { get; protected set; } = 4.0f;
    public override float PositionObstacle { get; protected set; } = 2.0f;

    public virtual bool StoreResources(DataStructures.Cost StoredResources)
    {
        if (DataStructures.Cost.IsLesser(StoredResources+this.ResourcesInside,this.BuildingStorage))
        {
            this.ResourcesInside += StoredResources;
            return true;
        }
        else return false;
    }
    public virtual bool TakeResources(DataStructures.Cost TakenResources)
    {
        if (DataStructures.Cost.IsLesser(TakenResources, this.ResourcesInside))
        {
            this.ResourcesInside -= TakenResources;
            return true;
        }
        else return false;
    }
}
