using Juce.Tween;
using UnityEngine;

public static class JuceTweenRectTransformExtensions
{
    public static Tween TweenAnchorMax(this RectTransform rectTransform, Vector2 to, float duration)
    {
        Tween tween = Tween.To(() => rectTransform.anchorMax, x => rectTransform.anchorMax = x, () => to, duration);
        tween.SetTarget(rectTransform);
        return tween;
    }

    public static Tween TweenAnchorMaxX(this RectTransform rectTransform, float to, float duration)
    {
        Tween tween = Tween.To(() => rectTransform.anchorMax.x,
            x => rectTransform.anchorMax = new Vector2(x, rectTransform.anchorMax.y), () => to, duration);
        tween.SetTarget(rectTransform);
        return tween;
    }

    public static Tween TweenAnchorMaxY(this RectTransform rectTransform, float to, float duration)
    {
        Tween tween = Tween.To(() => rectTransform.anchorMax.y,
        y => rectTransform.anchorMax = new Vector2(rectTransform.anchorMax.x, y), () => to, duration);
        tween.SetTarget(rectTransform);
        return tween;
    }

    public static Tween TweenAnchorMin(this RectTransform rectTransform, Vector2 to, float duration)
    {
        Tween tween = Tween.To(() => rectTransform.anchorMin, x => rectTransform.anchorMin = x, () => to, duration);
        tween.SetTarget(rectTransform);
        return tween;
    }

    public static Tween TweenAnchorMinX(this RectTransform rectTransform, float to, float duration)
    {
        Tween tween = Tween.To(() => rectTransform.anchorMin.x,
            x => rectTransform.anchorMin = new Vector2(x, rectTransform.anchorMin.y), () => to, duration);
        tween.SetTarget(rectTransform);
        return tween;
    }

    public static Tween TweenAnchorMinY(this RectTransform rectTransform, float to, float duration)
    {
        Tween tween = Tween.To(() => rectTransform.anchorMin.y,
        y => rectTransform.anchorMin = new Vector2(rectTransform.anchorMin.x, y), () => to, duration);
        tween.SetTarget(rectTransform);
        return tween;
    }

    public static Tween TweenAnchoredPosition(this RectTransform rectTransform, Vector2 to, float duration)
    {
        Tween tween = Tween.To(() => rectTransform.anchoredPosition, x => rectTransform.anchoredPosition = x, () => to, duration);
        tween.SetTarget(rectTransform);
        return tween;
    }

    public static Tween TweenAnchoredPositionX(this RectTransform transform, float to, float duration)
    {
        Tween tween = Tween.To(() => transform.anchoredPosition.x,
            x => transform.anchoredPosition = new Vector2(x, transform.anchoredPosition.y), () => to, duration);
        tween.SetTarget(transform);
        return tween;
    }

    public static Tween TweenAnchoredPositionY(this RectTransform transform, float to, float duration)
    {
        Tween tween = Tween.To(() => transform.anchoredPosition.y,
            y => transform.anchoredPosition = new Vector2(transform.anchoredPosition.x, y), () => to, duration);
        tween.SetTarget(transform);
        return tween;
    }

    public static Tween TweenAnchoredPosition3D(this RectTransform rectTransform, Vector3 to, float duration)
    {
        Tween tween = Tween.To(() => rectTransform.anchoredPosition3D, x => rectTransform.anchoredPosition3D = x, () => to, duration);
        tween.SetTarget(rectTransform);
        return tween;
    }

    public static Tween TweenPivot(this RectTransform rectTransform, Vector2 to, float duration)
    {
        Tween tween = Tween.To(() => rectTransform.pivot, x => rectTransform.pivot = x, () => to, duration);
        tween.SetTarget(rectTransform);
        return tween;
    }

    public static Tween TweenSizeDelta(this RectTransform rectTransform, Vector2 to, float duration)
    {
        Tween tween = Tween.To(() => rectTransform.sizeDelta, x => rectTransform.sizeDelta = x, () => to, duration);
        tween.SetTarget(rectTransform);
        return tween;
    }

    public static Tween TweenSizeDeltaX(this RectTransform rectTransform, float to, float duration)
    {
        Tween tween = Tween.To(() => rectTransform.sizeDelta.x,
            x => rectTransform.sizeDelta = new Vector2(x, rectTransform.sizeDelta.y), () => to, duration);
        tween.SetTarget(rectTransform);
        return tween;
    }

    public static Tween TweenSizeDeltaY(this RectTransform rectTransform, float to, float duration)
    {
        Tween tween = Tween.To(() => rectTransform.sizeDelta.y,
            y => rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, y), () => to, duration);
        tween.SetTarget(rectTransform);
        return tween;
    }
}