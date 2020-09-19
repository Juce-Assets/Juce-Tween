using System;
using UnityEngine;
using Juce.Tween;
using UnityEngine.UI;

public static class JuceTweenOutlineExtensions
{
    public static Tween TweenColor(this Outline outline, Color to, float duration)
    {
        Tween tween = Tween.To(() => outline.effectColor, x => outline.effectColor = x, to, duration);
        tween.SetTarget(outline);
        return tween;
    }

    public static Tween TweenColorAlpha(this Outline outline, float to, float duration)
    {
        float to255 = to * 255.0f;
        Tween tween = Tween.To(() => outline.effectColor.a, x => outline.effectColor =
            ColorUtils.ChangeAlpha(outline.effectColor, x), to, duration);
        tween.SetTarget(outline);
        return tween;
    }
}
