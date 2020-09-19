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

                bool hasValidTarget = HasValidTarget(currTweener);

                if (!hasValidTarget)
                {
                    if (currTweener.IsPlaying)
                    {
                        currTweener.Kill();
                    }
                }
                else
                {
                    if (!currTweener.IsPlaying)
                    {
                        currTweener.Init();
                    }

                    if (currTweener.IsPlaying)
                    {
                        currTweener.Update();
                    }
                }

                if (currTweener.IsCompleted || currTweener.IsKilled || !hasValidTarget)
                {
                    tweensToRemove.Add(currTweener);
                }
            }

            for (int i = 0; i < tweensToRemove.Count; ++i)
            {
                aliveTweens.Remove(tweensToRemove[i]);
            }

            tweensToRemove.Clear();

            if(aliveTweens.Count == 0)
            {
                return true;
            }

            return false;
        }

        internal static bool UpdateSequential(List<Tween> aliveTweens)
        {
            if(aliveTweens.Count == 0)
            {
                return true;
            }

            Tween currTweener = aliveTweens[0];

            bool hasValidTarget = HasValidTarget(currTweener);

            if (!hasValidTarget)
            {
                if (currTweener.IsPlaying)
                {
                    currTweener.Kill();
                }
            }
            else
            {
                if (!currTweener.IsPlaying)
                {
                    currTweener.Init();
                }

                if (currTweener.IsPlaying)
                {
                    currTweener.Update();
                }
            }

            if (currTweener.IsCompleted || currTweener.IsKilled || !hasValidTarget)
            {
                aliveTweens.RemoveAt(0);
            }

            return false;
        }

        internal static bool HasValidTarget(Tween tween)
        {
            if(tween.HasTarget)
            {
                if(tween.Target is UnityEngine.Object)
                {
                    if(((UnityEngine.Object)tween.Target) == null)
                    {
                        return false;
                    }
                }
                else if(tween.Target == null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
