using System;
using UnityEngine;

namespace Juce.Tween
{
    public class Tweener<T>
    {
        private readonly T initialValue;
        private readonly T finalValue;

        private readonly float timeScale;
        private readonly float duration;
        private readonly IInterpolator<T> interpolator;

        private readonly Setter setter;

        private EaseDelegate easeFunction;
        private float elapsedTime;

        public delegate T Getter();
        public delegate void Setter(T value);

        public bool IsPlaying { get; protected set; }
        public event Action OnComplete;

        internal Tweener(Getter getter, Setter setter, T finalValue, float duration, IInterpolator<T> interpolator)
        {
            this.initialValue = getter();
            this.finalValue = finalValue;
            this.setter = setter;
            this.duration = duration;
            this.interpolator = interpolator;

            timeScale = 1.0f;
            IsPlaying = true;

            SetEase(Ease.Linear);

            Update();
        }

        internal void SetEase(Ease ease)
        {
            easeFunction = PresetEaser.GetEaseDelegate(Ease.Linear); 
        }

        internal void SetEase(AnimationCurve animationCurve)
        {
            easeFunction = AnimationCurveEaser.GetEaseDelegate(animationCurve);
        }

        internal void Update()
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
                setter(finalValue);

                IsPlaying = false;
                OnComplete?.Invoke();
            }
        }
    }
}
