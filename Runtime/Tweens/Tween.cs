using System;
using UnityEngine;

namespace Juce.Tween
{
    public abstract partial class Tween 
    {
        private Action<float> onTimeScaleChange;
        private Action onStart;
        private Action onUpdate;
        private Action onComplete;
        private Action onKill;
        private Action onCompleteOrKill;

        internal bool HasTarget { get; private set; }
        internal object Target { get; private set; }

        public EaseDelegate EaseFunction { get; private set; }

        public float TimeScale { get; private set; }

        public bool IsPlaying { get; protected set; }
        public bool IsCompleted { get; protected set; }
        public bool IsKilled { get; protected set; }

        internal Tween()
        {
            SetTimeScale(1);
            SetEase(Ease.Linear);
        }

        public void Play()
        {
            JuceTween.Play(this);
        }

        public void SetTarget(object target)
        {
            Target = target;

            if (target != null)
            {
                HasTarget = true;
            }
            else
            {
                HasTarget = false;
            }
        }

        public void SetTimeScale(float set)
        {
            TimeScale = set;

            SetTimeScaleInternal(set);

            onTimeScaleChange?.Invoke(set);
        }

        public void SetEase(Ease ease)
        {
            SetEase(PresetEaser.GetEaseDelegate(ease));
        }

        public void SetEase(AnimationCurve animationCurve)
        {
            if (animationCurve == null) throw new ArgumentNullException($"Tried to {nameof(SetEase)} " +
                $"with a null {nameof(AnimationCurve)} on {nameof(Tween)}");

            SetEase(AnimationCurveEaser.GetEaseDelegate(animationCurve));
        }

        internal void SetEase(EaseDelegate easeFunction)
        {
            if (easeFunction == null) throw new ArgumentNullException($"Tried to {nameof(SetEase)} " +
                $"with a null {nameof(EaseDelegate)} on {nameof(Tween)}");

            if (IsPlaying)
            {
                return;
            }

            EaseFunction = easeFunction;

            SetEaseInternal(easeFunction);
        }

        internal void Init()
        {
            if(IsPlaying)
            {
                return;
            }

            IsPlaying = true;

            onStart?.Invoke();

            InitInternal();
        }

        public void Complete()
        {
            if (!IsPlaying)
            {
                return;
            }

            CompleteInternal();

            IsPlaying = false;
            IsCompleted = true;
            IsKilled = false;

            onComplete?.Invoke();
            onCompleteOrKill?.Invoke();
        }

        public void Kill()
        {
            if (!IsPlaying)
            {
                return;
            }

            KillInternal();

            IsPlaying = false;
            IsCompleted = false;
            IsKilled = true;

            onKill?.Invoke();
            onCompleteOrKill?.Invoke();
        }

        public void OnTimeScaleChange(Action<float> action)
        {
            if(action == null)
            {
                return;
            }

            onTimeScaleChange += action;
        }

        public void OnStart(Action action)
        {
            if (action == null)
            {
                return;
            }

            onStart += action;
        }

        public void OnUpdate(Action action)
        {
            if (action == null)
            {
                return;
            }

            onUpdate += action;
        }

        public void OnComplete(Action action)
        {
            if (action == null)
            {
                return;
            }

            onComplete += action;
        }

        public void OnKill(Action action)
        {
            if (action == null)
            {
                return;
            }

            onKill += action;
        }

        public void OnCompleteOrKill(Action action)
        {
            if (action == null)
            {
                return;
            }

            onCompleteOrKill += action;
        }

        internal void Update()
        {
            if(!IsPlaying)
            {
                return;
            }

            onUpdate?.Invoke();

            UpdateInternal();
        }

        protected void MarkAsFinished()
        {
            if (!IsPlaying)
            {
                return;
            }

            IsPlaying = false;
            IsCompleted = true;

            onComplete?.Invoke();
            onCompleteOrKill?.Invoke();
        }

        protected virtual void SetTimeScaleInternal(float timeScale)
        {

        }

        protected virtual void SetEaseInternal(EaseDelegate easeFunction)
        {

        }

        protected virtual void InitInternal()
        {

        }

        protected virtual void CompleteInternal()
        {

        }

        protected virtual void KillInternal()
        {

        }

        protected virtual void UpdateInternal()
        {

        }

    }
}
