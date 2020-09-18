using System;
using UnityEngine;

namespace Juce.Tween
{
    public abstract class Tween
    {
        public EaseDelegate EaseFunction { get; private set; }

        public bool IsPlaying { get; protected set; }
        public bool IsCompleted { get; protected set; }
        public bool IsKilled { get; protected set; }

        public event Action OnComplete;
        public event Action OnKill;
        public event Action OnCompleteOrKill;

        public Tween()
        {
            SetEase(Ease.Linear);
        }

        public static Tween To(Tweener<float>.Getter getter, Tweener<float>.Setter setter, float finalValue, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new FloatTweener(getter, setter, finalValue, duration));
            return tween;
        }

        public static Tween To(Tweener<Vector2>.Getter getter, Tweener<Vector2>.Setter setter, Vector2 finalValue, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new Vector2Tweener(getter, setter, finalValue, duration));
            return tween;
        }

        public static Tween To(Tweener<Vector3>.Getter getter, Tweener<Vector3>.Setter setter, Vector3 finalValue, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new Vector3Tweener(getter, setter, finalValue, duration));
            return tween;
        }

        public void Play()
        {
            JuceTween.Play(this);
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

            OnComplete?.Invoke();
            OnCompleteOrKill?.Invoke();
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

            OnKill?.Invoke();
            OnCompleteOrKill?.Invoke();
        }

        internal void Update()
        {
            if(!IsPlaying)
            {
                return;
            }

            UpdateInternal();
        }

        protected void MarkAsFinished()
        {
            IsPlaying = false;
            IsCompleted = true;
            IsKilled = false;

            OnComplete?.Invoke();
            OnCompleteOrKill?.Invoke();
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
