using System;
using UnityEngine;
using Juce.Tween;

public static class LineRendererExtensions
{
    public static Tween TweenStartColor(this LineRenderer lineRenderer, Color to, float duration)
    {
        Tween tween = Tween.To(() => lineRenderer.startColor, x => lineRenderer.startColor = x, to, duration);
        tween.SetTarget(lineRenderer);
        return tween;
    }

    public static Tween TweenEndColor(this LineRenderer lineRenderer, Color to, float duration)
    {
        Tween tween = Tween.To(() => lineRenderer.endColor, x => lineRenderer.endColor = x, to, duration);
        tween.SetTarget(lineRenderer);
        return tween;
    }

    public static Tween TweenColor(this LineRenderer lineRenderer, Color to, float duration)
    {
        Tween startTween = TweenStartColor(lineRenderer, to, duration);
        Tween endTween = TweenEndColor(lineRenderer, to, duration);

        GroupTween groupTween = new GroupTween();
        groupTween.Add(startTween);
        groupTween.Add(endTween);

        return groupTween;
    }

    public static Tween TweenStartWidth(this LineRenderer lineRenderer, float to, float duration)
    {
        Tween tween = Tween.To(() => lineRenderer.startWidth, x => lineRenderer.startWidth = x, to, duration);
        tween.SetTarget(lineRenderer);
        return tween;
    }

    public static Tween TweenEndWidth(this LineRenderer lineRenderer, float to, float duration)
    {
        Tween tween = Tween.To(() => lineRenderer.endWidth, x => lineRenderer.endWidth = x, to, duration);
        tween.SetTarget(lineRenderer);
        return tween;
    }

    public static Tween TweenWidth(this LineRenderer lineRenderer, float to, float duration)
    {
        Tween startTween = TweenStartWidth(lineRenderer, to, duration);
        Tween endTween = TweenEndWidth(lineRenderer, to, duration);

        GroupTween groupTween = new GroupTween();
        groupTween.Add(startTween);
        groupTween.Add(endTween);

        return groupTween;
    }
}
