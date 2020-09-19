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

        public Tween()
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
            SetEase(AnimationCurveEaser.GetEaseDelegate(animationCurve));
        }

        internal void SetEase(EaseDelegate easeFunction)
        {
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
            onTimeScaleChange += action;
        }

        public void OnStart(Action action)
        {
            onStart += action;
        }

        public void OnUpdate(Action action)
        {
            onUpdate += action;
        }

        public void OnComplete(Action action)
        {
            onComplete += onComplete;
        }

        public void OnKill(Action action)
        {
            onKill += action;
        }

        public void OnCompleteOrKill(Action action)
        {
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
            IsPlaying = false;
            IsCompleted = true;
            IsKilled = false;

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
