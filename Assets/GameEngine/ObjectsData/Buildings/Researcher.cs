using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Researcher : DefaultBuilding
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.RequiresInventor = true;

        this.ObjectName = "Researcher";
        this.ObjectDescription = "This is a Researcher. Allows extraction of crystal and unlocks crystal buildings.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Researcher";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 1500.0f;
        this.Armor = 5.0f;
        this.Protection = 10.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 8.0f;
        this.PositionObstacle = 6.0f;
        this.PositionDanger = 6.0f;

        this.BaseCost = new DataStructures.Cost(1500.0f, 400.0f, 300.0f, 150.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 75.0f;
        this.PlayerObjectID = 29;
        this.RequiredHumans = 50;
        this.CurrentHitpoints = this.MaxHitpoints;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public Researcher()
    {
        this.RequiresInventor = true;

        this.ObjectName = "Researcher";
        this.ObjectDescription = "This is a Researcher. Allows extraction of crystal and unlocks crystal buildings.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Researcher";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 1500.0f;
        this.Armor = 5.0f;
        this.Protection = 10.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 8.0f;
        this.PositionObstacle = 6.0f;
        this.PositionDanger = 6.0f;

        this.BaseCost = new DataStructures.Cost(1500.0f, 400.0f, 300.0f, 150.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 75.0f;
        this.PlayerObjectID = 29;
        this.RequiredHumans = 50;
    }
    public override void onCreate()
    {

        this.UC.ResearcherBuilt();
        base.onCreate();
    }
    public override void onDestroy()
    {
        if (this.DestroyAvailable())
        {
            this.UC.ResearcherDestroyed();
            base.onDestroy();
        }
    }
    public override void onSell()
    {
        if (this.SellAvailable())
        {
            this.UC.ResearcherDestroyed();
            base.onSell();
        }
    }
}
