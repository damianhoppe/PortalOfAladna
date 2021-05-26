using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalRapidTower : StoneRapidTower
{
    //CircleCollider2D AttackRange;


    // Start is called before the first frame update
    protected override void Start()
    {

        base.Start();

        this.ObjectName = "Metal Rapid Tower";
        this.ObjectDescription = "This is a metal rapid tower, with fast attack speed.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Metal Rapid Tower";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 500.0f;
        this.Armor = 5.0f;
        this.Protection = 12.0f;

        this.SightRange = 4.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 0.5f;
        this.PositionObstacle = 2.5f;
        this.PositionDanger = 4.5f;

        this.AttackRange.radius = 4.0f;
        this.TowerBulletDamage = 25.0f;
        this.TowerBulletSpeed = 0.05f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;


        this.TowerBulletSize = 0.5f;

        this.canAttack = true;

        this.attackSpeed = 100;
        this.attackReady = 0;

        this.BaseCost = new DataStructures.Cost(600.0f, 50.0f, 50.0f, 60.0f, 5.0f, 0.0f);
        this.EnergyToBuild = 15.0f;
        this.RequiredHumans = 15;

        this.PlayerObjectID = 89;

        this.RequiresAccess = false;

        this.CurrentHitpoints = this.MaxHitpoints;
        this.RequiresInventor = true;
        this.RequiresResearcher = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public MetalRapidTower()
    {
        this.ObjectName = "Metal Rapid Tower";
        this.ObjectDescription = "This is a metal rapid tower, with fast attack speed.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Metal Rapid Tower";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 500.0f;
        this.Armor = 5.0f;
        this.Protection = 12.0f;

        this.SightRange = 4.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 0.5f;
        this.PositionObstacle = 2.5f;
        this.PositionDanger = 4.5f;

        //this.AttackRange.radius = 4.0f;
        this.TowerBulletDamage = 25.0f;
        this.TowerBulletSpeed = 0.05f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        //this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;


        this.TowerBulletSize = 0.5f;

        this.canAttack = true;

        this.attackSpeed = 100;
        this.attackReady = 0;

        this.BaseCost = new DataStructures.Cost(600.0f, 50.0f, 50.0f, 60.0f, 5.0f, 0.0f);
        this.EnergyToBuild = 15.0f;
        this.RequiredHumans = 15;

        this.PlayerObjectID = 89;

        this.RequiresAccess = false;

        this.CurrentHitpoints = this.MaxHitpoints;
        this.RequiresInventor = true;
        this.RequiresResearcher = true;
    }
}
