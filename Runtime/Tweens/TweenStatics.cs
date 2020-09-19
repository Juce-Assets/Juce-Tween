using System;
using UnityEngine;

namespace Juce.Tween
{
    public partial class Tween
    {
        public static Tween To(Tweener<float>.Getter getter, Tweener<float>.Setter setter,
            float finalValue, float duration, Tweener<float>.Validate validate = null)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new FloatTweener(validate, getter, setter, finalValue, duration));
            return tween;
        }

        public static Tween To(Tweener<Vector2>.Getter getter, Tweener<Vector2>.Setter setter,
            Vector2 finalValue, float duration, Tweener<Vector2>.Validate validate = null)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new Vector2Tweener(validate, getter, setter, finalValue, duration));
            return tween;
        }

        public static Tween To(Tweener<Vector3>.Getter getter, Tweener<Vector3>.Setter setter,
            Vector3 finalValue, float duration, Tweener<Vector3>.Validate validate = null)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new Vector3Tweener(validate, getter, setter, finalValue, duration));
            return tween;
        }
    }
}
