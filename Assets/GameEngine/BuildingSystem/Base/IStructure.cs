using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStructure
{
    string getName();
    Position getPosition();
    void setPosition(Position position);
    void onClick();
    void destroy(bool forceDestruction);
    void onDestroy();
    void onCursorOver();
    void onCursorEnter();
    void onCursorLeft();
}
