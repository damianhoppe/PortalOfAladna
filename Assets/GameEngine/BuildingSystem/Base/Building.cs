using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Structure, IBuilding
{
    [SerializeField]
    List<Structure> nearbyStructuresRequired;
    [SerializeField]
    int requiredMinimalDistance;

    BuildingRequirements buildingRequirements;
    public Building() : base(EStructureType.Building)
    {
        this.buildingRequirements = new BuildingRequirements(this);
    }

    protected void Start()
    {
        buildingRequirements.initDictionary(nearbyStructuresRequired, requiredMinimalDistance);
    }

    protected void Update()
    {

    }

    public BuildingRequirements getBuildingRequirements()
    {
        return this.buildingRequirements;
    }

    public void onCreate()
    {
    }

    public void onDestroy()
    {
    }
}
