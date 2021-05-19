using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultEnemy : unitObject
{
    protected HPBar hpBar;
    private CircleCollider2D collider;
    private Rigidbody2D rigidbody;
    public EnemyControllerV2 EnC { get; protected set; }
    public TowerController TC { get; protected set; }

    public void HelloWorld()
    {
        Debug.Log("Hello world!");
    }
    protected override void Start()
    {
        base.Start();
        this.hpBar = HPBar.create(this.gameObject);
        this.hpBar.setMaxHealth(this.MaxHitpoints);
        this.hpBar.setHealth(this.CurrentHitpoints);
        this.hpBar.setVisibility(true);

        this.EnC = GameObject.Find("EnemyControllerV2").GetComponent<EnemyControllerV2>();
        this.TC = GameObject.Find("tmpTowerController").GetComponent<TowerController>();

        collider = gameObject.AddComponent<CircleCollider2D>() as CircleCollider2D;
        collider.radius = 0.5f;
        collider.isTrigger = true;

        rigidbody = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
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

    public virtual bool IsTank { get; protected set; } = false;

    public virtual DataStructures.Cost KillReward { get; protected set; } = new DataStructures.Cost(100.0f, 10.0f, 5.0f, 0.0f, 0.0f, 5.0f);

    public defaultEnemy(EStructureType Type=EStructureType.Enemy)
    {
        //this.type = type;
    }

    public virtual void onHit(float damage)
    {
        if (this.IsTank)
        {
            float DMG = (damage - this.Armor) * (1.0f - this.Protection / 100.0f);
            if (DMG <= 0.0f) DMG = 0.0f;
            this.CurrentHitpoints -= DMG;
            if (this.CurrentHitpoints <= 0.0f) destroy();
        }
        else
        {
            float DMG = damage * (1.0f - this.Protection / 100.0f) - this.Armor;
            if (DMG <= 0.0f) DMG = 0.0f;
            this.CurrentHitpoints -= DMG;
            if (this.CurrentHitpoints <= 0.0f) destroy();
        }


        this.hpBar.setHealth(this.CurrentHitpoints);
        this.hpBar.showForSeconds(0.5f);
    }
    public virtual void destroy()
    {
        onDeath();
        TC.EnemyKilled(this);
        EnC.ReportDeath(this);
    }
    public virtual void onDeath()
    {
        this.IsDead = true;
        this.IsAlive = false;
    }


}
