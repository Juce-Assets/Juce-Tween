using System;
using System.Collections.Generic;

namespace Juce.Tween
{
    public class GroupTween : Tween
    {
        private readonly List<Tween> allTweens = new List<Tween>();
        private int tweensLeftToFinish;

        protected override void SetTimeScaleInternal(float timeScale)
        {
            for (int i = 0; i < allTweens.Count; ++i)
            {
                allTweens[i].SetTimeScale(timeScale);
            }
        }

        protected override void SetEaseInternal(EaseDelegate easeFunction)
        {
            for (int i = 0; i < allTweens.Count; ++i)
            {
                allTweens[i].SetEase(easeFunction);
            }
        }

        protected override void ActivateInternal()
        {
            for (int i = 0; i < allTweens.Count; ++i)
            {
                allTweens[i].Activate();
            }
        }

        protected override void StartInternal()
        {
            tweensLeftToFinish = allTweens.Count;
        }

        protected override void CompleteInternal()
        {
            for (int i = 0; i < allTweens.Count; ++i)
            {
                Tween currTween = allTweens[i];

                if (!currTween.IsPlaying && !currTween.IsCompletedOrKilled)
                {
                    currTween.Start();
                }

                if (currTween.IsPlaying)
                {
                    currTween.Complete();
                }
            }

            tweensLeftToFinish = 0;
        }

        protected override void KillInternal()
        {
            for (int i = 0; i < allTweens.Count; ++i)
            {
                Tween currTween = allTweens[i];

                if (currTween.IsPlaying)
                {
                    currTween.Kill();
                }
            }

            tweensLeftToFinish = 0;
        }

        protected override void LoopResetInternal(ResetMode resetMode)
        {
            for (int i = allTweens.Count - 1; i >= 0; --i)
            {
                Tween currTween = allTweens[i];

                currTween.LoopReset(resetMode);

                currTween.Activate();
            }
        }

        protected override void UpdateInternal()
        {
            bool finished = TweenUtils.UpdateSimultaneous(allTweens, tweensLeftToFinish);

            if (finished)
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

            if (tween.IsNested)
            {
                return;
            }

            tween.SetNested();

            allTweens.Add(tween);
        }
    }
}
