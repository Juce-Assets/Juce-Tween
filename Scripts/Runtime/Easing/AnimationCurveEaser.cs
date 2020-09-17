using System;
using UnityEngine;

namespace Juce.Tween
{
    internal class AnimationCurveEaser
    {
        internal static EaseDelegate GetEaseDelegate(AnimationCurve animationCurve)
        {
            EaseDelegate result = (float a, float b, float t) =>
            {
                float newT = animationCurve.Evaluate(t);

                return a + ((b - a) * newT); 
            };

            return result;
        }
    }
}
