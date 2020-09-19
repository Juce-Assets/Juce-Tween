using System;
using UnityEngine;
using Juce.Tween;

public static class CameraExtensions
{
    public static Tween TweenAspect(this Camera camera, float to, float duration)
    {
        return Tween.To(() => camera.aspect, x => camera.aspect = x, to, duration,
        () =>
        {
            if (camera == null)
            {
                LogUtils.LogValidateError(typeof(Camera));

                return false;
            }

            return true;
        });
    }

    public static Tween TweenBackgroundColour(this Camera camera, float to, float duration)
    {
        return Tween.To(() => camera.backgroundColor, x => camera.aspect = x, to, duration,
        () =>
        {
            if (camera == null)
            {
                LogUtils.LogValidateError(typeof(Camera));

                return false;
            }

            return true;
        });
    }
}
