using System;
using UnityEngine;

namespace Juce.Tween
{
    internal class RectInterpolator : IInterpolator<Rect>
    {
        public Rect Evaluate(Rect initialValue, Rect finalValue, float time, EaseDelegate easeFunction)
        {
            if (easeFunction == null) throw new ArgumentNullException($"Tried to Evaluate with a null {nameof(EaseDelegate)} on {nameof(Rect)}");

            return new Rect(
                easeFunction(initialValue.x, finalValue.x, time),
                easeFunction(initialValue.y, finalValue.y, time),
                easeFunction(initialValue.width, finalValue.width, time),
                easeFunction(initialValue.height, finalValue.height, time)
                );
        }

        public Rect Subtract(Rect initialValue, Rect finalValue)
        {
            return new Rect(finalValue.x - initialValue.x,
                            finalValue.y - initialValue.y,
                            finalValue.width - initialValue.width,
                            finalValue.height - initialValue.height
                            );
        }

        public Rect Add(Rect initialValue, Rect finalValue)
        {
            return new Rect(finalValue.x + initialValue.x,
                            finalValue.y + initialValue.y,
                            finalValue.width + initialValue.width,
                            finalValue.height + initialValue.height
                            );
        }
    }
}
