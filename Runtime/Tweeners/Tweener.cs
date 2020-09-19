using System;
using UnityEngine;

namespace Juce.Tween
{
    public class Tweener<T> : ITweener
    {
        private T initialValue;
        private readonly T finalValue;

        private readonly float timeScale;
        private readonly float duration;
        private readonly IInterpolator<T> interpolator;

        private readonly Validate validate;
        private readonly Getter getter;
        private readonly Setter setter;

        private EaseDelegate easeFunction;
        private float elapsedTime;

        public delegate bool Validate();
        public delegate void Setter(T value);
        public delegate T Getter();

        public bool IsPlaying { get; protected set; }
        public bool IsCompleted { get; protected set; }

        internal Tweener(Validate validate, Getter getter, Setter setter, T finalValue, float duration, IInterpolator<T> interpolator)
        {
            this.validate = validate;
            this.getter = getter;
            this.finalValue = finalValue;
            this.setter = setter;
            this.duration = duration;
            this.interpolator = interpolator;

            timeScale = 1.0f;
        }

        public void SetEase(EaseDelegate easeFunction)
        {
            this.easeFunction = easeFunction;
        }

        public void Init()
        {
            if(IsPlaying)
            {
                return;
            }

            if (!TryValidate())
            {
                Complete();
            }
            else
            {
                IsPlaying = true;
                IsCompleted = false;

                this.initialValue = getter();
            }
        }

        public void Update()
        {
            if (!IsPlaying)
            {
                return;
            }

            if(!TryValidate())
            {
                Complete();
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
            if (TryValidate())
            {
                setter(finalValue);
            }

            IsPlaying = false;
            IsCompleted = true;
        }

        private bool TryValidate()
        {
            if(validate == null)
            {
                return true;
            }

            return validate();
        }
    }
}
