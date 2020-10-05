using System;
using UnityEngine;

namespace Juce.Tween
{
    public class Tweener<T> : ITweener
    {
        private T initialValue;
        private T finalValue;

        private bool firstTime;
        private T firstTimeInitialValue;
        private T firstTimeFinalValue;

        private readonly float duration;
        private readonly IInterpolator<T> interpolator;

        private readonly Getter getter;
        private readonly Setter setter;

        private EaseDelegate easeFunction;
        private float elapsedTime;

        public delegate void Setter(T value);
        public delegate T Getter();

        public float TimeScale { get; set; }

        public bool IsPlaying { get; protected set; }
        public bool IsCompleted { get; protected set; }

        internal Tweener(Getter getter, Setter setter, T finalValue, float duration, IInterpolator<T> interpolator)
        {
            this.getter = getter;
            this.finalValue = finalValue;
            this.setter = setter;
            this.duration = duration;
            this.interpolator = interpolator;

            firstTime = true;

            TimeScale = 1.0f;
        }

        public void SetEase(EaseDelegate easeFunction)
        {
            this.easeFunction = easeFunction;
        }

        public void Init()
        {
            IsPlaying = false;
            IsCompleted = false;

            elapsedTime = 0.0f;
        }

        public void Start()
        {
            if (IsPlaying)
            {
                return;
            }

            IsPlaying = true;
            IsCompleted = false;

            elapsedTime = 0.0f;

            this.initialValue = getter();

            if (firstTime)
            {
                firstTime = false;

                firstTimeInitialValue = initialValue;
                firstTimeFinalValue = finalValue;
            }
        }

        public void Reset(ResetMode mode)
        {
            switch (mode)
            {
                case ResetMode.Restart:
                    {
                        setter(firstTimeInitialValue);
                        finalValue = firstTimeFinalValue;
                    }
                    break;

                case ResetMode.Incremental:
                    {
                        T difference = interpolator.Subtract(firstTimeInitialValue, firstTimeFinalValue);
                        finalValue = interpolator.Add(getter(), difference);
                    }
                    break;
            }
        }

        public void Update()
        {
            if (!IsPlaying)
            {
                return;
            }

            float dt = Time.deltaTime * JuceTween.TimeScale * TimeScale;

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
            IsCompleted = true;
        }
    }
}
