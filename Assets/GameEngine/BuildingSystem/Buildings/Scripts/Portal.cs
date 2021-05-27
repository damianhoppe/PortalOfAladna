using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : DefaultBuilding
{
    public int GridX { get; protected set; }
    public int GridY { get; protected set; }
    public int[,] DistanceArray { get; protected set; }

    public Position ArrayPosition { get; protected set; }

    public Position PortalPosition { get; protected set; }

    protected override void Start()
    {
        base.Start();
        
        this.PlayerObjectID = 0;

        this.ObjectName = "Portal";
        this.ObjectDescription = "This is a portal. Protect it at any cost.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Portal";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 1000.0f;
        this.Armor = 10.0f;
        this.Protection = 50.0f;

        this.PositionValue = 100.0f;
        this.PositionDanger = 100.0f;
        this.PositionObstacle = 100.0f;

        this.BaseCost = new DataStructures.Cost(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.RepairRate = 2.0f;
        this.CanRepair = true;

        this.BuildingStorage = new DataStructures.Cost(1000.0f, 400.0f, 400.0f, 400.0f, 400.0f, 0.0f);
        this.LivingSpace = 50;

        this.BlocksPlayerUnits = false;
        this.RequiresAccess = true;

        this.CanBuild = true;
        this.CanSell = false;
        this.IsMilitary = true;

        this.CurrentHitpoints = this.MaxHitpoints;
}
    public Portal()
    {
        this.PlayerObjectID = 0;

        this.ObjectName = "Portal";
        this.ObjectDescription = "This is a portal. Protect it at any cost.";
        this.ObjectType = "Building";
        this.ObjectTypeID = 1;
        this.ObjectSubtype = "Default Portal";
        this.ObjectSubtypeID = 1;

        this.MaxHitpoints = 1000.0f;
        this.Armor = 10.0f;
        this.Protection = 50.0f;

        this.PositionValue = 100.0f;
        this.PositionDanger = 100.0f;
        this.PositionObstacle = 100.0f;

        this.BaseCost = new DataStructures.Cost(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        this.RepairRate = 2.0f;
        this.CanRepair = true;

        this.BuildingStorage = new DataStructures.Cost(1000.0f, 400.0f, 400.0f, 400.0f, 400.0f, 0.0f);
        this.LivingSpace = 50;

        this.BlocksPlayerUnits = false;
        this.RequiresAccess = true;

        this.CanBuild = true;
        this.CanSell = false;
        this.IsMilitary = true;

        this.CurrentHitpoints = this.MaxHitpoints;
    }
    protected override void Update()
    {
        base.Update();
    }
    public override void onCreate()
    {
        base.onCreate();

        this.BaseCost= new DataStructures.Cost(2500.0f, 1000.0f, 1000.0f, 500.0f, 500.0f, 0.0f);
        this.RepairRate = 2.0f;
        this.CanBuild = false;


        
        this.setMapSize();
        this.createDistanceArray();
        this.setPortalPosition();

        this.setNeighbours(this.ArrayPosition.x, this.ArrayPosition.y, 1);

        this.printArray();
    }
    public void setMapSize()
    {
        this.GridX = GM.width;
        this.GridY = GM.height;

        Debug.Log("gridX: " + this.GridX + "; gridY: " + this.GridY);
    }
    public void setPortalPosition()
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y;

        int X = Mathf.RoundToInt(x);
        int Y = Mathf.RoundToInt(y);

        this.PortalPosition = new Position(X, Y);
        //Debug.Log("portalX: "+this.PortalPosition.x+ "portalY: " + this.PortalPosition.y);

        this.DistanceArray[X + (this.GridX - 1) / 2, (this.GridY - 1 - Y - (this.GridY - 1) / 2)] =0;
        this.ArrayPosition = new Position(X + (this.GridX - 1) / 2, (this.GridY - 1 - Y - (this.GridY - 1) / 2));
        //Debug.Log("portalX: " + (X + (this.GridX - 1) / 2) + "portalY: " + (this.GridY-1 - Y - (this.GridY-1)/2));
    }
    public void createDistanceArray()
    {
        this.DistanceArray = new int[this.GridX, this.GridY];
        for(int i = 0; i < this.GridX; i++)
        {
            for(int j = 0; j < this.GridY; j++)
            {
                this.DistanceArray[i, j] = this.GridX+this.GridY;
            }
        }
    }
    public void printArray()
    {
        for(int y = 0; y < this.GridY; y++)
        {
            string tmp = "";
            for(int x = 0; x < this.GridX; x++)
            {
                tmp += DistanceArray[x, y].ToString() + " ";
            }
            Debug.Log(tmp);
        }
    }
    public void setNeighbours(int x, int y, int distance)
    {
        Structure west = null;
        Structure east = null;
        Structure north = null;
        Structure south = null;

        bool westChanged = false;
        bool eastChanged = false;
        bool northChanged = false;
        bool southChanged = false;

        if(x-1 >= 0)
        {
            west = GM.getStructure(new Position((x-1) - (this.GridX - 1) / 2, (this.GridY - 1) / 2 - y));

            if(west == null)
            {
                if (DistanceArray[x - 1, y] > distance)
                {
                    DistanceArray[x - 1, y] = distance;
                    westChanged = true;
                }
            }
            //else if (west.BlocksPlayerUnits) DistanceArray[x - 1, y] = -1;
            else
            {
                if (DistanceArray[x - 1, y] > distance)
                {
                    DistanceArray[x - 1, y] = distance;
                    westChanged = true;
                    if (west.BlocksPlayerUnits) westChanged = false;
                }
            }
        }
        if(x + 1 <= this.GridX - 1)
        {
            east = GM.getStructure(new Position((x+1) - (this.GridX - 1) / 2, (this.GridY - 1) / 2 - y));
            
            if (east == null)
            {
                if (DistanceArray[x + 1, y] > distance)
                {
                    DistanceArray[x + 1, y] = distance;
                    eastChanged = true;
                }
            }
            //else if (east.BlocksPlayerUnits) DistanceArray[x + 1, y] = -1;
            else
            {
                if (DistanceArray[x + 1, y] > distance)
                {
                    DistanceArray[x + 1, y] = distance;
                    eastChanged = true;
                    if (east.BlocksPlayerUnits) eastChanged = false;
                }
            }
        }
        
        if (y - 1 >= 0)
        {
            south = GM.getStructure(new Position(x - (this.GridX - 1) / 2, (this.GridY - 1) / 2 - (y-1)));

            if (south == null)
            {
                if (DistanceArray[x, y - 1] > distance)
                {
                    DistanceArray[x, y - 1] = distance;
                    southChanged = true;
                }
            }
            //else if (south.BlocksPlayerUnits) DistanceArray[x, y - 1] = -1;
            else
            {
                if (DistanceArray[x, y - 1] > distance)
                {
                    DistanceArray[x, y - 1] = distance;
                    southChanged = true;
                    if (south.BlocksPlayerUnits) southChanged = false;
                }
            }
        }
        if (y + 1 <= this.GridY - 1)
        {
            north = GM.getStructure(new Position(x - (this.GridX - 1) / 2, (this.GridY - 1) / 2 - (y+1)));

            if (north == null)
            {
                if (DistanceArray[x, y + 1] > distance)
                {
                    DistanceArray[x, y + 1] = distance;
                    northChanged = true;
                }
            }
            //else if (north.BlocksPlayerUnits) DistanceArray[x, y + 1] = -1;
            else
            {
                if (DistanceArray[x, y + 1] > distance)
                {
                    DistanceArray[x, y + 1] = distance;
                    northChanged = true;
                    if (north.BlocksPlayerUnits) northChanged = false;
                }
            }
        }

        if (southChanged) { this.setNeighbours(x, y - 1, distance + 1); }
        if (northChanged) { this.setNeighbours(x, y + 1, distance + 1); }
        if (eastChanged) { this.setNeighbours(x + 1, y, distance + 1); }
        if (westChanged) { this.setNeighbours(x - 1, y, distance + 1); }

    }
    public int getPositionDistance(int x, int y)
    {
        int X = x + (this.GridX - 1) / 2;
        int Y = (this.GridY - 1) / 2 - y;

        return DistanceArray[X, Y];
    }
}
