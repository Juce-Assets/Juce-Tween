using System;
using UnityEngine;
using Juce.Tween;
using UnityEngine.UI;

public static class JuceTweenTextExtensions
{
    public static Tween TweenColor(this Text text, Color to, float duration)
    {
        Tween tween = Tween.To(() => text.color, x => text.color = x, to, duration);
        tween.SetTarget(text);
        return tween;
    }

    public static Tween TweenColorNoAlpha(this Text text, Color to, float duration)
    {
        Tween tween = Tween.To(() => text.color, x => text.color =
            ColorUtils.ChangeColorKeepingAlpha(x, text.color), to, duration);
        tween.SetTarget(text);
        return tween;
    }

    public static Tween TweenColorAlpha(this Text text, float to, float duration)
    {
        float to255 = to * 255.0f;
        Tween tween = Tween.To(() => text.color.a, x => text.color =
            ColorUtils.ChangeAlpha(text.color, x), to, duration);
        tween.SetTarget(text);
        return tween;
    }
}
