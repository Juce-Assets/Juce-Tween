using System;
using UnityEngine;
using Juce.Tween;

public static class CameraExtensions
{
    public static Tween TweenAspect(this Camera camera, float to, float duration)
    {
        Tween tween = Tween.To(() => camera.aspect, x => camera.aspect = x, to, duration);
        tween.SetTarget(camera);
        return tween;
    }

    public static Tween TweenBackgroundColor(this Camera camera, Color to, float duration)
    {
        Tween tween = Tween.To(() => camera.backgroundColor, x => camera.backgroundColor = x, to, duration);
        tween.SetTarget(camera);
        return tween;
    }

    public static Tween TweenBackgroundColorAlpha(this Camera camera, float to, float duration)
    {
        float to255 = to * 255.0f;
        Tween tween = Tween.To(() => camera.backgroundColor.a, x => camera.backgroundColor = 
            ColorUtils.ChangeAlpha(camera.backgroundColor, x), to, duration);
        tween.SetTarget(camera);
        return tween;
    }

    public static Tween TweenFarClipPlane(this Camera camera, float to, float duration)
    {
        Tween tween = Tween.To(() => camera.farClipPlane, x => camera.farClipPlane = x, to, duration);
        tween.SetTarget(camera);
        return tween;
    }

    public static Tween TweenNearClipPlane(this Camera camera, float to, float duration)
    {
        Tween tween = Tween.To(() => camera.nearClipPlane, x => camera.nearClipPlane = x, to, duration);
        tween.SetTarget(camera);
        return tween;
    }

    public static Tween TweenFieldOfView(this Camera camera, float to, float duration)
    {
        Tween tween = Tween.To(() => camera.fieldOfView, x => camera.fieldOfView = x, to, duration);
        tween.SetTarget(camera);
        return tween;
    }

    public static Tween TweenOrthoSize(this Camera camera, float to, float duration)
    {
        Tween tween = Tween.To(() => camera.orthographicSize, x => camera.orthographicSize = x, to, duration);
        tween.SetTarget(camera);
        return tween;
    }

    public static Tween TweenRect(this Camera camera, Rect to, float duration)
    {
        Tween tween = Tween.To(() => camera.rect, x => camera.rect = x, to, duration);
        tween.SetTarget(camera);
        return tween;
    }

    public static Tween TweenPixelRect(this Camera camera, Rect to, float duration)
    {
        Tween tween = Tween.To(() => camera.pixelRect, x => camera.pixelRect = x, to, duration);
        tween.SetTarget(camera);
        return tween;
    }
}
