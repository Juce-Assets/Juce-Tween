using System;
using System.Collections.Generic;

namespace Juce.Tween
{
    internal class InterpolationTween : Tween
    {
        private readonly List<ITweener> aliveTweeners = new List<ITweener>();
        private readonly List<ITweener> tweenersToRemove = new List<ITweener>();

        protected override void InitInternal()
        {
            for(int i = 0; i < aliveTweeners.Count; ++i)
            {
                aliveTweeners[i].SetEase(EaseFunction);
            }
        }

        protected override void CompleteInternal()
        {
            for (int i = 0; i < aliveTweeners.Count; ++i)
            {
                ITweener currTweener = aliveTweeners[i];

                if (!currTweener.IsPlaying)
                {
                    currTweener.Init();
                }

                if (currTweener.IsPlaying)
                {
                    currTweener.Complete();
                }
            }

            aliveTweeners.Clear();
            tweenersToRemove.Clear();
        }

        protected override void KillInternal()
        {
            aliveTweeners.Clear();
            tweenersToRemove.Clear();
        }

        protected override void UpdateInternal()
        {
            for (int i = 0; i < aliveTweeners.Count; ++i)
            {
                ITweener currTweener = aliveTweeners[i];

                currTweener.TimeScale = TimeScale;

                if (!currTweener.IsPlaying)
                {
                    currTweener.Init();
                }

                currTweener.Update();

                if(currTweener.IsCompleted)
                {
                    tweenersToRemove.Add(currTweener);
                }
            }

            for(int i = 0; i < tweenersToRemove.Count; ++i)
            {
                aliveTweeners.Remove(tweenersToRemove[i]);
            }

            tweenersToRemove.Clear();

            if(aliveTweeners.Count == 0)
            {
                MarkAsFinished();
            }
        }

        public void Add(ITweener tweener)
        {
            aliveTweeners.Add(tweener);
        }
    }
}
