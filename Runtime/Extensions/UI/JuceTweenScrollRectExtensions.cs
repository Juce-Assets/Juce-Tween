using System;
using UnityEngine;
using Juce.Tween;
using UnityEngine.UI;

public static class JuceTweenScrollRectExtensions
{
    public static Tween TweenNormalizedPosition(this ScrollRect scrollRect, Vector2 to, float duration)
    {
        Tween tween = Tween.To(() => scrollRect.normalizedPosition, x => scrollRect.normalizedPosition = x, () => to, duration);
        tween.SetTarget(scrollRect);
        return tween;
    }

    public static Tween TweenHorizontalNormalizedPosition(this ScrollRect scrollRect, float to, float duration)
    {
        Tween tween = Tween.To(() => scrollRect.horizontalNormalizedPosition, x => scrollRect.horizontalNormalizedPosition = x, () => to, duration);
        tween.SetTarget(scrollRect);
        return tween;
    }

    public static Tween TweenVerticalNormalizedPosition(this ScrollRect scrollRect, float to, float duration)
    {
        Tween tween = Tween.To(() => scrollRect.verticalNormalizedPosition, x => scrollRect.verticalNormalizedPosition = x, () => to, duration);
        tween.SetTarget(scrollRect);
        return tween;
    }
}
