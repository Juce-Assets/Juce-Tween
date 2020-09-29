using System;
using UnityEngine;

namespace Juce.Tween
{
    public abstract partial class Tween
    {
        internal bool HasTarget { get; private set; }
        internal object Target { get; private set; }
        internal bool IsNested { get; private set; }

        public EaseDelegate EaseFunction { get; private set; }

        public float TimeScale { get; private set; }

        public int Loops { get; private set; }
        public int LoopsLeft { get; internal set; }
        public ResetMode LoopsResetMode { get; internal set; }

        internal bool ForcedFinish { get; set; }

        public bool IsActive { get; internal set; }
        public bool IsPlaying { get; protected set; }
        public bool IsCompleted { get; protected set; }
        public bool IsKilled { get; protected set; }
        public bool IsCompletedOrKilled => IsCompleted || IsKilled;

        public event Action<float> onTimeScaleChange;
        public event Action onStart;
        public event Action onUpdate;
        public event Action onComplete;
        public event Action onKill;
        public event Action onCompleteOrKill;
        public event Action onLoop;

        internal Tween()
        {
            SetTimeScale(1);
            SetEase(Ease.Linear);
        }

        internal void SetNested()
        {
            IsNested = true;
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

        public bool HasValidTarget()
        {
            if (HasTarget)
            {
                if (Target is UnityEngine.Object)
                {
                    if (((UnityEngine.Object)Target) == null)
                    {
                        return false;
                    }
                }
                else if (Target == null)
                {
                    return false;
                }
            }

            return true;
        }

        public void SetTimeScale(float set)
        {
            TimeScale = set;

            SetTimeScaleInternal(set);

            onTimeScaleChange?.Invoke(set);
        }

        public void SetLoops(int loops, ResetMode resetMode)
        {
            if (IsActive)
            {
                return;
            }

            Loops = loops;
            LoopsResetMode = resetMode;
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

        public void Play()
        {
            JuceTween.Play(this);
        }

        internal void Activate()
        {
            if (IsActive)
            {
                return;
            }

            LoopsLeft = Loops;

            ForcedFinish = false;

            IsActive = true;
            IsPlaying = false;
            IsCompleted = false;
            IsKilled = false;

            ActivateInternal();
        }

        internal void Deactivate()
        {
            if (!IsActive)
            {
                return;
            }

            IsActive = false;
        }

        internal void Start()
        {
            if (!IsActive)
            {
                return;
            }

            if (IsPlaying)
            {
                return;
            }

            IsPlaying = true;
            IsCompleted = false;
            IsKilled = false;

            onStart?.Invoke();

            StartInternal();
        }

        public void Complete()
        {
            if (!IsActive)
            {
                return;
            }

            if (!IsPlaying)
            {
                return;
            }

            if (!HasValidTarget())
            {
                return;
            }

            CompleteInternal();

            LoopsLeft = 0;

            ForcedFinish = true;

            IsPlaying = false;
            IsCompleted = true;
            IsKilled = false;

            onComplete?.Invoke();
            onCompleteOrKill?.Invoke();
        }

        public void Kill()
        {
            if (!IsActive)
            {
                return;
            }

            if (!IsPlaying)
            {
                return;
            }

            if (!HasValidTarget())
            {
                return;
            }

            KillInternal();

            LoopsLeft = 0;

            ForcedFinish = true;

            IsPlaying = false;
            IsCompleted = false;
            IsKilled = true;

            onKill?.Invoke();
            onCompleteOrKill?.Invoke();
        }

        public void Reset()
        {
            LoopsLeft = 0;

            ForcedFinish = false;

            IsActive = false;
            IsPlaying = false;
            IsCompleted = false;
            IsKilled = false;

            ResetInternal();
        }

        internal void LoopReset(ResetMode resetMode)
        {
            if (!HasValidTarget())
            {
                return;
            }

            onLoop?.Invoke();

            LoopResetInternal(resetMode);
        }


        internal void Update()
        {
            if (!IsPlaying)
            {
                return;
            }

            onUpdate?.Invoke();

            UpdateInternal();
        }

        public void OnTimeScaleChange(Action<float> action)
        {
            if (action == null)
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

            onStart = action;
        }

        public void OnUpdate(Action action)
        {
            if (action == null)
            {
                return;
            }

            onUpdate = action;
        }

        public void OnComplete(Action action)
        {
            if (action == null)
            {
                return;
            }

            onComplete = action;
        }

        public void OnKill(Action action)
        {
            if (action == null)
            {
                return;
            }

            onKill = action;
        }

        public void OnCompleteOrKill(Action action)
        {
            if (action == null)
            {
                return;
            }

            onCompleteOrKill = action;
        }

        public void OnLoop(Action action)
        {
            if (action == null)
            {
                return;
            }

            onLoop = action;
        }

        protected void MarkAsFinished()
        {
            if (!IsPlaying)
            {
                return;
            }

            ForcedFinish = false;

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

        protected virtual void ActivateInternal()
        {

        }

        protected virtual void StartInternal()
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

        protected virtual void ResetInternal()
        {

        }

        protected virtual void LoopResetInternal(ResetMode resetMode)
        {

        }
    }
}
