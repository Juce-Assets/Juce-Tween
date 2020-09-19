using System;
using UnityEngine;

namespace Juce.Tween
{
    internal class ColorInterpolator : IInterpolator<Color>
    {
        public Color Evaluate(Color initialValue, Color finalValue, float time, EaseDelegate easeFunction)
        {
            return new Color(
                easeFunction(initialValue.r, finalValue.r, time),
                easeFunction(initialValue.g, finalValue.g, time),
                easeFunction(initialValue.b, finalValue.b, time),
                easeFunction(initialValue.a, finalValue.a, time)
                );
        }
    }
}
