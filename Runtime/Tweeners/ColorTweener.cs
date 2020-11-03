using UnityEngine;

namespace Juce.Tween
{
    internal class ColorTweener : Tweener<Color>
    {
        internal ColorTweener(Getter currValueGetter, Setter setter, Getter finalValueGetter, float duration)
            : base(currValueGetter, setter, finalValueGetter, duration, new ColorInterpolator())
        {
        }
    }
}