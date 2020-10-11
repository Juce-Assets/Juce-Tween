using System;
using System.Collections.Generic;

namespace Juce.Tween
{
    internal class InterpolationTween : Tween
    {
        private readonly List<ITweener> allTweeners = new List<ITweener>();

        private int tweenersLeftToFinish;

        protected override void ActivateInternal()
        {
            for (int i = 0; i < allTweeners.Count; ++i)
            {
                ITweener currTweener = allTweeners[i];

                currTweener.Init();
            }
        }

        protected override void StartInternal()
        {
            tweenersLeftToFinish = allTweeners.Count;

            for (int i = 0; i < allTweeners.Count; ++i)
            {
                allTweeners[i].SetEase(EaseFunction);
            }
        }

        protected override void CompleteInternal()
        {
            for (int i = 0; i < allTweeners.Count; ++i)
            {
                ITweener currTweener = allTweeners[i];

                if (!currTweener.IsPlaying)
                {
                    currTweener.Start();
                }

                if (currTweener.IsPlaying)
                {
                    currTweener.Complete();
                }
            }

            tweenersLeftToFinish = 0;
        }

        protected override void KillInternal()
        {
            tweenersLeftToFinish = 0;
        }

        protected override void ResetInternal(ResetMode resetMode)
        {
            for (int i = 0; i < allTweeners.Count; ++i)
            {
                ITweener currTweener = allTweeners[i];

                currTweener.Reset(resetMode);

                currTweener.Init();
            }
        }

        protected override void UpdateInternal()
        {
            tweenersLeftToFinish = 0;

            for (int i = 0; i < allTweeners.Count; ++i)
            {
                ITweener currTweener = allTweeners[i];

                currTweener.TimeScale = TimeScale;

                if (!currTweener.IsPlaying)
                {
                    currTweener.Start();
                }

                currTweener.Update();

                if (!currTweener.IsCompleted)
                {
                    ++tweenersLeftToFinish;
                }
            }

            if (tweenersLeftToFinish == 0)
            {
                MarkAsFinished();
            }
        }

        protected override float GetDurationInternal()
        {
            float duration = 0.0f;

            for (int i = 0; i < allTweeners.Count; ++i)
            {
                ITweener currTweener = allTweeners[i];

                if (currTweener.Duration > duration)
                {
                    duration = currTweener.Duration;
                }
            }

            return duration;
        }

        protected override float GetProgressInternal()
        {
            float progress = float.MaxValue;

            for (int i = 0; i < allTweeners.Count; ++i)
            {
                ITweener currTweener = allTweeners[i];

                if (currTweener.Progress < progress)
                {
                    progress = currTweener.Progress;
                }
            }

            return progress;
        }

        public void Add(ITweener tweener)
        {
            if (tweener == null)
            {
                throw new ArgumentNullException($"Tried to {nameof(Add)} a null {nameof(ITweener)} on {nameof(InterpolationTween)}");
            }

            if (tweener.IsPlaying)
            {
                throw new ArgumentNullException($"Tried to {nameof(Add)} a {nameof(ITweener)} on {nameof(InterpolationTween)} " +
                    $"but it was already playing");
            }

            if (allTweeners.Contains(tweener))
            {
                throw new ArgumentNullException($"Tried to {nameof(Add)} a {nameof(ITweener)} on {nameof(InterpolationTween)} " +
                    $"but it was already added");
            }

            allTweeners.Add(tweener);
        }
    }
}
