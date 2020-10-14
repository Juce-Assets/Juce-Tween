using System;
using System.Collections.Generic;

namespace Juce.Tween
{
    public class SequenceTween : Tween
    {
        private readonly List<Tween> allTweens = new List<Tween>();
        private int currTweenIndex;

        private GroupTween lastGroupTween;

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
            currTweenIndex = 0;
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

        protected override void ResetInternal(ResetMode resetMode)
        {
            for (int i = allTweens.Count - 1; i >= 0; --i)
            {
                Tween currTween = allTweens[i];

                currTween.Reset(resetMode);

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

        protected override float GetDurationInternal()
        {
            float duration = 0.0f;

            for (int i = 0; i < allTweens.Count; ++i)
            {
                Tween currTween = allTweens[i];

                duration += currTween.GetDuration();
            }

            return duration;
        }

        protected override float GetProgressInternal()
        {
            if (allTweens.Count <= currTweenIndex)
            {
                return 1.0f;
            }

            float progress = float.MaxValue;

            float progressPerTween = (1.0f / allTweens.Count);

            progress = progressPerTween * currTweenIndex;

            Tween currTweener = allTweens[currTweenIndex];

            progress += progressPerTween * currTweener.GetProgress();

            return progress;
        }

        public void Append(Tween tween)
        {
            if (IsPlaying)
            {
                return;
            }

            if (tween == null)
            {
                throw new ArgumentNullException($"Tried to {nameof(Append)} a null {nameof(Tween)} on {nameof(SequenceTween)}");
            }

            if (tween.IsNested)
            {
                return;
            }

            if (tween.IsActive)
            {
                return;
            }

            tween.IsNested = true;

            allTweens.Add(tween);

            lastGroupTween = null;
        }

        public void Join(Tween tween)
        {
            if (tween == null)
            {
                throw new ArgumentNullException($"Tried to {nameof(Join)} a null {nameof(Tween)} on {nameof(SequenceTween)}");
            }

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

            if(allTweens.Count == 0)
            {
                Append(tween);

                return;
            }

            if(lastGroupTween != null)
            {
                lastGroupTween.Add(tween);

                return;
            }

            lastGroupTween = new GroupTween();
            lastGroupTween.IsNested = true;

            Tween toAppendTo = allTweens[allTweens.Count - 1];
            allTweens.RemoveAt(allTweens.Count - 1);
            toAppendTo.IsNested = false;

            lastGroupTween.Add(toAppendTo);

            lastGroupTween.Add(tween);

            allTweens.Add(lastGroupTween);
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
            if (time > 0)
            {
                Append(new WaitTimeTween(time));
            }
        }

        public void JoinWaitTime(float time)
        {
            if (time > 0)
            {
                Join(new WaitTimeTween(time));
            }
        }
    }
}
