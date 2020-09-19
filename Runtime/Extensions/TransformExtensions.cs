using System;
using UnityEngine;
using Juce.Tween;

public static class TransformExtensions
{
    public static Tween TweenPosition(this Transform transform, Vector3 to, float duration)
    {
        return Tween.To(() => transform.position, x => transform.position = x, to, duration,
        () => 
        {
            if(transform == null)
            {
                LogUtils.LogValidateError(typeof(Transform));

                return false;
            }

            return true;
        });
    }

    public static Tween TweenLocalPosition(this Transform transform, Vector3 to, float duration)
    {
        return Tween.To(() => transform.localPosition, x => transform.localPosition = x, to, duration,
        () =>
        {
            if (transform == null)
            {
                LogUtils.LogValidateError(typeof(Transform));

                return false;
            }

            return true;
        });
    }

    public static Tween TweenRotation(this Transform transform, Vector3 to, float duration)
    {
        return Tween.To(() => transform.rotation.eulerAngles, x => transform.rotation = Quaternion.Euler(x), to, duration,
        () =>
        {
            if (transform == null)
            {
                LogUtils.LogValidateError(typeof(Transform));

                return false;
            }

            return true;
        });
    }

    public static Tween TweenLocalRotation(this Transform transform, Vector3 to, float duration)
    {
        return Tween.To(() => transform.localRotation.eulerAngles, x => transform.localRotation = Quaternion.Euler(x), to, duration,
        () =>
        {
            if (transform == null)
            {
                LogUtils.LogValidateError(typeof(Transform));

                return false;
            }

            return true;
        });
    }

    public static Tween TweenLocalScale(this Transform transform, Vector3 to, float duration)
    {
        return Tween.To(() => transform.localScale, x => transform.localScale = x, to, duration,
        () =>
        {
            if (transform == null)
            {
                LogUtils.LogValidateError(typeof(Transform));

                return false;
            }

            return true;
        });
    }
}
