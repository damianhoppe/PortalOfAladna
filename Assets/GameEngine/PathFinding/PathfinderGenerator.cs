using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfinderGenerator : MonoBehaviour
{
    AstarData data;
    GridGraph gg;
    GameObject gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("BuildingSystem");
        // This holds all graph data
        data = AstarPath.active.data;
        gg = AstarPath.active.data.gridGraph;
        gg.name = "PATH";
        // Setup a grid graph with some values
        int width = gm.GetComponent<GridManager>().getWidth();
        int height = gm.GetComponent<GridManager>().getHeight();
        if (width % 2 == 0)
            width++;
        if (height % 2 == 0)
            height++;
        float nodeSize = 1;
        gg.center = new Vector3(0, 0, 0);
        // Updates internal size from the above values
        gg.SetDimensions(width, height, nodeSize);
        // Scans all graphs, do not call gg.Scan(), that is an internal method;
        AstarPath.active.Scan();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
