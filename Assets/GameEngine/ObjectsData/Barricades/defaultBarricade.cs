using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultBarricade : defaultTower
{
    // Start is called before the first frame update

    public defaultBarricade()
    {
        this.category = EStructureCategory.Barricades;
    }
    protected override void Start()
    {
        base.Start();

        this.CanBuildAtNight = true;
        this.BlocksPlayerUnits = false;
        this.RequiresAccess = false;
        this.canAttack = false;
        this.ActiveAtNight = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public override void onSell()
    {
        this.RefundRate = this.CurrentHitpoints / this.MaxHitpoints;
        base.onSell();
    }
    public override bool OnHit(float Damage)
    {
        bool tmp = base.OnHit(Damage);
        this.RefundRate = this.CurrentHitpoints / this.MaxHitpoints;
        return tmp;
    }
}
