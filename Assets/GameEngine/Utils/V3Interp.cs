using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V3Interp : Interpolator<Vector3>, ICalculatorInterpolation<Vector3>
{
    public V3Interp(float fullTime, IOnUpdateInterpolation<Vector3> onUpdateListener) : base(fullTime, null, onUpdateListener)
    {
        this.calculatorInterpolation = this;
    }

    public V3Interp(Vector3 startingValue, Vector3 targetValue, float fullTime, IOnUpdateInterpolation<Vector3> onUpdateListener) : base(startingValue, targetValue, fullTime, null, onUpdateListener)
    {
        this.calculatorInterpolation = this;
    }

    public Vector3 calculateInterpolatedValue(Vector3 startingValue, Vector3 targetValue, float t)
    {
        return Vector3.Lerp(startingValue, targetValue, t);
    }
}
