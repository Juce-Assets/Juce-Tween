using System;
using System.Collections.Generic;

namespace Juce.Tween
{
    internal class InterpolationTween : Tween
    {
        private readonly List<ITweener> allTweeners = new List<ITweener>();
        private int tweenersLeftToFinish;

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
                    currTweener.Init();
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

        protected override void ResetInternal()
        {
            for (int i = 0; i < allTweeners.Count; ++i)
            {
                ITweener currTweener = allTweeners[i];

                currTweener.Reset(ResetMode.Incremental);
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
                    currTweener.Init();
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
