using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicArcherBarricade : MagicBarricade
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Magic Archer Barricade";
        this.ObjectDescription = "This is a magic archer barricade, with increased range.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Magic Archer Barricade";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.PositionObstacle = base.PositionObstacle + 0.75f;
        this.PositionDanger = base.PositionDanger + 2.5f;

        this.AttackRange.radius = 4.0f;
        this.TowerBulletDamage = 35.0f;
        this.TowerBulletSpeed = 0.04f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;

        this.TowerBulletSize = 0.4f;

        this.BaseCost = new DataStructures.Cost(200.0f, 00.0f, 0.0f, 0.0f, 50.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 114;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.SightRange = 4.0f;

        this.canAttack = true;
        this.RequiresAccess = true;
        this.CurrentHitpoints = this.MaxHitpoints;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    MagicArcherBarricade()
    {

        this.ObjectName = "Magic Archer Barricade";
        this.ObjectDescription = "This is a magic archer barricade, with increased range.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Magic Archer Barricade";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.PositionObstacle = base.PositionObstacle + 0.75f;
        this.PositionDanger = base.PositionDanger + 2.5f;

        //this.AttackRange.radius = 4.0f;
        this.TowerBulletDamage = 35.0f;
        this.TowerBulletSpeed = 0.04f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        //this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;

        this.TowerBulletSize = 0.4f;

        this.BaseCost = new DataStructures.Cost(200.0f, 00.0f, 0.0f, 0.0f, 50.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 114;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.SightRange = 4.0f;

        this.canAttack = true;
        this.RequiresAccess = true;
        this.CurrentHitpoints = this.MaxHitpoints;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
    }
}
