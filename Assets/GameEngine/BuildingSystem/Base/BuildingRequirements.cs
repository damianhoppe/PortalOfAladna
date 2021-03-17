using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingRequirements
{
    List<string> nearbyStructures;
    int minDistance;
    List<Position> positionsToCheck;
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
}
