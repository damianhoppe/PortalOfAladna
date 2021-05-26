using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTankBarricade : MagicBarricade
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Magic Tank Barricade";
        this.ObjectDescription = "This is a magic tank barricade, with increased HP and some attack.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Magic Tank Barricade";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = base.MaxHitpoints * 2.0f;
        this.Protection = base.Protection + 7.5f;
        this.Armor = base.Armor + 3.0f;

        this.PositionObstacle = base.PositionObstacle + 3.0f;
        this.PositionDanger = base.PositionDanger + 2.0f;

        this.AttackRange.radius = 1.5f;
        this.TowerBulletDamage = 25.0f;
        this.TowerBulletSpeed = 0.1f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;

        this.TowerBulletSize = 0.4f;

        this.BaseCost = new DataStructures.Cost(200.0f, 00.0f, 0.0f, 0.0f, 50.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 106;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.SightRange = 1.5f;

        this.canAttack = true;
        this.RequiresAccess = true;
        this.CurrentHitpoints = this.MaxHitpoints;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    MagicTankBarricade()
    {
        this.ObjectName = "Magic Tank Barricade";
        this.ObjectDescription = "This is a magic tank barricade, with increased HP and some attack.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Magic Tank Barricade";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = base.MaxHitpoints * 2.0f;
        this.Protection = base.Protection + 7.5f;
        this.Armor = base.Armor + 3.0f;

        this.PositionObstacle = base.PositionObstacle + 3.0f;
        this.PositionDanger = base.PositionDanger + 2.0f;

        //this.AttackRange.radius = 1.5f;
        this.TowerBulletDamage = 25.0f;
        this.TowerBulletSpeed = 0.1f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        //this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;

        this.TowerBulletSize = 0.4f;

        this.BaseCost = new DataStructures.Cost(200.0f, 00.0f, 0.0f, 0.0f, 50.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 106;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.SightRange = 1.5f;

        this.canAttack = true;
        this.RequiresAccess = true;
        this.CurrentHitpoints = this.MaxHitpoints;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
    }
}
