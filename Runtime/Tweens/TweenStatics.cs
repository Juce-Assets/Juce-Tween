using System;
using UnityEngine;

namespace Juce.Tween
{
    public partial class Tween
    {
        public static Tween To(Tweener<int>.Getter currValueGetter, Tweener<int>.Setter setter,
            Tweener<int>.Getter finalValueGetter, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new IntTweener(currValueGetter, setter, finalValueGetter, duration));
            return tween;
        }

        public static Tween To(Tweener<float>.Getter currValueGetter, Tweener<float>.Setter setter,
            Tweener<float>.Getter finalValueGetter, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new FloatTweener(currValueGetter, setter, finalValueGetter, duration));
            return tween;
        }

        public static Tween To(Tweener<Vector2>.Getter currValueGetter, Tweener<Vector2>.Setter setter,
            Tweener<Vector2>.Getter finalValueGetter, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new Vector2Tweener(currValueGetter, setter, finalValueGetter, duration));
            return tween;
        }

        public static Tween To(Tweener<Vector3>.Getter currValueGetter, Tweener<Vector3>.Setter setter,
            Tweener<Vector3>.Getter finalValueGetter, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new Vector3Tweener(currValueGetter, setter, finalValueGetter, duration));
            return tween;
        }

        public static Tween To(Tweener<Vector4>.Getter currValueGetter, Tweener<Vector4>.Setter setter,
            Tweener<Vector4>.Getter finalValueGetter, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new Vector4Tweener(currValueGetter, setter, finalValueGetter, duration));
            return tween;
        }

        public static Tween To(Tweener<Rect>.Getter currValueGetter, Tweener<Rect>.Setter setter,
            Tweener<Rect>.Getter finalValueGetter, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new RectTweener(currValueGetter, setter, finalValueGetter, duration));
            return tween;
        }

        public static Tween To(Tweener<Color>.Getter currValueGetter, Tweener<Color>.Setter setter,
            Tweener<Color>.Getter finalValueGetter, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            tween.Add(new ColorTweener(currValueGetter, setter, finalValueGetter, duration));
            return tween;
        }

        // ---

        public static Tween To(Tweener<int>.Getter[] currValueGetter, Tweener<int>.Setter[] setter,
          Tweener<int>.Getter[] finalValueGetter, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            for (int i = 0; i < currValueGetter.Length; ++i)
            {
                if (setter.Length > i && finalValueGetter.Length > i)
                {
                    tween.Add(new IntTweener(currValueGetter[i], setter[i], finalValueGetter[i], duration));
                }
            }
            return tween;
        }

        public static Tween To(Tweener<float>.Getter[] currValueGetter, Tweener<float>.Setter[] setter,
            Tweener<float>.Getter[] finalValueGetter, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            for (int i = 0; i < currValueGetter.Length; ++i)
            {
                if (setter.Length > i && finalValueGetter.Length > i)
                {
                    tween.Add(new FloatTweener(currValueGetter[i], setter[i], finalValueGetter[i], duration));
                }
            }
            return tween;
        }

        public static Tween To(Tweener<Vector2>.Getter[] currValueGetter, Tweener<Vector2>.Setter[] setter,
            Tweener<Vector2>.Getter[] finalValueGetter, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            for (int i = 0; i < currValueGetter.Length; ++i)
            {
                if (setter.Length > i && finalValueGetter.Length > i)
                {
                    tween.Add(new Vector2Tweener(currValueGetter[i], setter[i], finalValueGetter[i], duration));
                }
            }
            return tween;
        }

        public static Tween To(Tweener<Vector3>.Getter[] currValueGetter, Tweener<Vector3>.Setter[] setter,
            Tweener<Vector3>.Getter[] finalValueGetter, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            for (int i = 0; i < currValueGetter.Length; ++i)
            {
                if (setter.Length > i && finalValueGetter.Length > i)
                {
                    tween.Add(new Vector3Tweener(currValueGetter[i], setter[i], finalValueGetter[i], duration));
                }
            }
            return tween;
        }

        public static Tween To(Tweener<Vector4>.Getter[] currValueGetter, Tweener<Vector4>.Setter[] setter,
            Tweener<Vector4>.Getter[] finalValueGetter, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            for (int i = 0; i < currValueGetter.Length; ++i)
            {
                if (setter.Length > i && finalValueGetter.Length > i)
                {
                    tween.Add(new Vector4Tweener(currValueGetter[i], setter[i], finalValueGetter[i], duration));
                }
            }
            return tween;
        }

        public static Tween To(Tweener<Rect>.Getter[] currValueGetter, Tweener<Rect>.Setter[] setter,
            Tweener<Rect>.Getter[] finalValueGetter, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            for (int i = 0; i < currValueGetter.Length; ++i)
            {
                if (setter.Length > i && finalValueGetter.Length > i)
                {
                    tween.Add(new RectTweener(currValueGetter[i], setter[i], finalValueGetter[i], duration));
                }
            }
            return tween;
        }

        public static Tween To(Tweener<Color>.Getter[] currValueGetter, Tweener<Color>.Setter[] setter,
            Tweener<Color>.Getter[] finalValueGetter, float duration)
        {
            InterpolationTween tween = new InterpolationTween();
            for (int i = 0; i < currValueGetter.Length; ++i)
            {
                if (setter.Length > i && finalValueGetter.Length > i)
                {
                    tween.Add(new ColorTweener(currValueGetter[i], setter[i], finalValueGetter[i], duration));
                }
            }
            return tween;
        }
    }
}
