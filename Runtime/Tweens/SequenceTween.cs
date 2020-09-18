using System;
using System.Collections.Generic;

namespace Juce.Tween
{
    public class SequenceTween : Tween
    {
        private readonly List<Tween> aliveTweens = new List<Tween>();

        private Tween lastAppendedTween;
        private GroupTween lastGroupTween;

        protected override void SetEaseInternal(EaseDelegate easeFunction)
        {
            for (int i = 0; i < aliveTweens.Count; ++i)
            {
                aliveTweens[i].SetEase(easeFunction);
            }
        }

        protected override void InitInternal()
        {
            if (lastAppendedTween != null)
            {
                aliveTweens.Add(lastAppendedTween);
            }
        }

        protected override void CompleteInternal()
        {
            for (int i = 0; i < aliveTweens.Count; ++i)
            {
                Tween currTween = aliveTweens[i];

                if(!currTween.IsPlaying && !currTween.IsCompleted && !currTween.IsKilled)
                {
                    currTween.Init();
                }

                if (!currTween.IsCompleted)
                {
                    currTween.Complete();
                }
            }

            aliveTweens.Clear();
        }

        protected override void KillInternal()
        {
            aliveTweens.Clear();
        }

        protected override void UpdateInternal()
        {
            bool finished = TweenUtils.UpdateSequential(aliveTweens);

            if (finished)
            {
                MarkAsFinished();
            }
        }

        public void Append(Tween tween)
        {
            if (IsPlaying)
            {
                return;
            }

            if (lastAppendedTween != null)
            {
                aliveTweens.Add(lastAppendedTween);
            }

            lastAppendedTween = tween;

            lastGroupTween = null;
        }

        public void Join(Tween tween)
        {
            if (IsPlaying)
            {
                return;
            }

            if (lastAppendedTween == null)
            {
                Append(tween);

                return;
            }

            if (lastGroupTween == null)
            {
                lastGroupTween = new GroupTween();
                aliveTweens.Add(lastGroupTween);
            }

            lastGroupTween.Add(tween);
        }
    }
}
