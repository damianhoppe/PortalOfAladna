using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWarriorBarricade : MagicBarricade
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        this.ObjectName = "Magic Warrior Barricade";
        this.ObjectDescription = "This is a magic warrior barricade, with increased attack.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Magic Warrior Barricade";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.PositionObstacle = base.PositionObstacle + 0.75f;
        this.PositionDanger = base.PositionDanger + 2.75f;

        this.AttackRange.radius = 1.5f;
        this.TowerBulletDamage = 60.0f;
        this.TowerBulletSpeed = 0.1f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;

        this.TowerBulletSize = 0.4f;

        this.BaseCost = new DataStructures.Cost(200.0f, 00.0f, 0.0f, 0.0f, 50.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 110;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.SightRange = 1.5f;

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
    MagicWarriorBarricade()
    {

        this.ObjectName = "Metal Warrior Barricade";
        this.ObjectDescription = "This is a metal warrior barricade, with increased attack.";
        this.ObjectType = "Tower";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Metal Warrior Barricade";
        this.ObjectSubtypeID = 2;

        this.IsMilitary = true;
        this.IsCivilian = false;

        this.PositionObstacle = base.PositionObstacle + 0.75f;
        this.PositionDanger = base.PositionDanger + 1.75f;

        this.AttackRange.radius = 1.5f;
        this.TowerBulletDamage = 35.0f;
        this.TowerBulletSpeed = 0.1f;
        //this.TowerBulletLifetime = Mathf.RoundToInt(((AttackRange.radius/TowerBulletSpeed)*1.2f));
        this.TowerBulletLifespan = AttackRange.radius / TowerBulletSpeed * 0.02f;

        this.TowerBulletSize = 0.4f;

        this.BaseCost = new DataStructures.Cost(150.0f, 0.0f, 0.0f, 50.0f, 0.0f, 0.0f);
        this.EnergyToBuild = 10.0f;
        this.RequiredHumans = 5;

        this.PlayerObjectID = 109;

        this.attackSpeed = 200;
        this.attackReady = 0;

        this.SightRange = 1.5f;

        this.canAttack = true;
        this.RequiresAccess = true;
        this.CurrentHitpoints = this.MaxHitpoints;

        this.RequiresInventor = true;
        this.RequiresResearcher = true;
    }
}
