using System;
using UnityEngine;
using Juce.Tween;
using UnityEngine.UI;

public static class JuceTweenImageExtensions
{
    public static Tween TweenColor(this Image image, Color to, float duration)
    {
        Tween tween = Tween.To(() => image.color, x => image.color = x, to, duration);
        tween.SetTarget(image);
        return tween;
    }

    public static Tween TweenColorNoAlpha(this Image image, Color to, float duration)
    {
        Tween tween = Tween.To(() => image.color, x => image.color =
            ColorUtils.ChangeColorKeepingAlpha(x, image.color), to, duration);
        tween.SetTarget(image);
        return tween;
    }

    public static Tween TweenColorAlpha(this Image image, float to, float duration)
    {
        float to255 = to * 255.0f;
        Tween tween = Tween.To(() => image.color.a, x => image.color =
            ColorUtils.ChangeAlpha(image.color, x), to, duration);
        tween.SetTarget(image);
        return tween;
    }

    public static Tween TweenFillAmount(this Image image, float to, float duration)
    {
        Tween tween = Tween.To(() => image.fillAmount, x => image.fillAmount = x, to, duration);
        tween.SetTarget(image);
        return tween;
    }
}
