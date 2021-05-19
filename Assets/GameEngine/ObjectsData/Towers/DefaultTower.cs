using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultTower : DefaultBuilding

{
    public CircleCollider2D AttackRange;
    public List<defaultEnemy> DetectedEnemies = new List<defaultEnemy>();
    public List<RedBullet> myBullets = new List<RedBullet>();

    public defaultEnemy CurrentTarget { get; protected set; }
    public bool hasTarget { get; protected set; } = false;

    public bool targetsFirst { get; protected set; } = true;
    
    public bool targetsLast { get; protected set; } = false;
    public bool targetsRandom { get; protected set; } = false;
    public bool targetsWeakest { get; protected set; } = false;
    public bool targetsStrongest { get; protected set; } = false;
    public bool targetsThreat { get; protected set; } = false;

    public int attackSpeed { get; protected set; } = 200;
    public int attackReady { get; protected set; } = 0;
    public int attackPercent { get; protected set; }

    public bool canAttack { get; protected set; } = true;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.AttackRange = this.GetComponent<CircleCollider2D>();
        AttackRange.radius = 3.0f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (this.hasTarget && this.canAttack)
        {
            Attack(CurrentTarget);
        }
        base.Update();
    }
    public virtual bool Attack(defaultEnemy target)
    {
        this.attackReady++;
        this.attackPercent = this.attackReady / this.attackSpeed;
        if (this.attackReady >= this.attackSpeed)
        {
            //this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            this.attackReady -= this.attackSpeed;
            //target.onHit(20.0f);
            


            return true;
        }
        else
        {
            /*
            this.transform.localScale.y = 1.0f + 0.5f * this.attackPercent;
            this.transform.localScale.x = 1.0f + 0.5f * this.attackPercent;
            this.transform.localScale = new Vector3(
                1.0f + (0.5f * this.attackPercent),
                1.0f + (0.5f * this.attackPercent),
                1.0f + (0.5f * this.attackPercent));
            */
            //this.transform.localScale += new Vector3(0.0015f, 0.0015f, 0.00f);
        }

        return false;
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            defaultEnemy detected = collision.gameObject.GetComponent<defaultEnemy>();
            DetectedEnemies.Add(detected);
            if (hasTarget == false)
            {
                hasTarget = true;
                CurrentTarget = detected;
            }
            //if()
            //this.DetectedEnemies.Add((defaultEnemy)collision.gameObject);
        }
    }
    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            defaultEnemy detected = collision.gameObject.GetComponent<defaultEnemy>();
            DetectedEnemies.Remove(detected);
            if (CurrentTarget == detected)
            {
                FindTarget();   
            }
            Debug.Log("Bai bai.");
        }
    }
    public virtual void FindTarget()
    {
        if (DetectedEnemies.Count == 0)
        {
            CurrentTarget = null;
            hasTarget = false;
            return;
        }
        if (targetsLast) { CurrentTarget = DetectedEnemies[DetectedEnemies.Count-1]; }
        else if (targetsRandom) 
        {
            int tmp = Random.Range(0, DetectedEnemies.Count);
            CurrentTarget = DetectedEnemies[tmp]; 
        }
        else if (targetsWeakest) { }
        else if (targetsStrongest) { }
        else if (targetsThreat) { }
        else
        {
            CurrentTarget = DetectedEnemies[0];
        }
    }
    public void targetFirst()
    {
        targetsFirst = true;
        targetsLast = false;
        targetsRandom = false;
        targetsStrongest = false;
        targetsWeakest = false;
        targetsThreat = false;
    }
    public void targetLast()
    {
        targetsFirst = false;
        targetsLast = true;
        targetsRandom = false;
        targetsStrongest = false;
        targetsWeakest = false;
        targetsThreat = false;
    }
    public void targetRandom()
    {
        targetsFirst = false;
        targetsLast = false;
        targetsRandom = true;
        targetsStrongest = false;
        targetsWeakest = false;
        targetsThreat = false;
    }
    public void targetStrongest()
    {
        targetsFirst = false;
        targetsLast = false;
        targetsRandom = false;
        targetsStrongest = true;
        targetsWeakest = false;
        targetsThreat = false;
    }
    public void targetWeakest()
    {
        targetsFirst = false;
        targetsLast = false;
        targetsRandom = false;
        targetsStrongest = false;
        targetsWeakest = true;
        targetsThreat = false;
    }
    public void targetThreat()
    {
        targetsFirst = false;
        targetsLast = false;
        targetsRandom = false;
        targetsStrongest = false;
        targetsWeakest = false;
        targetsThreat = true;
    }
}
