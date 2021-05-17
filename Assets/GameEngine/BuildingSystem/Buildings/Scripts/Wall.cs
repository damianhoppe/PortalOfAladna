using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : DefaultBuilding, OnGridChangedPerFrame
{
    float HP;
    DayNightController DNS;
    private Dictionary<Direction, Position> positionsToCheck;
    private string texturePrefix  = "Wall";
    private string texturesDirectory  = "Textures/Buildings/Wall";

    public Wall()
    {
        this.Name = "Wall";
    }

    protected override void Start()
    {
        positionsToCheck = new Dictionary<Direction, Position>();
        Position bp = getPosition();
        positionsToCheck.Add(Direction.TOP, new Position(bp.x, bp.y + 1));
        positionsToCheck.Add(Direction.RIGHT, new Position(bp.x + 1, bp.y));
        positionsToCheck.Add(Direction.BOTTOM, new Position(bp.x, bp.y - 1));
        positionsToCheck.Add(Direction.LEFT, new Position(bp.x - 1, bp.y));
        base.Start();
        DNS = GameObject.Find("PlayerDataController").GetComponent<DayNightController>();
        HP = 100;
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void onCreate()
    {
        base.onCreate();
        this.gridManager.addOnGridChangedListener(this);
        updateWall();
    }

    public override void onDestroy()
    {
        this.gridManager.removeOnGridChangedListener(this);
        base.onDestroy();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(GetDamage(5));
        
        }
    }

    IEnumerator GetDamage(float damage)
    {

        HP = HP - damage;
        if (HP < 0)
        {
            Destroy(this.gameObject);
            DNS.BuildingDestroyed();
        }
        yield return new WaitForSeconds(5);

    }

    public void onGridChanged(List<Position> changedPositions)
    {
        if(containNearPosition(changedPositions, getPosition()) && !containPosition(changedPositions, getPosition()))
        {
            updateWall();
        }
    }

    public bool containNearPosition(List<Position> positions, Position position)
    {
        foreach(Position pos in positions)
        {
            if (isAroundInDistance(pos, 1))
                return true;
        }
        return false;
    }

    public bool containPosition(List<Position> positions, Position position)
    {
        foreach (Position pos in positions)
        {
            if (pos.Equals(position))
                return true;
        }
        return false;
    }

    public void updateWall()
    {
        string texturePath = texturesDirectory + "/" + texturePrefix;
        foreach (KeyValuePair<Direction,Position> pair in this.positionsToCheck)
        {
            Structure structure = gridManager.getStructure(pair.Value);
            if (structure != null)
                if (structure.getName().StartsWith("Wall"))
                    texturePath += "_" + directionToString(pair.Key);
        }
        this.spriteRenderer.sprite = Resources.Load<Sprite>(texturePath);
    }

    private string directionToString(Direction direction)
    {
        switch(direction)
        {
            case Direction.TOP:
                return "T";
            case Direction.RIGHT:
                return "R";
            case Direction.BOTTOM:
                return "B";
            default:
                return "L";
        }
    }

    public enum Direction
    {
        TOP, RIGHT, BOTTOM, LEFT
    }

    protected override bool isAroundInDistance(Position position, int distance)
    {
        int xDiff = Mathf.Abs(position.x - getPosition().x);
        int yDiff = Mathf.Abs(position.y - getPosition().y);
        if (xDiff == 0 && yDiff == 0)
            return false;
        if (xDiff == 0 && yDiff != 0 || xDiff != 0 && yDiff == 0)
            return true;
        return false;
    }
}