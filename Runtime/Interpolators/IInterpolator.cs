using System;

namespace Juce.Tween
{
    internal interface IInterpolator<T>
    {
        T Evaluate(T initialValue, T finalValue, float time, EaseDelegate easeFunction);
        T Subtract(T initialValue, T finalValue);
        T Add(T initialValue, T finalValue);
    }
}
