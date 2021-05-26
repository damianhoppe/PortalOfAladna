using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenTankBarricade : WoodenBarricade
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Wooden Tank Barricade";
        this.ObjectDescription = "This is a wooden tank barricade, with increased HP and some attack.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Wooden Tank Barricade";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = base.MaxHitpoints * 1.5f;
        this.Protection = base.Protection + 5.0f;
        this.Armor = base.Armor + 2.0f;

        this.PositionObstacle = base.PositionObstacle + 1.0f;
        this.PositionDanger = base.PositionDanger + 1.0f;

        this.AttackRange.radius = 1.0f;
        this.TowerBulletDamage = 7.5f;
        this.TowerBulletSpeed = 0.1f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;

        this.TowerBulletSize = 0.4f;

        this.BaseCost = new DataStructures.Cost(50.0f, 50.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 103;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.SightRange = 1.0f;

        this.canAttack = true;
        this.RequiresAccess = true;
        this.CurrentHitpoints = this.MaxHitpoints;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    WoodenTankBarricade()
    {
        this.ObjectName = "Wooden Tank Barricade";
        this.ObjectDescription = "This is a wooden tank barricade, with increased HP and some attack.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Wooden Tank Barricade";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = base.MaxHitpoints * 1.5f;
        this.Protection = base.Protection + 5.0f;
        this.Armor = base.Armor + 2.0f;

        this.PositionObstacle = base.PositionObstacle + 1.0f;
        this.PositionDanger = base.PositionDanger + 1.0f;

        this.AttackRange.radius = 1.0f;
        this.TowerBulletDamage = 7.5f;
        this.TowerBulletSpeed = 0.1f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;

        this.TowerBulletSize = 0.4f;

        this.BaseCost = new DataStructures.Cost(50.0f, 50.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 103;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.SightRange = 1.0f;

        this.canAttack = true;
        this.RequiresAccess = true;
        this.CurrentHitpoints = this.MaxHitpoints;
    }
}
