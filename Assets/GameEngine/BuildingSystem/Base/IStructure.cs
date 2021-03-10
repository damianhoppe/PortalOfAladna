using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStructure
{
    string getName();
    Position getPosition();
    void setPosition(Position position);
    void onClick();
}
