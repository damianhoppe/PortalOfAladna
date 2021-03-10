using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOnCursorPositionChanged
{
    void onPositionChanged(Position oldPosition, Position newPosition);
}
