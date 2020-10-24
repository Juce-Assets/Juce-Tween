using System;

namespace Juce.Tween
{
    internal class FloatTweener : Tweener<float>
    {
		internal FloatTweener(Getter currValueGetter, Setter setter, Getter finalValueGetter, float duration)
			: base(currValueGetter, setter, finalValueGetter, duration, new FloatInterpolator())
		{

		}
	}
}
