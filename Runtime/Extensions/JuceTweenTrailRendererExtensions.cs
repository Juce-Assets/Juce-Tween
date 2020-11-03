using Juce.Tween;
using UnityEngine;

public static class JuceTweenTrailRendererExtensions
{
    public static Tween TweenTime(this TrailRenderer trailRenderer, float to, float duration)
    {
        Tween tween = Tween.To(() => trailRenderer.time, x => trailRenderer.time = x, () => to, duration);
        tween.SetTarget(trailRenderer);
        return tween;
    }

    public static Tween TweenStartColor(this TrailRenderer trailRenderer, Color to, float duration)
    {
        Tween tween = Tween.To(() => trailRenderer.startColor, x => trailRenderer.startColor = x, () => to, duration);
        tween.SetTarget(trailRenderer);
        return tween;
    }

    public static Tween TweenEndColor(this TrailRenderer trailRenderer, Color to, float duration)
    {
        Tween tween = Tween.To(() => trailRenderer.endColor, x => trailRenderer.endColor = x, () => to, duration);
        tween.SetTarget(trailRenderer);
        return tween;
    }

    public static Tween TweenColor(this TrailRenderer trailRenderer, Color to, float duration)
    {
        Tween startTween = TweenStartColor(trailRenderer, to, duration);
        Tween endTween = TweenEndColor(trailRenderer, to, duration);

        GroupTween groupTween = new GroupTween();
        groupTween.Add(startTween);
        groupTween.Add(endTween);

        return groupTween;
    }

    public static Tween TweenStartColorNoAlpha(this TrailRenderer trailRenderer, Color to, float duration)
    {
        Tween tween = Tween.To(() => trailRenderer.startColor, x => trailRenderer.startColor =
            ColorUtils.ChangeColorKeepingAlpha(x, trailRenderer.startColor), () => to, duration);
        tween.SetTarget(trailRenderer);
        return tween;
    }

    public static Tween TweenEndColorNoAlpha(this TrailRenderer trailRenderer, Color to, float duration)
    {
        Tween tween = Tween.To(() => trailRenderer.endColor, x => trailRenderer.endColor =
            ColorUtils.ChangeColorKeepingAlpha(x, trailRenderer.endColor), () => to, duration);
        tween.SetTarget(trailRenderer);
        return tween;
    }

    public static Tween TweenColorNoAlpha(this TrailRenderer trailRenderer, Color to, float duration)
    {
        Tween startTween = TweenStartColorNoAlpha(trailRenderer, to, duration);
        Tween endTween = TweenEndColorNoAlpha(trailRenderer, to, duration);

        GroupTween groupTween = new GroupTween();
        groupTween.Add(startTween);
        groupTween.Add(endTween);

        return groupTween;
    }

    public static Tween TweenStartColorAlpha(this TrailRenderer trailRenderer, float to, float duration)
    {
        float to255 = to * 255.0f;
        Tween tween = Tween.To(() => trailRenderer.startColor.a, x => trailRenderer.startColor =
            ColorUtils.ChangeAlpha(trailRenderer.startColor, x), () => to, duration);
        tween.SetTarget(trailRenderer);
        return tween;
    }

    public static Tween TweenEndColorAlpha(this TrailRenderer trailRenderer, float to, float duration)
    {
        float to255 = to * 255.0f;
        Tween tween = Tween.To(() => trailRenderer.endColor.a, x => trailRenderer.endColor =
            ColorUtils.ChangeAlpha(trailRenderer.endColor, x), () => to, duration);
        tween.SetTarget(trailRenderer);
        return tween;
    }

    public static Tween TweenColorAlpha(this TrailRenderer trailRenderer, float to, float duration)
    {
        Tween startTween = TweenStartColorAlpha(trailRenderer, to, duration);
        Tween endTween = TweenEndColorAlpha(trailRenderer, to, duration);

        GroupTween groupTween = new GroupTween();
        groupTween.Add(startTween);
        groupTween.Add(endTween);

        return groupTween;
    }

    public static Tween TweenStartWidth(this TrailRenderer trailRenderer, float to, float duration)
    {
        Tween tween = Tween.To(() => trailRenderer.startWidth, x => trailRenderer.startWidth = x, () => to, duration);
        tween.SetTarget(trailRenderer);
        return tween;
    }

    public static Tween TweenEndWidth(this TrailRenderer trailRenderer, float to, float duration)
    {
        Tween tween = Tween.To(() => trailRenderer.endWidth, x => trailRenderer.endWidth = x, () => to, duration);
        tween.SetTarget(trailRenderer);
        return tween;
    }

    public static Tween TweenWidth(this TrailRenderer trailRenderer, float to, float duration)
    {
        Tween startTween = TweenStartWidth(trailRenderer, to, duration);
        Tween endTween = TweenEndWidth(trailRenderer, to, duration);

        GroupTween groupTween = new GroupTween();
        groupTween.Add(startTween);
        groupTween.Add(endTween);

        return groupTween;
    }
}