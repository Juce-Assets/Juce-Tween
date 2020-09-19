using System;
using UnityEngine;

namespace Juce.Tween
{
    internal class Vector4Interpolator : IInterpolator<Vector4>
    {
        public Vector4 Evaluate(Vector4 initialValue, Vector4 finalValue, float time, EaseDelegate easeFunction)
        {
            return new Vector4(
                easeFunction(initialValue.x, finalValue.x, time),
                easeFunction(initialValue.y, finalValue.y, time),
                easeFunction(initialValue.z, finalValue.z, time),
                easeFunction(initialValue.z, finalValue.w, time)
                );
        }
    }
}
