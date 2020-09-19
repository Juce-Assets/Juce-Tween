using System;
using UnityEngine;

namespace Juce.Tween
{
    public partial class Tween
    {
        public static Tween To(Tweener<float>.Getter getter, Tweener<float>.Setter setter,
            float finalValue, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new FloatTweener(getter, setter, finalValue, duration));
            return tween;
        }

        public static Tween To(Tweener<Vector2>.Getter getter, Tweener<Vector2>.Setter setter,
            Vector2 finalValue, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new Vector2Tweener(getter, setter, finalValue, duration));
            return tween;
        }

        public static Tween To(Tweener<Vector3>.Getter getter, Tweener<Vector3>.Setter setter,
            Vector3 finalValue, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new Vector3Tweener(getter, setter, finalValue, duration));
            return tween;
        }

        public static Tween To(Tweener<Vector4>.Getter getter, Tweener<Vector4>.Setter setter,
            Vector4 finalValue, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new Vector4Tweener(getter, setter, finalValue, duration));
            return tween;
        }

        public static Tween To(Tweener<Rect>.Getter getter, Tweener<Rect>.Setter setter,
            Rect finalValue, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new RectTweener(getter, setter, finalValue, duration));
            return tween;
        }

        public static Tween To(Tweener<Color>.Getter getter, Tweener<Color>.Setter setter,
            Color finalValue, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new ColorTweener(getter, setter, finalValue, duration));
            return tween;
        }
    }
}
