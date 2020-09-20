using System;
using System.Collections.Generic;

namespace Juce.Tween
{
    public class SequenceTween : Tween
    {
        private readonly List<Tween> aliveTweens = new List<Tween>();

        private Tween lastAppendedTween;
        private GroupTween lastGroupTween;

        protected override void SetTimeScaleInternal(float timeScale)
        {
            for (int i = 0; i < aliveTweens.Count; ++i)
            {
                aliveTweens[i].SetTimeScale(timeScale);
            }

            if (lastAppendedTween != null)
            {
                lastAppendedTween.SetTimeScale(timeScale);
            }
        }

        protected override void SetEaseInternal(EaseDelegate easeFunction)
        {
            for (int i = 0; i < aliveTweens.Count; ++i)
            {
                aliveTweens[i].SetEase(easeFunction);
            }

            if (lastAppendedTween != null)
            {
                lastAppendedTween.SetEase(easeFunction);
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

                if(!currTween.IsPlaying)
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
            for (int i = 0; i < aliveTweens.Count; ++i)
            {
                Tween currTween = aliveTweens[i];

                if (currTween.IsPlaying)
                {
                    currTween.Kill();
                }
            }

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
            if (tween == null) throw new ArgumentNullException($"Tried to Append a null {nameof(Tween)} on {nameof(SequenceTween)}");

            if (IsPlaying)
            {
                return;
            }

            if(tween.IsPlaying)
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
            if (tween == null) throw new ArgumentNullException($"Tried to Join a null {nameof(Tween)} on {nameof(SequenceTween)}");

            if (IsPlaying)
            {
                return;
            }

            if (tween.IsPlaying)
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
                aliveTweens.Add(lastGroupTween);
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
