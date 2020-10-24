using System;
using UnityEngine;
using Juce.Tween;

public static class JuceTweenRigidBody2DExtensions
{
    public static Tween TweenPosition(this Rigidbody2D rigidbody, Vector2 to, float duration)
    {
        Tween tween = Tween.To(() => rigidbody.position, x => rigidbody.MovePosition(x), () => to, duration);
        tween.SetTarget(rigidbody);
        return tween;
    }

    public static Tween TweenRotation(this Rigidbody rigidbody, Vector2 to, float duration)
    {
        Tween tween = Tween.To(() => (Vector2)rigidbody.rotation.eulerAngles, x => rigidbody.MoveRotation(Quaternion.Euler(x)), () => to, duration);
        tween.SetTarget(rigidbody);
        return tween;
    }
}
