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

                bool hasValidTarget = currTweener.HasValidTarget();

                if (!hasValidTarget)
                {
                    if (currTweener.IsPlaying)
                    {
                        currTweener.Kill();
                    }
                }
                else
                {
                    if (currTweener.IsActive)
                    {
                        if (!currTweener.IsPlaying)
                        {
                            currTweener.Start();
                        }

                        if (currTweener.IsPlaying)
                        {
                            currTweener.Update();
                        }
                    }
                }

                if (!currTweener.IsActive || !hasValidTarget)
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

                bool hasValidTarget = currTweener.HasValidTarget();

                if (!hasValidTarget)
                {
                    if (currTweener.IsPlaying)
                    {
                        currTweener.Kill();
                    }
                }
                else
                {
                    if (currTweener.IsActive)
                    {
                        if (!currTweener.IsPlaying)
                        {
                            currTweener.Start();
                        }

                        if (currTweener.IsPlaying)
                        {
                            currTweener.Update();
                        }
                    }
                }

                if (currTweener.IsActive && hasValidTarget)
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

            bool hasValidTarget = currTweener.HasValidTarget();

            if (!hasValidTarget)
            {
                if (currTweener.IsPlaying)
                {
                    currTweener.Kill();
                }
            }
            else
            {
                if (currTweener.IsActive)
                {
                    if (!currTweener.IsPlaying)
                    {
                        currTweener.Start();
                    }

                    if (currTweener.IsPlaying)
                    {
                        currTweener.Update();
                    }
                }
            }

            if (!currTweener.IsActive || !hasValidTarget)
            {
                ++currTweenIndex;
            }

            return false;
        }
    }
}
