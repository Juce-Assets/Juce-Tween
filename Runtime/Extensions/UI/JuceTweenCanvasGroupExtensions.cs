using System;
using UnityEngine;
using Juce.Tween;

public static class JuceTweenCanvasGroupExtensions
{
    public static Tween TweenAlpha(this CanvasGroup canvasGroup, float to, float duration)
    {
        Tween tween = Tween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, to, duration);
        tween.SetTarget(canvasGroup);
        return tween;
    }
}
