using System;

namespace Juce.Tween
{
    internal class FloatInterpolator : IInterpolator<float>
    {
        public float Evaluate(float initialValue, float finalValue, float time, EaseDelegate easeFunction)
        {
            return easeFunction(initialValue, finalValue, time);
        }
    }
}
