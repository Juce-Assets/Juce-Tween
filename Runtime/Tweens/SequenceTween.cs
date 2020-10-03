using System;
using System.Collections.Generic;

namespace Juce.Tween
{
    public class SequenceTween : Tween
    {
        private readonly List<Tween> allTweens = new List<Tween>();
        private int currTweenIndex;

        private Tween lastAppendedTween;
        private GroupTween lastGroupTween;

        protected override void SetTimeScaleInternal(float timeScale)
        {
            for (int i = 0; i < allTweens.Count; ++i)
            {
                allTweens[i].SetTimeScale(timeScale);
            }

            if (lastAppendedTween != null)
            {
                lastAppendedTween.SetTimeScale(timeScale);
            }
        }

        protected override void SetEaseInternal(EaseDelegate easeFunction)
        {
            for (int i = 0; i < allTweens.Count; ++i)
            {
                allTweens[i].SetEase(easeFunction);
            }

            if (lastAppendedTween != null)
            {
                lastAppendedTween.SetEase(easeFunction);
            }
        }

        protected override void ActivateInternal()
        {
            if (lastAppendedTween != null)
            {
                lastAppendedTween.SetNested();

                allTweens.Add(lastAppendedTween);

                lastAppendedTween = null;
            }

            for (int i = 0; i < allTweens.Count; ++i)
            {
                allTweens[i].Activate();
            }
        }

        protected override void StartInternal()
        {
            currTweenIndex = 0;
        }

        protected override void CompleteInternal()
        {
            for (int i = 0; i < allTweens.Count; ++i)
            {
                Tween currTween = allTweens[i];

                if (!currTween.IsPlaying)
                {
                    currTween.Start();
                }

                if (!currTween.IsCompleted)
                {
                    currTween.Complete();
                }
            }

            currTweenIndex = allTweens.Count;
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

            currTweenIndex = allTweens.Count;
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
            bool finished = TweenUtils.UpdateSequential(allTweens, ref currTweenIndex);

            if (finished)
            {
                MarkAsFinished();
            }
        }

        public void Append(Tween tween)
        {
            if (tween == null) throw new ArgumentNullException($"Tried to {nameof(Append)} a null {nameof(Tween)} on {nameof(SequenceTween)}");

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

            if (lastAppendedTween != null)
            {
                lastAppendedTween.SetNested();

                allTweens.Add(lastAppendedTween);
            }

            lastAppendedTween = tween;

            lastGroupTween = null;
        }

        public void Join(Tween tween)
        {
            if (tween == null) throw new ArgumentNullException($"Tried to {nameof(Join)} a null {nameof(Tween)} on {nameof(SequenceTween)}");

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

            if (lastAppendedTween == null)
            {
                Append(tween);

                return;
            }

            if (lastGroupTween == null)
            {
                lastGroupTween = new GroupTween();
                lastGroupTween.Add(lastAppendedTween);
                lastGroupTween.SetNested();
                allTweens.Add(lastGroupTween);
            }

            lastGroupTween.Add(tween);
        }

        public void AppendCallback(Action action)
        {
            Append(new CallbackTween(action));
        }

        public void JoinCallback(Action action)
        {
            Join(new CallbackTween(action));
        }

        public void AppendWaitTime(float time)
        {
            Append(new WaitTimeTween(time));
        }

        public void JoinWaitTime(float time)
        {
            Join(new WaitTimeTween(time));
        }
    }
}
