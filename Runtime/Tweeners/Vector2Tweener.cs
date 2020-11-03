using UnityEngine;

namespace Juce.Tween
{
    internal class Vector2Tweener : Tweener<Vector2>
    {
        internal Vector2Tweener(Getter currValueGetter, Setter setter, Getter finalValueGetter, float duration)
            : base(currValueGetter, setter, finalValueGetter, duration, new Vector2Interpolator())
        {
        }
    }
}