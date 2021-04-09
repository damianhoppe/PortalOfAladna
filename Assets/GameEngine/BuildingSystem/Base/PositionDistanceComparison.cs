using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionDistanceComparison : IComparer<Position>
{
    private Position basePosition;

    public PositionDistanceComparison(Position basePosition)
    {
        this.basePosition = basePosition;
    }

    public int Compare(Position pos1, Position pos2)
    {
        float distance1 = basePosition.distanceTo(pos1);
        float distance2 = basePosition.distanceTo(pos2);
        return Compare(distance1, distance2);
    }

    public int Compare(float l1, float l2)
    {
        if (l1 < l2)
            return -1;
        if (l1 > l2)
            return 1;
        return 0;
    }
}
