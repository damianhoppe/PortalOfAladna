using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOnUpdateInterpolation<T>
{
    void onUpdateInterpolation(Interpolator<T> interpolator, T currentValue);
}
