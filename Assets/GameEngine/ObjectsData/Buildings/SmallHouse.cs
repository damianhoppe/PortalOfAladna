using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallHouse : DefaultBuilding
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

    public override string ObjectName { get; protected set; } = "Small House";
    public override string ObjectDescription { get; protected set; } = "This is a small house for 5 people.";
    public override string ObjectType { get; protected set; } = "Building";
    public override int ObjectTypeID { get; protected set; } = 1;
    public override string ObjectSubtype { get; protected set; } = "Default Small House";
    public override int ObjectSubtypeID { get; protected set; } = 1;

    public override float MaxHitpoints { get; protected set; } = 50.0f;
    public override bool ActiveAtNight { get; protected set; } = true;

    public override float EnergyToBuild { get; protected set; } = 10.0f;

    public override float PositionValue { get; protected set; } = 2.0f;
    public override float PositionObstacle { get; protected set; } = 1.0f;

}
