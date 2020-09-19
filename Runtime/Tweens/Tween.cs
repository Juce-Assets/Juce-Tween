using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Juce.Tween
{
    public abstract class Tween
    {
        private event Action<float> onTimeScaleChange;
        private event Action onStart;
        private event Action onUpdate;
        private event Action onComplete;
        private event Action onKill;
        private event Action onCompleteOrKill;

        public EaseDelegate EaseFunction { get; private set; }

        public float TimeScale { get; private set; }

        public bool IsPlaying { get; protected set; }
        public bool IsCompleted { get; protected set; }
        public bool IsKilled { get; protected set; }

        public Tween()
        {
            SetEase(Ease.Linear);
        }

        public static Tween To(Tweener<float>.Getter getter, Tweener<float>.Setter setter, 
            float finalValue, float duration, Tweener<float>.Validate validate = null)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new FloatTweener(validate, getter, setter, finalValue, duration));
            return tween;
        }

        public static Tween To(Tweener<Vector2>.Getter getter, Tweener<Vector2>.Setter setter, 
            Vector2 finalValue, float duration, Tweener<Vector2>.Validate validate = null)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new Vector2Tweener(validate, getter, setter, finalValue, duration));
            return tween;
        }

        public static Tween To(Tweener<Vector3>.Getter getter, Tweener<Vector3>.Setter setter, 
            Vector3 finalValue, float duration, Tweener<Vector3>.Validate validate = null)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new Vector3Tweener(validate, getter, setter, finalValue, duration));
            return tween;
        }

        public void Play()
        {
            JuceTween.Play(this);
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
