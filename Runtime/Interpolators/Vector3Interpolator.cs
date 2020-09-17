using System;
using UnityEngine;

namespace Juce.Tween
{
    internal class Vector3Interpolator : IInterpolator<Vector3>
    {
        public Vector3 Evaluate(Vector3 initialValue, Vector3 finalValue, float time, EaseDelegate easeFunction)
        {
            return new Vector3(
                easeFunction(initialValue.x, finalValue.x, time),
                easeFunction(initialValue.y, finalValue.y, time),
                easeFunction(initialValue.z, finalValue.z, time)
                );
        }
    }
}
