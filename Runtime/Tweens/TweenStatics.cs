using System;
using UnityEngine;

namespace Juce.Tween
{
    public partial class Tween
    {
        public static Tween To(Tweener<int>.Getter getter, Tweener<int>.Setter setter,
            int finalValue, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new IntTweener(getter, setter, finalValue, duration));
            return tween;
        }

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

        // ---

        public static Tween To(Tweener<int>.Getter[] getter, Tweener<int>.Setter[] setter,
          int[] finalValue, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            for (int i = 0; i < getter.Length; ++i)
            {
                if (setter.Length > i && finalValue.Length > i)
                {
                    tween.Add(new IntTweener(getter[i], setter[i], finalValue[i], duration));
                }
            }
            return tween;
        }

        public static Tween To(Tweener<float>.Getter[] getter, Tweener<float>.Setter[] setter,
            float[] finalValue, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            for (int i = 0; i < getter.Length; ++i)
            {
                if (setter.Length > i && finalValue.Length > i)
                {
                    tween.Add(new FloatTweener(getter[i], setter[i], finalValue[i], duration));
                }
            }
            return tween;
        }

        public static Tween To(Tweener<Vector2>.Getter[] getter, Tweener<Vector2>.Setter[] setter,
            Vector2[] finalValue, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            for (int i = 0; i < getter.Length; ++i)
            {
                if (setter.Length > i && finalValue.Length > i)
                {
                    tween.Add(new Vector2Tweener(getter[i], setter[i], finalValue[i], duration));
                }
            }
            return tween;
        }

        public static Tween To(Tweener<Vector3>.Getter[] getter, Tweener<Vector3>.Setter[] setter,
            Vector3[] finalValue, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            for (int i = 0; i < getter.Length; ++i)
            {
                if (setter.Length > i && finalValue.Length > i)
                {
                    tween.Add(new Vector3Tweener(getter[i], setter[i], finalValue[i], duration));
                }
            }
            return tween;
        }

        public static Tween To(Tweener<Vector4>.Getter[] getter, Tweener<Vector4>.Setter[] setter,
            Vector4[] finalValue, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            for (int i = 0; i < getter.Length; ++i)
            {
                if (setter.Length > i && finalValue.Length > i)
                {
                    tween.Add(new Vector4Tweener(getter[i], setter[i], finalValue[i], duration));
                }
            }
            return tween;
        }

        public static Tween To(Tweener<Rect>.Getter[] getter, Tweener<Rect>.Setter[] setter,
            Rect[] finalValue, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            for (int i = 0; i < getter.Length; ++i)
            {
                if (setter.Length > i && finalValue.Length > i)
                {
                    tween.Add(new RectTweener(getter[i], setter[i], finalValue[i], duration));
                }
            }
            return tween;
        }

        public static Tween To(Tweener<Color>.Getter[] getter, Tweener<Color>.Setter[] setter,
            Color[] finalValue, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            for (int i = 0; i < getter.Length; ++i)
            {
                if (setter.Length > i && finalValue.Length > i)
                {
                    tween.Add(new ColorTweener(getter[i], setter[i], finalValue[i], duration));
                }
            }
            return tween;
        }
    }
}
