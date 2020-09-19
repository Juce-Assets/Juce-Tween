using System;
using UnityEngine;
using Juce.Tween;

public static class AudioSourceExtensions
{
    public static Tween TweenVolume(this AudioSource audioSource, float to, float duration)
    {
        return Tween.To(() => audioSource.volume, x => audioSource.volume = x, to, duration,
        () =>
        {
            if (audioSource == null)
            {
                LogUtils.LogValidateError(typeof(AudioSource));

                return false;
            }

            return true;
        });
    }

    public static Tween TweenPitch(this AudioSource audioSource, float to, float duration)
    {
        return Tween.To(() => audioSource.pitch, x => audioSource.pitch = x, to, duration,
        () =>
        {
            if (audioSource == null)
            {
                LogUtils.LogValidateError(typeof(AudioSource));

                return false;
            }

            return true;
        });
    }
}
