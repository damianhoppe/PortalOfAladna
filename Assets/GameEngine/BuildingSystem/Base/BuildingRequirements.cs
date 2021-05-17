using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingRequirements
{
    List<string> nearbyStructures;
    int minDistance;
    public List<Position> positionsToCheck;
    bool initialized;

    Building building;

    public BuildingRequirements(Building building)
    {
        this.nearbyStructures = new List<string>();
        this.building = building;
        this.initialized = false;
        positionsToCheck = new List<Position>();
    }

    public void initDictionary(List<Structure> structures, int minDistance)
    {
        Debug.Log("initDict 1");
        this.initialized = true;
        for (int i = 0; i < structures.Count; i++)
        {
            this.nearbyStructures.Add(structures[i].GetComponent<Structure>().getName());
        }
        this.minDistance = minDistance;

        if (structures.Count == 0) return;
        int size = this.minDistance * 2 + 1;
        for(int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                positionsToCheck.Add(new Position(x-this.minDistance, y-this.minDistance));
            }
        }
        positionsToCheck.Sort(new PositionDistanceComparison(building.getPosition()));
    }

    public bool areMet(GridManager gridManager)
    {
        if (!initialized) return false;
        if (isStructureNear(gridManager)) return true;
        return false;
    }

    private bool isStructureNear(GridManager gridManager)
    {
        if (this.positionsToCheck.Count == 0) return true;
        Position buildingPosition = this.building.getPosition();
        foreach (Position pos in positionsToCheck)
        {
            Structure structure = gridManager.getStructure(buildingPosition.getX() + pos.getX(), buildingPosition.getY() + pos.getY());
            if (structure != null)
            {
                if (this.nearbyStructures.Contains(structure.getName()))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public int getMinDistance()
    {
        return this.minDistance;
    }

    public Structure findNearestStructure(GridManager gridManager)
    {
        Debug.Log("Count: " + this.positionsToCheck.Count);
        Debug.Log("Is: " + isStructureNear(gridManager));
        Debug.Log("Pos: " + this.building.getPosition().toString());
        Position buildingPosition = this.building.getPosition();
        foreach (Position pos in positionsToCheck)
        {
            Debug.Log(pos.distanceTo(building.getPosition()));
            Structure structure = gridManager.getStructure(buildingPosition.getX() + pos.getX(), buildingPosition.getY() + pos.getY());
            if (structure != null)
            {
                if (this.nearbyStructures.Contains(structure.getName()))
                {
                    return structure;
                }
            }
        }
        return null;
    }

    public List<Position> getAllStructurePositions(GridManager gridManager)
    {
        Position buildingPosition = this.building.getPosition();
        List<Position> positions = new List<Position>();
        foreach (Position pos in positionsToCheck)
        {
            if (pos.x == 0 && pos.y == 0)
                continue;
            Structure structure = gridManager.getStructure(buildingPosition.getX() + pos.getX(), buildingPosition.getY() + pos.getY());
            if (structure != null)
            {
                if (this.nearbyStructures.Contains(structure.getName()))
                {
                    positions.Add(new Position(pos.x + buildingPosition.x, pos.y + buildingPosition.y));
                }
            }
        }
        Debug.Log("A: " + positions.Count);
        return positions;
    }
}
