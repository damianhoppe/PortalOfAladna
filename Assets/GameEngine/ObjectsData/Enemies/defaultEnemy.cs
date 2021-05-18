﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultEnemy : unitObject
{
    protected HPBar hpBar;


    protected override void Start()
    {
        base.Start();
        this.hpBar = HPBar.create(this.gameObject);
        this.hpBar.setMaxHealth(this.MaxHitpoints);
        this.hpBar.setHealth(this.CurrentHitpoints);
        this.hpBar.setVisibility(true);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    

    public virtual string EnemyName { get; protected set; } = "Default Enemy";
    public virtual string EnemyDescription { get; protected set; } = "Default Enemy description";
    public virtual string EnemyType { get; protected set; } = "Enemy";

    public virtual bool IsFriendly { get; protected set; } = true;
    public virtual bool IsHostile { get; protected set; } = false;
    public virtual bool CanSelect { get; protected set; } = true;
    public virtual bool IsAlive { get; protected set; } = true;
    public virtual bool IsDead { get; protected set; } = false;
    public virtual bool CanDie { get; protected set; } = true;

    public virtual float MaxHitpoints { get; protected set; } = 100.0f;
    public virtual float CurrentHitpoints { get; protected set; } = 100.0f;
    public virtual float Armor { get; protected set; } = 0.0f;
    public virtual float Protection { get; protected set; } = 0.0f;

    public virtual float PriorityDanger { get; protected set; } = 1.0f;
    public virtual float PriorityValue { get; protected set; } = 1.0f;
    public virtual float PriorityObstacle { get; protected set; } = 1.0f;

    public virtual DataStructures.Cost KillReward { get; protected set; } = new DataStructures.Cost(100.0f, 10.0f, 5.0f, 0.0f, 0.0f, 5.0f);

    public defaultEnemy(EStructureType Type=EStructureType.Enemy)
    {
        //this.type = type;
    }

    public virtual void onHit()
    {
        this.hpBar.setHealth(this.CurrentHitpoints);
        this.hpBar.showForSeconds(0.5f);
    }
    public virtual void onDeath()
    {

    }


}
