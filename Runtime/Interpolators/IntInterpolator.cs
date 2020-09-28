using System;

namespace Juce.Tween
{
    internal class IntInterpolator : IInterpolator<int>
    {
        public int Evaluate(int initialValue, int finalValue, float time, EaseDelegate easeFunction)
        {
            if (easeFunction == null) throw new ArgumentNullException($"Tried to Evaluate with a null {nameof(EaseDelegate)} on {nameof(IntInterpolator)}");

            return (int)easeFunction(initialValue, finalValue, time);
        }

        public int Subtract(int initialValue, int finalValue)
        {
            return finalValue - initialValue;
        }

        public int Add(int initialValue, int finalValue)
        {
            return finalValue + initialValue;
        }
    }
}
