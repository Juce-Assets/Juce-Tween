using System;
using UnityEngine;
using Juce.Tween;

public static class TrailRendererExtensions
{
    public static Tween TweenTime(this TrailRenderer trailRenderer, float to, float duration)
    {
        Tween tween = Tween.To(() => trailRenderer.time, x => trailRenderer.time = x, to, duration);
        tween.SetTarget(trailRenderer);
        return tween;
    }
}
