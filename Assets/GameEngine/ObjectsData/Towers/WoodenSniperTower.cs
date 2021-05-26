using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenSniperTower : defaultTower
{
    //CircleCollider2D AttackRange;


    // Start is called before the first frame update
    protected override void Start()
    {

        base.Start();

        this.ObjectName = "Wooden Sniper Tower";
        this.ObjectDescription = "This is a wooden sniper tower, with long range.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Wooden Sniper Tower";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 150.0f;
        this.Armor = 1.5f;
        this.Protection = 7.5f;

        this.SightRange = 4.5f;
        this.ActiveAtNight = true;

        this.PositionValue = 0.0f;
        this.PositionObstacle = 1.0f;
        this.PositionDanger = 3.0f;

        this.AttackRange.radius = 4.5f;
        this.TowerBulletDamage = 15.0f;
        this.TowerBulletSpeed = 0.0375f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;


        this.TowerBulletSize = 0.75f;

        this.canAttack = true;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.BaseCost = new DataStructures.Cost(100.0f, 40.0f, 20.0f, 5.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 15.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 83;

        this.RequiresAccess = false;

        this.CurrentHitpoints = this.MaxHitpoints;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public WoodenSniperTower()
    {
        this.ObjectName = "Wooden Sniper Tower";
        this.ObjectDescription = "This is a wooden sno[er tower, with long range.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Wooden Sniper Tower";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 150.0f;
        this.Armor = 1.5f;
        this.Protection = 7.5f;

        this.SightRange = 4.5f;
        this.ActiveAtNight = true;

        this.PositionValue = 0.0f;
        this.PositionObstacle = 1.0f;
        this.PositionDanger = 3.0f;

        this.AttackRange.radius = 4.5f;
        this.TowerBulletDamage = 10.0f;
        this.TowerBulletSpeed = 0.0375f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;


        this.TowerBulletSize = 0.75f;

        this.canAttack = true;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.BaseCost = new DataStructures.Cost(100.0f, 40.0f, 20.0f, 5.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 15.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 83;

        this.RequiresAccess = false;

        this.CurrentHitpoints = this.MaxHitpoints;
    }
}
