using System;
using System.Collections.Generic;

namespace Juce.Tween
{
    public class GroupTween : Tween
    {
        private readonly List<Tween> aliveTweens = new List<Tween>();
        private readonly List<Tween> tweensToRemove = new List<Tween>();

        protected override void SetTimeScaleInternal(float timeScale)
        {
            for (int i = 0; i < aliveTweens.Count; ++i)
            {
                aliveTweens[i].SetTimeScale(timeScale);
            }
        }

        protected override void SetEaseInternal(EaseDelegate easeFunction)
        {
            for (int i = 0; i < aliveTweens.Count; ++i)
            {
                aliveTweens[i].SetEase(easeFunction);
            }
        }

        protected override void CompleteInternal()
        {
            for (int i = 0; i < aliveTweens.Count; ++i)
            {
                Tween currTween = aliveTweens[i];

                if (currTween.IsPlaying)
                {
                    currTween.Complete();
                }
            }

            aliveTweens.Clear();
            tweensToRemove.Clear();
        }

        protected override void KillInternal()
        {
            for (int i = 0; i < aliveTweens.Count; ++i)
            {
                Tween currTween = aliveTweens[i];

                if (currTween.IsPlaying)
                {
                    currTween.Kill();
                }
            }

            aliveTweens.Clear();
            tweensToRemove.Clear();
        }

        protected override void UpdateInternal()
        {
            bool finished = TweenUtils.UpdateSimultaneous(aliveTweens, tweensToRemove);

            if(finished)
            {
                MarkAsFinished();
            }
        }

        public void Add(Tween tween)
        {
            if (tween == null) throw new ArgumentNullException($"Tried to Add a null {nameof(Tween)} on {nameof(GroupTween)}");

            if (IsPlaying)
            {
                return;
            }

            if (tween.IsPlaying)
            {
                return;
            }

            aliveTweens.Add(tween);
        }
    }
}
