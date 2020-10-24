using System;
using System.Collections.Generic;

namespace Juce.Tween
{
    internal static class TweenUtils
    {
        internal static bool UpdateSimultaneous(List<Tween> aliveTweens, List<Tween> tweensToRemove)
        {
            for (int i = 0; i < aliveTweens.Count; ++i)
            {
                Tween currTweener = aliveTweens[i];

                bool active = StepTween(currTweener);

                if (!active)
                {
                    tweensToRemove.Add(currTweener);
                }
            }

            for (int i = 0; i < tweensToRemove.Count; ++i)
            {
                aliveTweens.Remove(tweensToRemove[i]);
            }

            tweensToRemove.Clear();

            if (aliveTweens.Count == 0)
            {
                return true;
            }

            return false;
        }

        internal static bool UpdateSimultaneous(List<Tween> allTweens, int tweensLeftToFinish)
        {
            tweensLeftToFinish = 0;

            for (int i = 0; i < allTweens.Count; ++i)
            {
                Tween currTweener = allTweens[i];

                bool active = StepTween(currTweener);

                if (active)
                {
                    ++tweensLeftToFinish;
                }
            }

            if (tweensLeftToFinish == 0)
            {
                return true;
            }

            return false;
        }

        internal static bool UpdateSequential(List<Tween> allTweens, ref int currTweenIndex)
        {
            if (allTweens.Count <= currTweenIndex)
            {
                return true;
            }

            Tween currTweener = allTweens[currTweenIndex];

            bool active = StepTween(currTweener);

            if (!active)
            {
                ++currTweenIndex;

                return UpdateSequential(allTweens, ref currTweenIndex);
            }

            return false;
        }

        internal static bool StepTween(Tween tween)
        {
            bool hasValidTarget = tween.HasValidTarget();

            if (!hasValidTarget)
            {
                if (tween.IsPlaying)
                {
                    tween.Kill();
                }
            }
            else
            {
                if (tween.IsActive)
                {
                    if (!tween.IsPlaying && !tween.IsCompletedOrKilled)
                    {
                        tween.Start();
                    }

                    if (tween.IsPlaying)
                    {
                        tween.Update();
                    }
                }

                if(!tween.IsActive)
                {
                    if (!tween.ForcedFinish )
                    {
                        AdvanceLoop(tween);
                    }
                }
            }

            if (!hasValidTarget)
            {
                tween.Deactivate();
            }

            return tween.IsActive;
        }

        internal static void AdvanceLoop(Tween tween)
        {
            if (tween.LoopsLeft <= 0)
            {
                return;
            }

            tween.LoopsLeft -= 1;
            tween.Reset(tween.LoopsResetMode);
            tween.Activate(false);
        }
    }
}
