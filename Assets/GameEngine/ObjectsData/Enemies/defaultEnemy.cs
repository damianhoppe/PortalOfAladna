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
    public Portal PORTAL { get; protected set; }

    public Vector2Int[] attackRange = { new Vector2Int(0, 1), new Vector2Int(0, -1), new Vector2Int(1, 0), new Vector2Int(-1, 0) };

    //CheckSurroundings

    public List<DefaultBuilding> Surroundings = new List<DefaultBuilding>();
    public float[] SurroundingValues { get; protected set; }
    public bool[] CanGo { get; protected set; }

    //CheckSurroundings2

    public Structure[] SurroundingStructures { get; protected set; }
    public bool[] CanGoDirections { get; protected set; }
    public bool[] CanAttackDirections { get; protected set; }
    public float[] PositionsValues { get; protected set; }
    public float[] IsStructureBuilding { get; protected set; }
    public float CurrentPositionValue { get; protected set; } = 999.9f;

    public DefaultBuilding AttackTarget { get; protected set; }

    public bool IsMoving { get; protected set; } = true;
    public bool IsAttacking { get; protected set; } = false;
    public bool IsStuck { get; protected set; } = false;

    public int attackSpeed { get; protected set; } = 200;
    public int attackReady { get; protected set; } = 0;
    public int attackPercent { get; protected set; }
    public float attackValue { get; protected set; } = 0.0f;


    public virtual string EnemyName { get; protected set; } = "Default Enemy";
    public virtual string EnemyDescription { get; protected set; } = "Default Enemy description";
    public virtual string EnemyType { get; protected set; } = "Enemy";

    public virtual bool IsFriendly { get; protected set; } = false;
    public virtual bool IsHostile { get; protected set; } = true;
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

    public void HelloWorld()
    {
        Debug.Log("Hello world!");
    }
    protected override void Start()
    {
        base.Start();
        
        this.EnC = GameObject.Find("EnemyControllerV2").GetComponent<EnemyControllerV2>();
        this.TC = GameObject.Find("TowerController").GetComponent<TowerController>();
        this.PORTAL = GameObject.Find("Portal").GetComponent<Portal>();

        collider = gameObject.AddComponent<CircleCollider2D>() as CircleCollider2D;
        collider.radius = 0.1f;
        collider.isTrigger = true;

        rigidbody = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        rigidbody.bodyType = RigidbodyType2D.Kinematic;

        this.SurroundingValues = new float[moveRange.Length];
        this.CanGo = new bool[moveRange.Length];

        this.moveSpeed = 0.0025f;
        this.movePrecision = 0.2f;


        this.Armor = 1.0f;
        this.Protection = 0.0f;
        this.MaxHitpoints = 100.0f;
        this.CurrentHitpoints = this.MaxHitpoints;
        this.IsTank = false;
        this.attackValue = 0.0f;

        this.hpBar = HPBar.create(this.gameObject);
        this.hpBar.setMaxHealth(this.MaxHitpoints);
        this.hpBar.setHealth(this.CurrentHitpoints);
        this.hpBar.setVisibility(true);

        this.PriorityDanger = 0.0f;
        this.PriorityObstacle = -1.0f;
        this.PriorityValue = 1.0f;

        setPosition();
        //CheckSurroundings();
        //setDestination();
        CheckSurroundingsV2();
        setDestinationV2();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (IsStuck)
        {
            //jak sie zawiesisz, to nie rob nic
            this.IsMoving = false;
            this.IsAttacking = false;

        }
        if (IsMoving)
        {
            //this.Move();
            this.MoveV2();
        }
        if (IsAttacking)
        {
            this.Attack();
        }

    }

    

    public defaultEnemy(EStructureType Type=EStructureType.Enemy)
    {
        //this.type = type;
    }

    public virtual bool MoveV2()
    {
        this.transform.position += moveVector * Time.deltaTime * 100;
        //Debug.Log(Time.deltaTime*1000000);
        if (Vector3.Distance(this.transform.position, this.DestinationPosition) < movePrecision)
        {
            setPosition();
            CheckSurroundingsV2();
            setDestinationV2();
            return true;
        }
        else return false;
    }

    public override void calculateVector()
    {
        base.calculateVector();
        float proporcja = this.moveSpeed / Vector3.Distance(this.transform.position, this.DestinationPosition);
        float speedX = proporcja * (this.DestinationPosition.x - this.transform.position.x);
        float speedY = proporcja * (this.DestinationPosition.y - this.transform.position.y);
        //Debug.Log("Proporcja:"+proporcja);
        //Debug.Log(new Vector3(speedX, speedY, 0.0f));
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

    public bool Attack()
    {
        this.attackReady++;
        this.attackPercent = this.attackReady / this.attackSpeed;
        if (this.attackReady >= this.attackSpeed)
        {
            this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            this.attackReady -= this.attackSpeed;
            AttackTarget.OnHit(this.attackValue);
            //Debug.Log("Job z paticku w " + AttackTarget);
            if (AttackTarget.IsDead)
            {
                //Destroy(AttackTarget);
                IsMoving = true;
                IsAttacking = false;
            }
            return true;
        }
        else
        {
            this.transform.localScale += new Vector3(0.0015f, 0.0015f, 0.00f);
        }
        return false;
    }
    public override void setDestination()
    {

        float tmpMin = 0.0f;
        int tmpIndex = -1;
        int tmpRand = -1;
        tmpRand = Random.Range(0, 4);

        for (int j = 0; j < SurroundingValues.Length; j++)
        {
            int i = tmpRand + j;
            if (i >= SurroundingValues.Length) i = 0;

            if (j == 0)
            {
                tmpMin = SurroundingValues[i]; tmpIndex = i;
            }
            else if (SurroundingValues[i] < tmpMin) { tmpIndex = i; tmpMin = SurroundingValues[i]; }

        }

        if (CanGo[tmpIndex])
        {
            Position target = CurrentPosition + moveRange[tmpIndex];
            Vector3 punkt_docelowy = new Vector3((float)target.x, (float)target.y, -0.5f);
            punkt_docelowy.x += Random.Range(-movePrecision, movePrecision);
            punkt_docelowy.y += Random.Range(-movePrecision, movePrecision);
            this.DestinationPosition = punkt_docelowy;

            calculateVector();
        }
        else
        {
            Position target = CurrentPosition + moveRange[tmpIndex];
            Vector3 punkt_docelowy = new Vector3((float)target.x, (float)target.y, -0.5f);
            punkt_docelowy.x += Random.Range(-movePrecision, movePrecision);
            punkt_docelowy.y += Random.Range(-movePrecision, movePrecision);
            this.DestinationPosition = punkt_docelowy;
            //Debug.Log("Target detected");
            calculateVector();

            AttackTarget = (DefaultBuilding)GM.getStructure(target);
            IsMoving = false;
            IsAttacking = true;
        }
    }
    public virtual void setDestinationV2()
    {
        float tmpMin = 0.0f;
        int tmpIndex = -1;
        int tmpRand = -1;
        tmpRand = Random.Range(0, moveRange.Length);

        for (int j = 0; j < PositionsValues.Length; j++)
        {
            int i = tmpRand + j;
            if (i >= PositionsValues.Length) i = 0;

            //if (tmpIndex == 0) Debug.Log("Północ: " + PositionsValues[tmpIndex].ToString());
            //if (tmpIndex == 1) Debug.Log("Południe: " + PositionsValues[tmpIndex].ToString());
            //if (tmpIndex == 2) Debug.Log("Wschód: " + PositionsValues[tmpIndex].ToString());
            //if (tmpIndex == 3) Debug.Log("Zachód: " +PositionsValues[tmpIndex].ToString());

            if (j == 0)
            {
                tmpMin = PositionsValues[i]; tmpIndex = i;
            }
            else if (PositionsValues[i] < tmpMin) { tmpIndex = i; tmpMin = PositionsValues[i]; }
        }
        //if (tmpIndex == 0) Debug.Log("Idę: Północ");
        //if (tmpIndex == 1) Debug.Log("Idę: Południe");
        //if (tmpIndex == 2) Debug.Log("Idę: Wschód");
        //if (tmpIndex == 3) Debug.Log("Idę: Zachód");
        Debug.Log(tmpMin + " " + this.CurrentPositionValue);
        if (tmpMin >= this.CurrentPositionValue)
        {
            Debug.Log("Ale jestem podkurwiony.");
            //jeżeli najlepsze miejsce docelowe, spowoduje oddalenie sie
            //przeciwnik wpada w szal i ignoruje swoje priorytety

            this.CheckSurroundingsV2(true);
            for (int j = 0; j < PositionsValues.Length; j++)
            {
                int i = tmpRand + j;
                if (i >= PositionsValues.Length) i = 0;

                if (j == 0)
                {
                    tmpMin = PositionsValues[i]; tmpIndex = i;
                }
                else if (PositionsValues[i] < tmpMin) { tmpIndex = i; tmpMin = PositionsValues[i]; }
            }
        }
        this.CurrentPositionValue = this.PositionsValues[tmpIndex];

        if (CanGoDirections[tmpIndex])
        {
            Position target = CurrentPosition + moveRange[tmpIndex];
            Vector3 punkt_docelowy = new Vector3((float)target.x, (float)target.y, -0.5f);
            punkt_docelowy.x += Random.Range(-movePrecision, movePrecision);
            punkt_docelowy.y += Random.Range(-movePrecision, movePrecision);
            this.DestinationPosition = punkt_docelowy;

            calculateVector();
        }
        else
        {
            if (CanAttackDirections[tmpIndex])
            {
                Position target = CurrentPosition + moveRange[tmpIndex];
                Vector3 punkt_docelowy = new Vector3((float)target.x, (float)target.y, -0.5f);
                punkt_docelowy.x += Random.Range(-movePrecision, movePrecision);
                punkt_docelowy.y += Random.Range(-movePrecision, movePrecision);
                this.DestinationPosition = punkt_docelowy;
                //Debug.Log("Target detected");
                calculateVector();

                AttackTarget = (DefaultBuilding)GM.getStructure(target);
                IsMoving = false;
                IsAttacking = true;
            }
            else
            {
                this.IsMoving = false;
                this.IsAttacking = false;
                this.IsStuck = false;
                Debug.Log("Help me, StepTower, I'm stuck :(");
            }
        }
    }
    public override void CheckSurroundings()
    {
        int X = this.CurrentPosition.x;
        int Y = this.CurrentPosition.y;
        Surroundings = new List<DefaultBuilding>();

        for (int i = 0; i < moveRange.Length; i++)
        {
            if (GM.getStructure(CurrentPosition + moveRange[i]) == null)
            {
                SurroundingValues[i] = Mathf.Abs((CurrentPosition + moveRange[i]).x) + Mathf.Abs((CurrentPosition + moveRange[i]).y);
                CanGo[i] = true;
            }
            else
            {
                Structure tmpStruct = GM.getStructure(CurrentPosition + moveRange[i]);
                if (tmpStruct.IsPlayerBuilding)
                {
                    DefaultBuilding tmpBuilding = (DefaultBuilding)tmpStruct;
                    Surroundings.Add(tmpBuilding);
                    SurroundingValues[i] = Mathf.Abs((CurrentPosition + moveRange[i]).x) + Mathf.Abs((CurrentPosition + moveRange[i]).y);
                    SurroundingValues[i] -= tmpBuilding.PositionDanger * this.PriorityDanger;
                    SurroundingValues[i] -= tmpBuilding.PositionValue * this.PriorityValue;
                    SurroundingValues[i] -= tmpBuilding.PositionObstacle * this.PriorityObstacle;
                    CanGo[i] = false;
                }
                 
            }
        }

    }
    public virtual void CheckSurroundingsV2(bool rage = false)
    {
        int X = this.CurrentPosition.x;
        int Y = this.CurrentPosition.y;

        this.SurroundingStructures = new Structure[moveRange.Length];
        this.CanGoDirections = new bool[moveRange.Length];
        this.PositionsValues = new float[moveRange.Length];
        this.CanAttackDirections = new bool[moveRange.Length];


        for (int i = 0; i < moveRange.Length; i++)
        {
            Structure tmpStructure = GM.getStructure(CurrentPosition + moveRange[i]);
            if (tmpStructure == null)
            {
                this.SurroundingStructures[i] = null;
                this.CanGoDirections[i] = true;
                this.CanAttackDirections[i] = false;

                this.PositionsValues[i] = PORTAL.getPositionDistance(X + moveRange[i].x, Y + moveRange[i].y);
            }
            else
            {
                this.SurroundingStructures[i] = tmpStructure;
                this.CanGoDirections[i] = false;
                //if (tmpStructure.BlocksPlayerUnits) this.CanGoDirections[i] = false;
                if (tmpStructure.IsPlayerBuilding)
                {
                    this.CanAttackDirections[i] = true;
                    this.PositionsValues[i] = PORTAL.getPositionDistance(X + moveRange[i].x, Y + moveRange[i].y);

                    DefaultBuilding tmpBuilding = (DefaultBuilding)tmpStructure;
                    if (rage == false)
                    {
                        this.PositionsValues[i] -= tmpBuilding.PositionDanger * this.PriorityDanger;
                        this.PositionsValues[i] -= tmpBuilding.PositionValue * this.PriorityValue;
                        this.PositionsValues[i] -= tmpBuilding.PositionObstacle * this.PriorityObstacle;
                    }
                }
                else
                {
                    this.PositionsValues[i] = 9999;
                    this.CanAttackDirections[i] = false;
                }
            }
        }
    }
}
