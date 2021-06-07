using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesHUDManager : MonoBehaviour
{

    private EconomyController economyController;
    private PopulationController populationController;


    ///DANE
    private DataStructures.Cost currentResources;
    private DataStructures.Cost totalResources;
    private float currentEnergy;
    private float totalEnergy;

    ///UI
    private ResourceView goldView;
    private ResourceView woodView;
    private ResourceView stoneView;
    private ResourceView metalView;
    private ResourceView crystalsView;
    private ResourceView humansView;
    private ResourceView humansView2;
    private ResourceView humansView3;
    private ResourceView efficiencyView;
    private ResourceView energyView;

    void Start()
    {
        this.economyController = GameObject.Find("PlayerDataController").GetComponent<EconomyController>();
        this.populationController = GameObject.Find("PlayerDataController").GetComponent<PopulationController>();
        this.goldView = addResource("Złoto: ");
        this.woodView = addResource("Drewno: ");
        this.stoneView = addResource("Kamień: ");
        this.metalView = addResource("Metal: ");
        this.crystalsView = addResource("Kryształy: ");
        this.humansView = addResource("Populacja: ");
        this.humansView2 = addResource("Pracujący: ");
        this.humansView3 = addResource("Wolni: ");
        this.efficiencyView = addResource("Wydajność: ");
        this.energyView = addResource("Energia: ");
    }

    void Update()
    {
        updateEconomyValues();
        this.goldView.setValue(this.currentResources.Gold.ToString() + "/" + this.totalResources.Gold.ToString());
        this.woodView.setValue(this.currentResources.Wood.ToString() + "/" + this.totalResources.Wood.ToString());
        this.stoneView.setValue(this.currentResources.Stone.ToString() + "/" + this.totalResources.Stone.ToString());
        this.metalView.setValue(this.currentResources.Metal.ToString() + "/" + this.totalResources.Metal.ToString());
        this.crystalsView.setValue(this.currentResources.Crystals.ToString() + "/" + this.totalResources.Crystals.ToString());
        this.humansView.setValue(this.populationController.CurrentPopulation.ToString() + "/" + this.populationController.MaxPopulation.ToString());
        this.humansView2.setValue(this.populationController.BusyPopulation.ToString());
        this.humansView3.setValue(this.populationController.FreePopulation.ToString());
        this.efficiencyView.setValue(this.populationController.Efficiency.ToString());
        this.energyView.setValue(this.currentEnergy.ToString() + "/" + this.totalEnergy.ToString());
    }

    private ResourceView addResource(string name)
    {
        ResourceView view = ResourceView.create(this.gameObject, this.economyController);
        view.setName(name);
        return view;
    }

    private void updateEconomyValues()
    {
        this.currentResources = this.economyController.PlayerResources;
        this.totalResources = this.economyController.TotalStorage;
        this.currentEnergy = this.economyController.CurrentEnergy;
        this.totalEnergy = this.economyController.EnergyLimit;
    }
}
