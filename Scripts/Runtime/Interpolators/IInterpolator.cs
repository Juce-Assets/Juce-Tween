using System;

namespace Juce.Tween
{
    internal interface IInterpolator<T>
    {
        T Evaluate(T initialValue, T finalValue, float time, EaseDelegate easeFunction);
    }
}
