using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface OnGridChangedPerFrame
{
    void onGridChanged(List<Position> changedPositions);
    Position getPosition();
}
