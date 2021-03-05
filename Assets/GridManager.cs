using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridManager : MonoBehaviour
{
    // Start is called before the first frame update
    Grid grid;
    [SerializeField]
    GameObject[] sprite;
    private void Start()
    {
        grid = new Grid(5, 5, 5f, sprite);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.setValue(UtilsClass.GetMouseWorldPosition(),grid.getValue(UtilsClass.GetMouseWorldPosition())+1);
        }
    }
}
