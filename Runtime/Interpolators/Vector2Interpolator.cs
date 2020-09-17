using System;
using UnityEngine;

namespace Juce.Tween
{
    internal class Vector2Interpolator : IInterpolator<Vector2>
    {
        public Vector2 Evaluate(Vector2 initialValue, Vector2 finalValue, float time, EaseDelegate easeFunction)
        {
            return new Vector2(
                easeFunction(initialValue.x, finalValue.x, time), 
                easeFunction(initialValue.y, finalValue.y, time)
                );
        }
    }
}
