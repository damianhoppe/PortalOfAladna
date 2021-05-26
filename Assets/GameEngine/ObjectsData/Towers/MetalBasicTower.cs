using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBasicTower : StoneBasicTower
{
    //CircleCollider2D AttackRange;


    // Start is called before the first frame update
    protected override void Start()
    {

        base.Start();

        this.ObjectName = "Metal Basic Tower";
        this.ObjectDescription = "This is a metal basic tower, with default attack.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Metal Basic Tower";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 350.0f;
        this.Armor = 3.5f;
        this.Protection = 10.0f;

        this.SightRange = 4.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 0.5f;
        this.PositionObstacle = 2.0f;
        this.PositionDanger = 3.5f;

        this.AttackRange.radius = 4.0f;
        this.TowerBulletDamage = 25.0f;
        this.TowerBulletSpeed = 0.025f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;


        this.TowerBulletSize = 1.0f;

        this.canAttack = true;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.BaseCost = new DataStructures.Cost(300.0f, 30.0f, 30.0f, 50.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 10;

        this.PlayerObjectID = 77;

        this.RequiresAccess = false;

        this.CurrentHitpoints = this.MaxHitpoints;

        this.RequiresInventor = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public MetalBasicTower()
    {
        this.ObjectName = "Metal Basic Tower";
        this.ObjectDescription = "This is a metal basic tower, with default attack.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Metal Basic Tower";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 350.0f;
        this.Armor = 3.5f;
        this.Protection = 10.0f;

        this.SightRange = 4.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 0.5f;
        this.PositionObstacle = 2.0f;
        this.PositionDanger = 3.5f;

        this.AttackRange.radius = 4.0f;
        this.TowerBulletDamage = 25.0f;
        this.TowerBulletSpeed = 0.025f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;


        this.TowerBulletSize = 1.0f;

        this.canAttack = true;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.BaseCost = new DataStructures.Cost(300.0f, 30.0f, 30.0f, 50.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 10;

        this.PlayerObjectID = 77;

        this.RequiresAccess = false;

        this.CurrentHitpoints = this.MaxHitpoints;
        this.RequiresInventor = true;
    }
}
