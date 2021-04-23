using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuilding
{
    BuildingRequirements getBuildingRequirements();
    void onCreate();
    void onDestroy();
    BuildingStatusBehaviour.Status canBuild();
    void subtractRequirements();
}
