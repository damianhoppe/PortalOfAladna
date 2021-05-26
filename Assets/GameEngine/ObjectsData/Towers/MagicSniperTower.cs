using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSniperTower : MetalSniperTower
{
    //CircleCollider2D AttackRange;


    // Start is called before the first frame update
    protected override void Start()
    {

        base.Start();

        this.ObjectName = "Magic Sniper Tower";
        this.ObjectDescription = "This is a magic sniper tower, with long range.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default magic Sniper Tower";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 800.0f;
        this.Armor = 7.5f;
        this.Protection = 18.0f;

        this.SightRange = 7.5f;
        this.ActiveAtNight = true;

        this.PositionValue = 2.0f;
        this.PositionObstacle = 5.0f;
        this.PositionDanger = 7.5f;

        this.AttackRange.radius = 7.5f;
        this.TowerBulletDamage = 60.0f;
        this.TowerBulletSpeed = 0.0375f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;


        this.TowerBulletSize = 0.75f;

        this.canAttack = true;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.BaseCost = new DataStructures.Cost(1000.0f, 75.0f, 75.0f, 75.0f, 50.0f, 0.0f);
        this.EnergyToBuild = 15.0f;
        this.RequiredHumans = 10;

        this.PlayerObjectID = 86;

        this.RequiresAccess = false;

        this.CurrentHitpoints = this.MaxHitpoints;
        this.RequiresInventor = true;
        this.RequiresResearcher = true;
        this.RequiresAcademy = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public MagicSniperTower()
    {
        this.ObjectName = "Magic Sniper Tower";
        this.ObjectDescription = "This is a magic sniper tower, with long range.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default magic Sniper Tower";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 800.0f;
        this.Armor = 7.5f;
        this.Protection = 18.0f;

        this.SightRange = 7.5f;
        this.ActiveAtNight = true;

        this.PositionValue = 2.0f;
        this.PositionObstacle = 5.0f;
        this.PositionDanger = 7.5f;

        //this.AttackRange.radius = 7.5f;
        this.TowerBulletDamage = 60.0f;
        this.TowerBulletSpeed = 0.0375f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        //this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;


        this.TowerBulletSize = 0.75f;

        this.canAttack = true;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.BaseCost = new DataStructures.Cost(1000.0f, 75.0f, 75.0f, 75.0f, 50.0f, 0.0f);
        this.EnergyToBuild = 15.0f;
        this.RequiredHumans = 10;

        this.PlayerObjectID = 86;

        this.RequiresAccess = false;

        this.CurrentHitpoints = this.MaxHitpoints;
        this.RequiresInventor = true;
        this.RequiresResearcher = true;
        this.RequiresAcademy = true;
    }
}
