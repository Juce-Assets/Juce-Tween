using System;
using UnityEngine;

namespace Juce.Tween
{
    public class Tweener<T> : ITweener
    {
        private readonly T initialValue;
        private readonly T finalValue;

        private readonly float timeScale;
        private readonly float duration;
        private readonly IInterpolator<T> interpolator;

        private readonly Setter setter;

        private EaseDelegate easeFunction;
        private float elapsedTime;

        public delegate void Setter(T value);

        public bool IsPlaying { get; protected set; }

        internal Tweener(T initialValue, Setter setter, T finalValue, float duration, IInterpolator<T> interpolator)
        {
            this.initialValue = initialValue;
            this.finalValue = finalValue;
            this.setter = setter;
            this.duration = duration;
            this.interpolator = interpolator;

            timeScale = 1.0f;
            IsPlaying = true;
        }

        public void SetEase(EaseDelegate easeFunction)
        {
            this.easeFunction = easeFunction;
        }

        public void Update()
        {
            if (!IsPlaying)
            {
                return;
            }

            float dt = Time.deltaTime * JuceTween.TimeScale * timeScale;

            elapsedTime += dt;

            if (elapsedTime < duration)
            {
                float timeNormalized = elapsedTime / duration;

                T newValue = interpolator.Evaluate(initialValue, finalValue, timeNormalized, easeFunction);

                setter(newValue);
            }
            else
            {
                Complete();
            }
        }

        public void Complete()
        {
            setter(finalValue);

            IsPlaying = false;
        }
    }
}
