using System;

namespace Juce.Tween
{
    internal class IntInterpolator : IInterpolator<int>
    {
        public int Evaluate(int initialValue, int finalValue, float time, EaseDelegate easeFunction)
        {
            return (int)easeFunction(initialValue, finalValue, time);
        }
    }
}
