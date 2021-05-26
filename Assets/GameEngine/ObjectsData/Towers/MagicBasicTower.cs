using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBasicTower : MetalBasicTower
{
    //CircleCollider2D AttackRange;


    // Start is called before the first frame update
    protected override void Start()
    {

        base.Start();

        this.ObjectName = "Magic Basic Tower";
        this.ObjectDescription = "This is a magic basic tower, with default attack.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Magic Basic Tower";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 600.0f;
        this.Armor = 5.0f;
        this.Protection = 15.0f;

        this.SightRange = 5.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 1.5f;
        this.PositionObstacle = 3.5f;
        this.PositionDanger = 5.5f;

        this.AttackRange.radius = 6.0f;
        this.TowerBulletDamage = 45.0f;
        this.TowerBulletSpeed = 0.025f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;


        this.TowerBulletSize = 1.0f;

        this.canAttack = true;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.BaseCost = new DataStructures.Cost(500.0f, 50.0f, 50.0f, 50.0f, 25.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 78;

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
    public MagicBasicTower()
    {
        this.ObjectName = "Magic Basic Tower";
        this.ObjectDescription = "This is a magic basic tower, with default attack.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Magic Basic Tower";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.MaxHitpoints = 600.0f;
        this.Armor = 5.0f;
        this.Protection = 15.0f;

        this.SightRange = 5.0f;
        this.ActiveAtNight = true;

        this.PositionValue = 1.5f;
        this.PositionObstacle = 3.5f;
        this.PositionDanger = 5.5f;

        this.AttackRange.radius = 6.0f;
        this.TowerBulletDamage = 45.0f;
        this.TowerBulletSpeed = 0.025f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;


        this.TowerBulletSize = 1.0f;

        this.canAttack = true;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.BaseCost = new DataStructures.Cost(500.0f, 50.0f, 50.0f, 50.0f, 25.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 78;

        this.RequiresAccess = false;

        this.CurrentHitpoints = this.MaxHitpoints;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
    }
}
