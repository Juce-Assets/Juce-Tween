using System;
using UnityEngine;

namespace Juce.Tween
{
    public abstract partial class Tween
    {
        internal bool IsNested { get; set; }

        internal EaseDelegate EaseFunction { get; private set; }

        internal float TimeScale { get; private set; }

        internal bool HasTarget { get; private set; }
        internal object Target { get; private set; }

        internal int Loops { get; private set; }
        internal int LoopsLeft { get; set; }
        internal ResetMode LoopsResetMode { get; set; }

        internal bool IsActive { get; set; }
        internal bool ForcedFinish { get; set; }

        public bool IsPlaying { get; internal set; }
        public bool IsCompleted { get; internal set; }
        public bool IsKilled { get; set; }
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
            SetTimeScale(1.0f);
            SetEase(Ease.Linear);
        }

        public void SetEase(Ease ease)
        {
            SetEase(PresetEaser.GetEaseDelegate(ease));
        }

        public void SetEase(AnimationCurve animationCurve)
        {
            if (animationCurve == null)
            {
                throw new ArgumentNullException($"Tried to {nameof(SetEase)} " +
                  $"with a null {nameof(AnimationCurve)} on {nameof(Tween)}");
            }

            SetEase(AnimationCurveEaser.GetEaseDelegate(animationCurve));
        }

        internal void SetEase(EaseDelegate easeFunction)
        {
            if (easeFunction == null)
            {
                throw new ArgumentNullException($"Tried to {nameof(SetEase)} " +
                  $"with a null {nameof(EaseDelegate)} on {nameof(Tween)}");
            }

            EaseFunction = easeFunction;

            SetEaseInternal(easeFunction);
        }

        public void SetUseGeneralTimeScale(bool set)
        {
            SetUseGeneralTimeScaleInternal(set);
        }

        public void SetTimeScale(float set)
        {
            TimeScale = set;

            SetTimeScaleInternal(set);

            onTimeScaleChange?.Invoke(set);
        }

        public void SetTarget(object target)
        {
            Target = target;

            if (Target != null)
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
            if (!HasTarget)
            {
                return true;
            }

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

            return true;
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

        public void Play(bool syncOnPlay = true)
        {
            if (IsActive)
            {
                return;
            }

            if (IsNested)
            {
                return;
            }

            Activate();

            JuceTween.Add(this, syncOnPlay);
        }

        public void Restart()
        {
            Kill();

            Reset(ResetMode.RestartValues);

            Play();
        }

        internal void Activate(bool resetLoops = true)
        {
            if (IsActive)
            {
                return;
            }

            if (resetLoops)
            {
                LoopsLeft = Loops;
            }

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

            ForcedFinish = false;

            IsPlaying = true;
            IsCompleted = false;
            IsKilled = false;

            StartInternal();

            onStart?.Invoke();
        }

        public void Reset(ResetMode resetMode)
        {
            if (!HasValidTarget())
            {
                return;
            }

            ResetInternal(resetMode);

            onLoop?.Invoke();
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

            Deactivate();

            LoopsLeft = 0;

            ForcedFinish = true;

            IsPlaying = false;
            IsCompleted = true;
            IsKilled = false;

            CompleteInternal();

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

            Deactivate();

            LoopsLeft = 0;

            ForcedFinish = true;

            IsPlaying = false;
            IsCompleted = false;
            IsKilled = true;

            KillInternal();

            onKill?.Invoke();
            onCompleteOrKill?.Invoke();
        }

        protected void MarkAsFinished()
        {
            if (!IsActive)
            {
                return;
            }

            if (!IsPlaying)
            {
                return;
            }

            if (IsCompletedOrKilled)
            {
                return;
            }

            Deactivate();

            if (LoopsLeft > 0)
            {
                return;
            }

            ForcedFinish = false;

            IsPlaying = false;
            IsCompleted = true;

            onComplete?.Invoke();
            onCompleteOrKill?.Invoke();
        }

        internal void Update()
        {
            if (!IsPlaying)
            {
                return;
            }

            UpdateInternal();

            onUpdate?.Invoke();
        }

        public float GetDuration()
        {
            return GetDurationInternal();
        }

        public float GetProgress()
        {
            if (!IsPlaying)
            {
                return 0.0f;
            }

            return GetProgressInternal();
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

        protected virtual void SetUseGeneralTimeScaleInternal(bool set)
        {
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

        protected virtual void ResetInternal(ResetMode resetMode)
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

        protected virtual float GetDurationInternal()
        {
            return 0.0f;
        }

        protected virtual float GetProgressInternal()
        {
            return 1.0f;
        }

        public virtual int GetNestedTweenChildsCount()
        {
            return 0;
        }
    }
}