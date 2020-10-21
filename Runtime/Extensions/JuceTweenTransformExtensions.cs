using System;
using UnityEngine;
using Juce.Tween;

public static class TransformExtensions
{
    public static Tween TweenPosition(this Transform transform, Vector3 to, float duration)
    {
        Tween tween = Tween.To(() => transform.position, x => transform.position = x, to, duration);
        tween.SetTarget(transform);
        return tween;
    }

    public static Tween TweenPositionX(this Transform transform, float to, float duration)
    {
        Tween tween = Tween.To(() => transform.position.x, 
            x => transform.position = new Vector3(x, transform.position.y, transform.position.z), to, duration);
        tween.SetTarget(transform);
        return tween;
    }

    public static Tween TweenPositionY(this Transform transform, float to, float duration)
    {
        Tween tween = Tween.To(() => transform.position.y, 
            y => transform.position = new Vector3(transform.position.x, y, transform.position.z), to, duration);
        tween.SetTarget(transform);
        return tween;
    }

    public static Tween TweenPositionZ(this Transform transform, float to, float duration)
    {
        Tween tween = Tween.To(() => transform.position.z, 
            z => transform.position = new Vector3(transform.position.x, transform.position.y, z), to, duration);
        tween.SetTarget(transform);
        return tween;
    }

    public static Tween TweenLocalPosition(this Transform transform, Vector3 to, float duration)
    {
        Tween tween = Tween.To(() => transform.localPosition, x => transform.localPosition = x, to, duration);
        tween.SetTarget(transform);
        return tween;
    }

    public static Tween TweenLocalPositionX(this Transform transform, float to, float duration)
    {
        Tween tween = Tween.To(() => transform.localPosition.x, 
            x => transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z), to, duration);
        tween.SetTarget(transform);
        return tween;
    }

    public static Tween TweenLocalPositionY(this Transform transform, float to, float duration)
    {
        Tween tween = Tween.To(() => transform.localPosition.y, 
            y => transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z), to, duration);
        tween.SetTarget(transform);
        return tween;
    }

    public static Tween TweenLocalPositionZ(this Transform transform, float to, float duration)
    {
        Tween tween = Tween.To(() => transform.localPosition.z, 
            z => transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, z), to, duration);
        tween.SetTarget(transform);
        return tween;
    }

    public static Tween TweenRotation(this Transform transform, Vector3 to, float duration, RotationMode mode)
    {
        Vector3 finalTo = to;

        if (mode == RotationMode.Fast)
        {
            finalTo = AngleUtils.Clamp360(to);
        }

        Tween tween = Tween.To(() =>
        {
            if (mode == RotationMode.Fast)
            {
                return finalTo + AngleUtils.DeltaAngle(finalTo, transform.rotation.eulerAngles);
            }

            return transform.rotation.eulerAngles;
        },
        x => transform.rotation = Quaternion.Euler(x), finalTo, duration);
        tween.SetTarget(transform);
        return tween;
    }

    public static Tween TweenRotationX(this Transform transform, float to, float duration, RotationMode mode)
    {
        float finalTo = to;

        if (mode == RotationMode.Fast)
        {
            finalTo = AngleUtils.Clamp360(to);
        }

        Tween tween = Tween.To(() =>
        {
            if (mode == RotationMode.Fast)
            {
                return finalTo + Mathf.DeltaAngle(finalTo, transform.rotation.eulerAngles.x);
            }

            return transform.rotation.eulerAngles.x;
        },
        x => transform.rotation = Quaternion.Euler(x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z), finalTo, duration);
        tween.SetTarget(transform);
        return tween;
    }

    public static Tween TweenRotationY(this Transform transform, float to, float duration, RotationMode mode)
    {
        float finalTo = to;

        if (mode == RotationMode.Fast)
        {
            finalTo = AngleUtils.Clamp360(to);
        }

        Tween tween = Tween.To(() =>
        {
            if (mode == RotationMode.Fast)
            {
                return finalTo + Mathf.DeltaAngle(finalTo, transform.rotation.eulerAngles.y);
            }

            return transform.rotation.eulerAngles.y;
        },
        y => transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, y, transform.rotation.eulerAngles.z), finalTo, duration);
        tween.SetTarget(transform);
        return tween;
    }

    public static Tween TweenRotationZ(this Transform transform, float to, float duration, RotationMode mode)
    {
        float finalTo = to;

        if (mode == RotationMode.Fast)
        {
            finalTo = AngleUtils.Clamp360(to);
        }

        Tween tween = Tween.To(() =>
        {
            if (mode == RotationMode.Fast)
            {
                return finalTo + Mathf.DeltaAngle(to, transform.rotation.eulerAngles.z);
            }

            return transform.rotation.eulerAngles.z;
        },
        z => transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, z), finalTo, duration);
        tween.SetTarget(transform);
        return tween;
    }

    public static Tween TweenLocalRotation(this Transform transform, Vector3 to, float duration, RotationMode mode)
    {
        Vector3 finalTo = to;

        if (mode == RotationMode.Fast)
        {
            finalTo = AngleUtils.Clamp360(to);
        }

        Tween tween = Tween.To(() =>
        {
            if (mode == RotationMode.Fast)
            {
                return finalTo + AngleUtils.DeltaAngle(finalTo, transform.localRotation.eulerAngles);
            }

            return transform.rotation.eulerAngles;
        },
        x => transform.localRotation = Quaternion.Euler(x), finalTo, duration);
        tween.SetTarget(transform);
        return tween;
    }

    public static Tween TweenLocalRotationX(this Transform transform, float to, float duration, RotationMode mode)
    {
        float finalTo = to;

        if (mode == RotationMode.Fast)
        {
            finalTo = AngleUtils.Clamp360(to);
        }

        Tween tween = Tween.To(() =>
        {
            if (mode == RotationMode.Fast)
            {
                return finalTo + Mathf.DeltaAngle(finalTo, transform.localRotation.eulerAngles.x);
            }

            return transform.localRotation.eulerAngles.x;
        },
        x => transform.localRotation = Quaternion.Euler(x, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z), finalTo, duration);
        tween.SetTarget(transform);
        return tween;
    }

    public static Tween TweenLocalRotationY(this Transform transform, float to, float duration, RotationMode mode)
    {
        float finalTo = to;

        if (mode == RotationMode.Fast)
        {
            finalTo = AngleUtils.Clamp360(to);
        }

        Tween tween = Tween.To(() =>
        {
            if (mode == RotationMode.Fast)
            {
                return finalTo + Mathf.DeltaAngle(finalTo, transform.localRotation.eulerAngles.y);
            }

            return transform.localRotation.eulerAngles.y;
        },
        y => transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, y, transform.localRotation.eulerAngles.z), finalTo, duration);
        tween.SetTarget(transform);
        return tween;
    }

    public static Tween TweenLocalRotationZ(this Transform transform, float to, float duration, RotationMode mode)
    {
        float finalTo = to;

        if (mode == RotationMode.Fast)
        {
            finalTo = AngleUtils.Clamp360(to);
        }

        Tween tween = Tween.To(() => 
        {
            if(mode == RotationMode.Fast)
            {
                return finalTo + Mathf.DeltaAngle(finalTo, transform.localRotation.eulerAngles.z);
            }

            return transform.localRotation.eulerAngles.z;
        }, 
        z => transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, z), finalTo, duration);
        tween.SetTarget(transform);
        return tween;
    }

    public static Tween TweenLocalScale(this Transform transform, Vector3 to, float duration)
    {
        Tween tween = Tween.To(() => transform.localScale, x => transform.localScale = x, to, duration);
        tween.SetTarget(transform);
        return tween;
    }

    public static Tween TweenLocalScaleX(this Transform transform, float to, float duration)
    {
        Tween tween = Tween.To(() => transform.localScale.x, 
            x => transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z), to, duration);
        tween.SetTarget(transform);
        return tween;
    }

    public static Tween TweenLocalScaleY(this Transform transform, float to, float duration)
    {
        Tween tween = Tween.To(() => transform.localScale.y, 
            y => transform.localScale = new Vector3(transform.localScale.x, y, transform.localScale.z), to, duration);
        tween.SetTarget(transform);
        return tween;
    }

    public static Tween TweenLocalScaleZ(this Transform transform, float to, float duration)
    {
        Tween tween = Tween.To(() => transform.localScale.z, 
            z => transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, z), to, duration);
        tween.SetTarget(transform);
        return tween;
    }
}
