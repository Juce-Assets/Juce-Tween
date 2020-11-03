using UnityEngine;

namespace Juce.Tween
{
    internal class Vector3Tweener : Tweener<Vector3>
    {
        internal Vector3Tweener(Getter currValueGetter, Setter setter, Getter finalValueGetter, float duration)
            : base(currValueGetter, setter, finalValueGetter, duration, new Vector3Interpolator())
        {
        }
    }
}