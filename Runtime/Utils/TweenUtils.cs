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

                if (!currTweener.IsPlaying)
                {
                    currTweener.Init();
                }

                currTweener.Update();

                if (currTweener.IsCompleted || currTweener.IsKilled)
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

            if (!currTweener.IsPlaying)
            {
                currTweener.Init();
            }

            currTweener.Update();

            if (currTweener.IsCompleted || currTweener.IsKilled)
            {
                aliveTweens.RemoveAt(0);
            }

            return false;
        }
    }
}
