using System;
using UnityEngine;

namespace Juce.Tween
{
    internal class Vector2Interpolator : IInterpolator<Vector2>
    {
        public Vector2 Evaluate(Vector2 initialValue, Vector2 finalValue, float time, EaseDelegate easeFunction)
        {
            if (easeFunction == null) throw new ArgumentNullException($"Tried to Evaluate with a null {nameof(EaseDelegate)} on {nameof(Vector2Interpolator)}");

            return new Vector2(
                easeFunction(initialValue.x, finalValue.x, time), 
                easeFunction(initialValue.y, finalValue.y, time)
                );
        }

        public Vector2 Subtract(Vector2 initialValue, Vector2 finalValue)
        {
            return finalValue - initialValue;
        }

        public Vector2 Add(Vector2 initialValue, Vector2 finalValue)
        {
            return finalValue + initialValue;
        }
    }
}
