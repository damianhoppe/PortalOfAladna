﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : Structure
{
    public Ore() : base(EStructureType.Building) {
        this.PlayerObjectID = 200;
        this.category = EStructureCategory.Ores;
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
    }
}
