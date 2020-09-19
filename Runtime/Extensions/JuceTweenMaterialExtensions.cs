using System;
using UnityEngine;
using Juce.Tween;

public static class JuceTweenMaterialExtensions
{
    public static Tween TweenColor(this Material material, Color to, float duration)
    {
        Tween tween = Tween.To(() => material.color, x => material.color = x, to, duration);
        tween.SetTarget(material);
        return tween;
    }

    public static Tween TweenColor(this Material material, Color to, string property, float duration)
    {
        Tween tween = Tween.To(() => material.GetColor(property), x => material.SetColor(property, x), to, duration);
        tween.SetTarget(material);
        return tween;
    }

    public static Tween TweenColor(this Material material, Color to, int propertyID, float duration)
    {
        Tween tween = Tween.To(() => material.GetColor(propertyID), x => material.SetColor(propertyID, x), to, duration);
        tween.SetTarget(material);
        return tween;
    }

    public static Tween TweenColorAlpha(this Material material, float to, float duration)
    {
        float to255 = to * 255.0f;
        Tween tween = Tween.To(() => material.color.a, x => material.color =
            ColorUtils.ChangeAlpha(material.color, x), to, duration);
        tween.SetTarget(material);
        return tween;
    }

    public static Tween TweenColorAlpha(this Material material, float to, string property, float duration)
    {
        float to255 = to * 255.0f;
        Tween tween = Tween.To(() => material.GetColor(property).a, x => material.SetColor(property,
            ColorUtils.ChangeAlpha(material.GetColor(property), x)), to, duration);
        tween.SetTarget(material);
        return tween;
    }

    public static Tween TweenColorAlpha(this Material material, float to, int propertyID, float duration)
    {
        float to255 = to * 255.0f;
        Tween tween = Tween.To(() => material.GetColor(propertyID).a, x => material.SetColor(propertyID,
            ColorUtils.ChangeAlpha(material.GetColor(propertyID), x)), to, duration);
        tween.SetTarget(material);
        return tween;
    }

    public static Tween TweenFloat(this Material material, float to, string property, float duration)
    {
        Tween tween = Tween.To(() => material.GetFloat(property), x => material.SetFloat(property, x), to, duration);
        tween.SetTarget(material);
        return tween;
    }

    public static Tween TweenFloat(this Material material, float to, int propertyID, float duration)
    {
        Tween tween = Tween.To(() => material.GetFloat(propertyID), x => material.SetFloat(propertyID, x), to, duration);
        tween.SetTarget(material);
        return tween;
    }

    public static Tween TweenVector(this Material material, Vector4 to, string property, float duration)
    {
        Tween tween = Tween.To(() => material.GetVector(property), x => material.SetVector(property, x), to, duration);
        tween.SetTarget(material);
        return tween;
    }

    public static Tween TweenVector(this Material material, Vector4 to, int propertyID, float duration)
    {
        Tween tween = Tween.To(() => material.GetVector(propertyID), x => material.SetVector(propertyID, x), to, duration);
        tween.SetTarget(material);
        return tween;
    }

    public static Tween TweenTextureOffset(this Material material, Vector2 to, float duration)
    {
        Tween tween = Tween.To(() => material.mainTextureOffset, x => material.mainTextureOffset = x, to, duration);
        tween.SetTarget(material);
        return tween;
    }

    public static Tween TweenTextureOffset(this Material material, Vector2 to, string property, float duration)
    {
        Tween tween = Tween.To(() => material.GetTextureOffset(property), x => material.SetTextureOffset(property, x), to, duration);
        tween.SetTarget(material);
        return tween;
    }

    public static Tween TweenTextureOffset(this Material material, Vector2 to, int propertyID, float duration)
    {
        Tween tween = Tween.To(() => material.GetTextureOffset(propertyID), x => material.SetTextureOffset(propertyID, x), to, duration);
        tween.SetTarget(material);
        return tween;
    }

    public static Tween TweenTextureScale(this Material material, Vector2 to, float duration)
    {
        Tween tween = Tween.To(() => material.mainTextureScale, x => material.mainTextureScale = x, to, duration);
        tween.SetTarget(material);
        return tween;
    }

    public static Tween TweenTextureScale(this Material material, Vector2 to, string property, float duration)
    {
        Tween tween = Tween.To(() => material.GetTextureScale(property), x => material.SetTextureScale(property, x), to, duration);
        tween.SetTarget(material);
        return tween;
    }

    public static Tween TweenTextureScale(this Material material, Vector2 to, int propertyID, float duration)
    {
        Tween tween = Tween.To(() => material.GetTextureScale(propertyID), x => material.SetTextureScale(propertyID, x), to, duration);
        tween.SetTarget(material);
        return tween;
    }
}
