using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneRapidTower : WoodenRapidTower
{
    //CircleCollider2D AttackRange;


    // Start is called before the first frame update
    protected override void Start()
    {

        base.Start();

        this.ObjectName = "Stone Rapid Tower";
        this.ObjectDescription = "This is a stone rapid tower, with fast attack speed.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Stone Rapid Tower";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 300.0f;
        this.Armor = 3.0f;
        this.Protection = 10.0f;

        this.SightRange = 3.5f;
        this.ActiveAtNight = true;

        this.PositionValue = 0.0f;
        this.PositionObstacle = 2.0f;
        this.PositionDanger = 4.0f;

        this.AttackRange.radius = 3.0f;
        this.TowerBulletDamage = 15.0f;
        this.TowerBulletSpeed = 0.05f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;


        this.TowerBulletSize = 0.5f;

        this.canAttack = true;

        this.attackSpeed = 100;
        this.attackReady = 0;

        this.BaseCost = new DataStructures.Cost(250.0f, 40.0f, 60.0f, 20.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 15.0f;
        this.RequiredHumans = 10;

        this.PlayerObjectID = 88;

        this.RequiresAccess = false;

        this.CurrentHitpoints = this.MaxHitpoints;
        this.RequiresInventor = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public StoneRapidTower()
    {
        this.ObjectName = "Stone Rapid Tower";
        this.ObjectDescription = "This is a stone rapid tower, with fast attack speed.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Stone Rapid Tower";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 300.0f;
        this.Armor = 3.0f;
        this.Protection = 10.0f;

        this.SightRange = 3.5f;
        this.ActiveAtNight = true;

        this.PositionValue = 0.0f;
        this.PositionObstacle = 2.0f;
        this.PositionDanger = 4.0f;

        //this.AttackRange.radius = 3.0f;
        this.TowerBulletDamage = 15.0f;
        this.TowerBulletSpeed = 0.05f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        //this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;


        this.TowerBulletSize = 0.5f;

        this.canAttack = true;

        this.attackSpeed = 100;
        this.attackReady = 0;

        this.BaseCost = new DataStructures.Cost(250.0f, 40.0f, 60.0f, 20.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 15.0f;
        this.RequiredHumans = 10;

        this.PlayerObjectID = 88;

        this.RequiresAccess = false;

        this.CurrentHitpoints = this.MaxHitpoints;
        this.RequiresInventor = true;
    }
}
