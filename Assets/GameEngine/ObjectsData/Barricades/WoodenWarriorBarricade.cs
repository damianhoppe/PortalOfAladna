using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenWarriorBarricade : WoodenBarricade
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Wooden Warrior Barricade";
        this.ObjectDescription = "This is a wooden warrior barricade, with increased attack.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Wooden Warrior Barricade";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.PositionObstacle = base.PositionObstacle + 0.75f;
        this.PositionDanger = base.PositionDanger + 1.25f;

        this.AttackRange.radius = 1.0f;
        this.TowerBulletDamage = 15.0f;
        this.TowerBulletSpeed = 0.1f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;

        this.TowerBulletSize = 0.4f;

        this.BaseCost = new DataStructures.Cost(50.0f, 50.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 107;

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
    WoodenWarriorBarricade()
    {

        this.ObjectName = "Wooden Warrior Barricade";
        this.ObjectDescription = "This is a wooden warrior barricade, with increased attack.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Wooden Warrior Barricade";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.PositionObstacle = base.PositionObstacle + 0.5f;
        this.PositionDanger = base.PositionDanger + 1.5f;

        //this.AttackRange.radius = 1.0f;
        this.TowerBulletDamage = 15.0f;
        this.TowerBulletSpeed = 0.1f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        //this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;

        this.TowerBulletSize = 0.4f;

        this.BaseCost = new DataStructures.Cost(50.0f, 50.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 107;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.SightRange = 1.0f;

        this.canAttack = true;
        this.RequiresAccess = true;
        this.CurrentHitpoints = this.MaxHitpoints;
    }
}
