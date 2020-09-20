using System;

namespace Juce.Tween
{
    internal class FloatInterpolator : IInterpolator<float>
    {
        public float Evaluate(float initialValue, float finalValue, float time, EaseDelegate easeFunction)
        {
            if (easeFunction == null) throw new ArgumentNullException($"Tried to Evaluate with a null {nameof(EaseDelegate)} on {nameof(FloatInterpolator)}");

            return easeFunction(initialValue, finalValue, time);
        }
    }
}
