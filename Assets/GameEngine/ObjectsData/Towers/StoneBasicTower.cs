using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBasicTower : WoodenBasicTower
{
    //CircleCollider2D AttackRange;


    // Start is called before the first frame update
    protected override void Start()
    {

        base.Start();

        this.ObjectName = "Stone Basic Tower";
        this.ObjectDescription = "This is a stone basic tower, with default attack.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Stone Basic Tower";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 200.0f;
        this.Armor = 2.0f;
        this.Protection = 7.0f;

        this.SightRange = 3.5f;
        this.ActiveAtNight = true;

        this.PositionValue = 0.0f;
        this.PositionObstacle = 1.5f;
        this.PositionDanger = 2.5f;

        this.AttackRange.radius = 3.5f;
        this.TowerBulletDamage = 15.0f;
        this.TowerBulletSpeed = 0.025f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;


        this.TowerBulletSize = 1.0f;

        this.canAttack = true;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.BaseCost = new DataStructures.Cost(125.0f, 25.0f, 50.0f, 5.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 10;

        this.PlayerObjectID = 76;

        this.RequiresAccess = false;

        this.CurrentHitpoints = this.MaxHitpoints;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public StoneBasicTower()
    {
        this.ObjectName = "Stone Basic Tower";
        this.ObjectDescription = "This is a stone basic tower, with default attack.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Stone Basic Tower";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 200.0f;
        this.Armor = 2.0f;
        this.Protection = 7.0f;

        this.SightRange = 3.5f;
        this.ActiveAtNight = true;

        this.PositionValue = 0.0f;
        this.PositionObstacle = 1.5f;
        this.PositionDanger = 2.5f;

        //this.AttackRange.radius = 3.5f;
        this.TowerBulletDamage = 15.0f;
        this.TowerBulletSpeed = 0.025f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        //this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;


        this.TowerBulletSize = 1.0f;

        this.canAttack = true;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.BaseCost = new DataStructures.Cost(125.0f, 25.0f, 50.0f, 5.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 10;

        this.PlayerObjectID = 76;

        this.RequiresAccess = false;

        this.CurrentHitpoints = this.MaxHitpoints;
    }
}
