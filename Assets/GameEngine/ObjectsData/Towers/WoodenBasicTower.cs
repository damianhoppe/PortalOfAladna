using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBasicTower : defaultTower
{
    //CircleCollider2D AttackRange;
    

    // Start is called before the first frame update
    protected override void Start()
    {

        base.Start();

        this.ObjectName = "Wooden Basic Tower";
        this.ObjectDescription = "This is a wooden basic tower, with default attack.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Wooden Basic Tower";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 100.0f;
        this.Armor = 1.0f;
        this.Protection = 5.0f;

        this.SightRange = 3.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 0.0f;
        this.PositionObstacle = 1.0f;
        this.PositionDanger = 2.0f;

        this.AttackRange.radius = 3.0f;
        this.TowerBulletDamage = 10.0f;
        this.TowerBulletSpeed = 0.025f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;
        

        this.TowerBulletSize = 1.0f;

        this.canAttack = true;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.BaseCost = new DataStructures.Cost(50.0f, 25.0f, 5.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 75;

        this.RequiresAccess = false;

        this.CurrentHitpoints = this.MaxHitpoints;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public WoodenBasicTower()
    {
        this.PlayerObjectID = 75;

        this.ObjectName = "Wooden Basic Tower";
        this.ObjectDescription = "This is a wooden basic tower, with default attack.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Wooden Basic Tower";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 100.0f;
        this.Armor = 1.0f;
        this.Protection = 5.0f;

        this.SightRange = 3.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 0.0f;
        this.PositionObstacle = 1.0f;
        this.PositionDanger = 2.0f;

        this.AttackRange.radius = 3.0f;
        this.TowerBulletDamage = 10.0f;
        this.TowerBulletSpeed = 0.025f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;


        this.TowerBulletSize = 1.0f;

        this.canAttack = true;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.BaseCost = new DataStructures.Cost(50.0f, 25.0f, 5.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 75;

        this.RequiresAccess = false;

        this.CurrentHitpoints = this.MaxHitpoints;
    }
}
