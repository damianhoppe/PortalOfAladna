using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder
{
    public static GameObject getBuildingPreview(BuildingId building, Vector3 position)
    {
        GameObject obj = build(building, true);
        obj.transform.position = position;
        return obj;
    }

    public static GameObject getBuilding(BuildingId building, Vector3 position)
    {
        GameObject obj = build(building, false);
        obj.transform.position = position;
        return obj;
    }

    private static GameObject build(BuildingId bId, bool preview)
    {
        GameObject obj = new GameObject();
        obj.AddComponent<SpriteRenderer>();
        switch (bId)
        {
            case BuildingId.PORTAL:
                obj.name = "Portal";
                obj.AddComponent<Portal>();
                if (!preview)
                    obj.AddComponent<PortalLogic>();
                break;
        }
        if (preview)
            obj.name += " - preview";
        return obj;
    }
}
