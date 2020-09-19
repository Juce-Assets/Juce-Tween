using System;
using UnityEngine;
using Juce.Tween;
using UnityEngine.UI;

public static class JuceTweenGraphicExtensions
{
    public static Tween TweenColor(this Graphic graphic, Color to, float duration)
    {
        Tween tween = Tween.To(() => graphic.color, x => graphic.color = x, to, duration);
        tween.SetTarget(graphic);
        return tween;
    }

    public static Tween TweenColorAlpha(this Graphic graphic, float to, float duration)
    {
        float to255 = to * 255.0f;
        Tween tween = Tween.To(() => graphic.color.a, x => graphic.color =
            ColorUtils.ChangeAlpha(graphic.color, x), to, duration);
        tween.SetTarget(graphic);
        return tween;
    }
}
