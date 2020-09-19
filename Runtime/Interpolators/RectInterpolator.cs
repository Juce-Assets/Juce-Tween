using System;
using UnityEngine;

namespace Juce.Tween
{
    internal class RectInterpolator : IInterpolator<Rect>
    {
        public Rect Evaluate(Rect initialValue, Rect finalValue, float time, EaseDelegate easeFunction)
        {
            return new Rect(
                easeFunction(initialValue.x, finalValue.x, time),
                easeFunction(initialValue.y, finalValue.y, time),
                easeFunction(initialValue.width, finalValue.width, time),
                easeFunction(initialValue.height, finalValue.height, time)
                );
        }
    }
}
