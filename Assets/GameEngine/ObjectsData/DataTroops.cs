using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTroops : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public class DefaultTroop : DataSpecialObjects.DefaultObject
    {
        public new string ObjectName { get; protected set; } = "Default Troop";
        public new string ObjectDescription { get; protected set; } = "Default Troop Description";
        public new string ObjectType { get; protected set; } = "Troop";
        public new int ObjectTypeID { get; protected set; } = 6;

        public new bool IsFriendly { get; protected set; } = true;
        public new bool CanSelect { get; protected set; } = true;
        public new bool IsAlive { get; protected set; } = true;
        public new bool CanDie { get; protected set; } = true;

        public bool CanBuild { get; protected set; } = false;
        public bool CanUpgrade { get; protected set; } = false;
        public bool CanRepair { get; protected set; } = false;
        public bool CanSell { get; protected set; } = false;

        public bool CanSpawn { get; protected set; } = false;
        public bool CanDespawn { get; protected set; } = false;

        public bool HasEnergy { get; protected set; } = false;
        public bool HasAbilities { get; protected set; } = false;
        public bool HasHealth { get; protected set; } = true;

        public double MaxHitpoints { get; protected set; } = 100.0;
        public double CurrentHitpoints { get; protected set; }
        public double Armor { get; protected set; } = 0.0;
        public double Protection { get; protected set; } = 0.0;


        public override bool OnSelect()
        {
            return base.OnSelect();
        }
        public override bool OnDeath()
        {
            return base.OnDeath();
        }
    }

    /*
    public class Cost
    {
        private int Gold { get; set; }
        private int Human { get; set; }
        private int Wood { get; set; }
        private int Stone { get; set; }
        private int Metal { get; set; }
        private int Crystal { get; set; }
        public Cost(int g, int h, int w, int s, int m, int c)
        {
            this.Gold = g;
            this.Human = h;
            this.Wood = w;
            this.Stone = s;
            this.Metal = m;
            this.Crystal = c;
        }
    }
    public class Default
    {
        // Domyslne wartosci dla HP/MP/Armor
        private double MaxHitpoints { get; set; } = 100.0;
        private double MaxEnergy { get; set; } = 0.0;
        private double MaxArmor { get; set; } = 0.0; //Stala wartosc
        private double MaxBlock { get; set; } = 0.0; //Procentowa

        // Zmienne na odpornosci, jezeli beda
        //private double FireResistance { get; set; } = 0.0; //%
        //private double FireProtection { get; set; } = 0.0; //stala wartosc

        // Zmienne dla siatki/pola na ktorym stoja
        private int[] Position { get; set; } = new int[] { 0, 0 };
        private double DefaultDanger { get; set; } = 0.0;
        private double DefaultValue { get; set; } = 0.0;
        private double DefaultObstacle { get; set; } = 0.0;
        private double SightRange { get; set; } = 1.0;
        private int[,] InteractionRange { get; set; } = new int[,] { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };

        // Zmienne ekonomiczne
        private int UnitGoldCost { get; set; } = 100;
        private int UnitHumanCost { get; set; } = 1;
        private int UnitWoodCost { get; set; } = 0;
        private int UnitStoneCost { get; set; } = 0;
        private int UnitMetalCost { get; set; } = 0;
        private int UnitCrystalCost { get; set; } = 0;
        private int UnitBuildTime { get; set; } = 0;
        private double UnitSellRefund { get; set; } = 100.0;
        // Obiekt kosztu

        public Cost UnitCost;

        // Zmienne wizualne i ruch
        private string UnitName { get; set; } = "Human";
        private string UnitDescription { get; set; } = "I'm just useless human.";
        private double Rotation { get; set; } = 0.0;
        private double MaxSpeed { get; set; } = 1.0;

        // Opcje dodatkowe
        private bool CanUseGates { get; set; } = false;
        private bool CanSwim { get; set; } = false;
        private bool CanFly { get; set; } = false;
        private bool IsFireproof { get; set; } = false;

        private bool IsDead { get; set; } = false;
        private bool IsAlive { get; set; } = true;

        private bool IsFriendly { get; set; } = true;
        private bool IsUseful { get; set; } = false;
        private bool IsHostile { get; set; } = false;

        // Statystyki obecne, najbardziej podstawowe
        private double CurrentHitpoints { get; set; }
        private double CurrentEnergy { get; set; }

        // Statystyki obecne, dodatkowe (modyfikatory/negatywne/pozytywne statusy)
        //private bool MaxArmor { get; set; }
        //private bool MaxBlcok { get; set; }

        public Default()
        {
            this.CurrentHitpoints = MaxHitpoints;
            this.CurrentEnergy = CurrentHitpoints;
            this.UnitCost = new Cost(this.UnitGoldCost, this.UnitHumanCost, this.UnitWoodCost, this.UnitStoneCost, this.UnitMetalCost, this.UnitCrystalCost);
        }
        //Default(UpgradesObject){}
        public bool OnSpawn(int[] SpawnpointXY)
        {
            //if(Grid.CheckOccupied(SpawnpointXY)) return false;
            //if(Economy.CheckCanAfford(this.UnitCost)=!true) return false;
            //Economy.BuyUnit(this.UnitCost);
            this.Position[0] = SpawnpointXY[0];
            this.Position[1] = SpawnpointXY[1];
            return true;
        }
        public void OnHitpointsChange(double Hitpoints)
        {
            this.CurrentHitpoints -= Hitpoints;
            if (this.CurrentHitpoints > this.MaxHitpoints) this.CurrentHitpoints = this.MaxHitpoints;
            if (this.CurrentHitpoints <= 0.0)
            {
                this.IsAlive = false;
                this.IsDead = false;
                this.OnUnitDeath();
            }
            return;
        }
        public bool OnEnergyChange(double Energy)
        {
            //bool - czy udalo sie zuzyc energie
            if (this.CurrentEnergy >= Energy)
            {
                this.CurrentEnergy -= Energy;
                if (this.CurrentEnergy > this.MaxEnergy) this.CurrentEnergy = this.MaxEnergy;
                return true;
            }
            else return false;
            
        }
        public void OnUnitDeath() {
            //Co sie dzieje jak zgnije
            //Animacja smierci?
            return;
        }
        public void OnSell()
        {
            this.UnitSellRefund = this.CurrentHitpoints / this.MaxHitpoints;
            if (this.UnitSellRefund > 1.0) UnitSellRefund = 1.0;
            //Wywolanie funkcji zwracajacej koszt wraz z %-zwrotu
            //Economy.Refund(this.Cost,this.UnitSellRefund);
            return;
        }
        public void OnMove() 
        {
            //Tutaj funkcja do przesuwania jednostki, z warunkami czy mozna to zrobic?
            return;
        }
        public void OnUpgrade()
        {
            //Co sie dzieje jak sie ulepsza?
            return;
        }
    }
    public class Peasant : Default
    {

    }
    public class Warrior : Default
    {

    }
    public class Archer : Default
    {

    }
    public class Tank : Default
    {

    }
    public class Scout : Default
    {

    }*/

}
