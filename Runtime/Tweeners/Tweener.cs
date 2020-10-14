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

        private readonly IInterpolator<T> interpolator;

        private readonly Getter getter;
        private readonly Setter setter;

        private EaseDelegate easeFunction;
        private float elapsedTime;

        public delegate void Setter(T value);
        public delegate T Getter();

        public float Duration { get; }
        public float TimeScale { get; set; }

        public bool IsPlaying { get; protected set; }
        public bool IsCompleted { get; protected set; }
        public float Progress { get => elapsedTime / Duration; }

        internal Tweener(Getter getter, Setter setter, T finalValue, float duration, IInterpolator<T> interpolator)
        {
            this.getter = getter;
            this.finalValue = finalValue;
            this.setter = setter;
            Duration = duration;
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
            if(firstTime)
            {
                return;
            }

            switch (mode)
            {
                case ResetMode.Restart:
                    {
                        if (Duration > 0)
                        {
                            setter(firstTimeInitialValue);
                            finalValue = firstTimeFinalValue;
                        }
                        else
                        {
                            setter(firstTimeFinalValue);
                            finalValue = firstTimeFinalValue;
                        }
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

            if (elapsedTime < Duration)
            {
                float timeNormalized = elapsedTime / Duration;

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
            T newValue = interpolator.Evaluate(initialValue, finalValue, 1.0f, easeFunction);

            setter(newValue);

            IsPlaying = false;
            IsCompleted = true;
        }
    }
}
