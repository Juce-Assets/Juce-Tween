﻿using System;
using UnityEngine;
using Juce.Tween;

public static class JuceTweenRectTransformExtensions
{
    public static Tween TweenAnchorMax(this RectTransform rectTransform, Vector2 to, float duration)
    {
        Tween tween = Tween.To(() => rectTransform.anchorMax, x => rectTransform.anchorMax = x, to, duration);
        tween.SetTarget(rectTransform);
        return tween;
    }

    public static Tween TweenAnchorMin (this RectTransform rectTransform, Vector2 to, float duration)
    {
        Tween tween = Tween.To(() => rectTransform.anchorMin, x => rectTransform.anchorMin = x, to, duration);
        tween.SetTarget(rectTransform);
        return tween;
    }

    public static Tween TweenAnchoredPosition(this RectTransform rectTransform, Vector2 to, float duration)
    {
        Tween tween = Tween.To(() => rectTransform.anchoredPosition, x => rectTransform.anchoredPosition = x, to, duration);
        tween.SetTarget(rectTransform);
        return tween;
    }
    public static Tween TweenAnchoredPosition3D(this RectTransform rectTransform, Vector3 to, float duration)
    {
        Tween tween = Tween.To(() => rectTransform.anchoredPosition3D, x => rectTransform.anchoredPosition3D = x, to, duration);
        tween.SetTarget(rectTransform);
        return tween;
    }

    public static Tween TweenPivot(this RectTransform rectTransform, Vector2 to, float duration)
    {
        Tween tween = Tween.To(() => rectTransform.pivot, x => rectTransform.pivot = x, to, duration);
        tween.SetTarget(rectTransform);
        return tween;
    }

    public static Tween TweenSizeDelta(this RectTransform rectTransform, Vector2 to, float duration)
    {
        Tween tween = Tween.To(() => rectTransform.sizeDelta, x => rectTransform.sizeDelta = x, to, duration);
        tween.SetTarget(rectTransform);
        return tween;
    }
}