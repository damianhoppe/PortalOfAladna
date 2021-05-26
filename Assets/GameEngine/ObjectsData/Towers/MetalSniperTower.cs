using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalSniperTower : StoneSniperTower
{
    //CircleCollider2D AttackRange;


    // Start is called before the first frame update
    protected override void Start()
    {

        base.Start();

        this.ObjectName = "Metal Sniper Tower";
        this.ObjectDescription = "This is a metal sniper tower, with long range.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Metal Sniper Tower";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 500.0f;
        this.Armor = 5.0f;
        this.Protection = 12.0f;

        this.SightRange = 6.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 0.5f;
        this.PositionObstacle = 2.5f;
        this.PositionDanger = 4.5f;

        this.AttackRange.radius = 6.0f;
        this.TowerBulletDamage = 35.0f;
        this.TowerBulletSpeed = 0.0375f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;


        this.TowerBulletSize = 0.75f;

        this.canAttack = true;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.BaseCost = new DataStructures.Cost(600.0f, 50.0f, 50.0f, 60.0f, 5.0f, 0.0f);
        this.EnergyToBuild = 15.0f;
        this.RequiredHumans = 15;

        this.PlayerObjectID = 85;

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
    public MetalSniperTower()
    {
        this.ObjectName = "Metal Sniper Tower";
        this.ObjectDescription = "This is a metal sniper tower, with long range.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Metal Sniper Tower";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 500.0f;
        this.Armor = 5.0f;
        this.Protection = 12.0f;

        this.SightRange = 6.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 0.5f;
        this.PositionObstacle = 2.5f;
        this.PositionDanger = 4.5f;

        this.AttackRange.radius = 6.0f;
        this.TowerBulletDamage = 35.0f;
        this.TowerBulletSpeed = 0.0375f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;


        this.TowerBulletSize = 0.75f;

        this.canAttack = true;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.BaseCost = new DataStructures.Cost(600.0f, 50.0f, 50.0f, 60.0f, 5.0f, 0.0f);
        this.EnergyToBuild = 15.0f;
        this.RequiredHumans = 15;

        this.PlayerObjectID = 85;

        this.RequiresAccess = false;

        this.CurrentHitpoints = this.MaxHitpoints;
        this.RequiresInventor = true;
        this.RequiresResearcher = true;
    }
}
