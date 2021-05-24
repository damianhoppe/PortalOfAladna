using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour
{
    public defaultTower BulletSource { get; protected set; }
    public defaultEnemy BulletTarget { get; protected set; }
    private CircleCollider2D BulletCollider;
    public bool BulletArmed { get; protected set; } = false;
    public Vector3 BulletMove { get; protected set; } = new Vector3(0.0f, 0.0f, 0.0f);

    public float BulletDamage { get; protected set; }
    public float BulletSpeed { get; protected set; }
    public int BulletLifetime { get; protected set; }
    public int BulletTime { get; protected set; } = 0;
    public bool NoTarget { get; protected set; } = false;
    
    // Start is called before the first frame update
    public void setBulletParameters(float damage, float speed, float size,int lifetime)
    {
        this.BulletDamage = damage;
        this.BulletSpeed = speed;
        this.BulletLifetime = lifetime;
        this.transform.localScale = new Vector3(size, size, size);
    }
    public void launchBullet()
    {
        this.BulletArmed = true;
    }
    public void setSource(defaultTower source)
    {
        this.BulletSource = source;
    }
    public void setTarget(defaultEnemy target)
    {
        this.BulletTarget = target;
    }
    public void moveToTarget()
    {
        this.transform.position += BulletMove*Time.deltaTime*100;

    }
    public void recalculateVector()
    {
        if (this.NoTarget || this.BulletTarget==null) return;
        else
        {
            float proporcja = this.BulletSpeed / Vector3.Distance(this.transform.position, this.BulletTarget.transform.position);
            float speedX = proporcja * (this.BulletTarget.transform.position.x - this.transform.position.x);
            float speedY = proporcja * (this.BulletTarget.transform.position.y - this.transform.position.y);
            this.BulletMove = new Vector3(speedX, speedY, 0.0f);
        }
    }
    public void hitTarget(defaultEnemy target)
    {
        if (target.IsAlive)
        {
            target.onHit(this.BulletDamage);
            if (target.IsDead)
            {
                targetDestroyed();
            }
            this.bulletExpired();
        }
    }
    public void targetDestroyed()
    {
        this.BulletTarget = null;
        this.NoTarget = true;
        this.BulletSource.targetDestroyed();
    }
    public void targetLost()
    {
        this.NoTarget = true;
        this.BulletTarget = null;
    }

    public void bulletExpired()
    {
        Debug.Log("Hey, I expired!");
        this.BulletArmed = false;
        this.BulletSource.bulletExpired(this);
    }
    void Start()
    {
        BulletCollider = gameObject.AddComponent<CircleCollider2D>() as CircleCollider2D;
        BulletCollider.radius = 0.1f;
        BulletCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.BulletArmed)
        {
            if (this.BulletTime >= this.BulletLifetime)
            {
                this.bulletExpired();
            }

            if (BulletTime % 10 == 9)
            {
                recalculateVector();
            }

            moveToTarget();
            
            this.BulletTime++;
        }
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            defaultEnemy enemyHit = collision.gameObject.GetComponent<defaultEnemy>();
            if(BulletArmed)hitTarget(enemyHit);
        }
    }
}
