using System;
using UnityEngine;
using Juce.Tween;

public static class LightExtensions
{
    public static Tween TweenColor(this Light light, Color to, float duration)
    {
        Tween tween = Tween.To(() => light.color, x => light.color = x, to, duration);

        tween.SetTarget(light);
        return tween;
    }

    public static Tween TweenIntensity(this Light light, float to, float duration)
    {
        Tween tween = Tween.To(() => light.intensity, x => light.intensity = x, to, duration);
        tween.SetTarget(light);
        return tween;
    }

    public static Tween TweenShadowStrenght(this Light light, float to, float duration)
    {
        Tween tween = Tween.To(() => light.shadowStrength, x => light.shadowStrength = x, to, duration);
        tween.SetTarget(light);
        return tween;
    }
}
