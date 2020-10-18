using System;
using UnityEngine;
using Juce.Tween;

public static class JuceTweenSpriteRendererExtensions
{
    public static Tween TweenColor(this SpriteRenderer spriteRenderer, Color to, float duration)
    {
        Tween tween = Tween.To(() => spriteRenderer.color, x => spriteRenderer.color = x, to, duration);
        tween.SetTarget(spriteRenderer);
        return tween;
    }

    public static Tween TweenColorNoAlpha(this SpriteRenderer spriteRenderer, Color to, float duration)
    {
        Tween tween = Tween.To(() => spriteRenderer.color, x => spriteRenderer.color =
            ColorUtils.ChangeColorKeepingAlpha(x, spriteRenderer.color), to, duration);
        tween.SetTarget(spriteRenderer);
        return tween;
    }

    public static Tween TweenColorAlpha(this SpriteRenderer spriteRenderer, float to, float duration)
    {
        float to255 = to * 255.0f;
        Tween tween = Tween.To(() => spriteRenderer.color.a, x => spriteRenderer.color = 
            ColorUtils.ChangeAlpha(spriteRenderer.color, x), to, duration);
        tween.SetTarget(spriteRenderer);
        return tween;
    }
}
