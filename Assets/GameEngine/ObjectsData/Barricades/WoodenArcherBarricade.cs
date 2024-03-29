﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenArcherBarricade : WoodenBarricade
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Wooden Archer Barricade";
        this.ObjectDescription = "This is a wooden archer barricade, with increased range.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Wooden Archer Barricade";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.PositionObstacle = base.PositionObstacle + 0.75f;
        this.PositionDanger = base.PositionDanger + 1.5f;

        this.AttackRange.radius = 2.5f;
        this.TowerBulletDamage = 10.0f;
        this.TowerBulletSpeed = 0.04f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;

        this.TowerBulletSize = 0.4f;

        this.BaseCost = new DataStructures.Cost(50.0f, 50.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 111;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.SightRange = 2.5f;

        this.canAttack = true;
        this.RequiresAccess = true;
        this.CurrentHitpoints = this.MaxHitpoints;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    WoodenArcherBarricade()
    {

        this.ObjectName = "Wooden Archer Barricade";
        this.ObjectDescription = "This is a wooden archer barricade, with increased range.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Wooden Archer Barricade";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.PositionObstacle = base.PositionObstacle + 0.75f;
        this.PositionDanger = base.PositionDanger + 1.5f;

        //this.AttackRange.radius = 2.5f;
        this.TowerBulletDamage = 10.0f;
        this.TowerBulletSpeed = 0.04f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        //this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;

        this.TowerBulletSize = 0.4f;

        this.BaseCost = new DataStructures.Cost(50.0f, 50.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 111;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.SightRange = 2.5f;

        this.canAttack = true;
        this.RequiresAccess = true;
        this.CurrentHitpoints = this.MaxHitpoints;
    }
}
