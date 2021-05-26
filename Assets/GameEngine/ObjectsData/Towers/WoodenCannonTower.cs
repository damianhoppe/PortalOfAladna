using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenCannonTower : defaultTower
{
    //CircleCollider2D AttackRange;


    // Start is called before the first frame update
    protected override void Start()
    {

        base.Start();

        this.ObjectName = "Wooden Cannon Tower";
        this.ObjectDescription = "This is a wooden cannon tower, with heavy attack.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Wooden cannon Tower";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 150.0f;
        this.Armor = 1.5f;
        this.Protection = 7.5f;

        this.SightRange = 3.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 0.0f;
        this.PositionObstacle = 1.0f;
        this.PositionDanger = 3.0f;

        this.AttackRange.radius = 3.0f;
        this.TowerBulletDamage = 35.0f;
        this.TowerBulletSpeed = 0.015f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;


        this.TowerBulletSize = 1.5f;

        this.canAttack = true;

        this.attackSpeed = 300;
        this.attackReady = 0;

        this.BaseCost = new DataStructures.Cost(100.0f, 40.0f, 20.0f, 5.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 15.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 79;

        this.RequiresAccess = false;

        this.CurrentHitpoints = this.MaxHitpoints;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public WoodenCannonTower()
    {
        this.ObjectName = "Wooden Cannon Tower";
        this.ObjectDescription = "This is a wooden cannon tower, with heavy attack.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Wooden cannon Tower";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 150.0f;
        this.Armor = 1.5f;
        this.Protection = 7.5f;

        this.SightRange = 3.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 0.0f;
        this.PositionObstacle = 1.0f;
        this.PositionDanger = 3.0f;

        //this.AttackRange.radius = 3.0f;
        this.TowerBulletDamage = 35.0f;
        this.TowerBulletSpeed = 0.015f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        //this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;


        this.TowerBulletSize = 1.5f;

        this.canAttack = true;

        this.attackSpeed = 300;
        this.attackReady = 0;

        this.BaseCost = new DataStructures.Cost(100.0f, 40.0f, 20.0f, 5.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 15.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 79;

        this.RequiresAccess = false;

        this.CurrentHitpoints = this.MaxHitpoints;
    }
}
