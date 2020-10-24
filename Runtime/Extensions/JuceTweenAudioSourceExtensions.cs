using System;
using UnityEngine;
using Juce.Tween;

public static class JuceTweenAudioSourceExtensions
{
    public static Tween TweenVolume(this AudioSource audioSource, float to, float duration)
    {
        Tween tween = Tween.To(() => audioSource.volume, x => audioSource.volume = x, () => to, duration);
        tween.SetTarget(audioSource);
        return tween;
    }

    public static Tween TweenPitch(this AudioSource audioSource, float to, float duration)
    {
        Tween tween = Tween.To(() => audioSource.pitch, x => audioSource.pitch = x, () => to, duration);
        tween.SetTarget(audioSource);
        return tween;
    }
}
