using System;

namespace Juce.Tween
{
    internal class FloatTweener : Tweener<float>
    {
		internal FloatTweener(float initialValue, Setter setter, float finalValue, float duration)
			: base(initialValue, setter, finalValue, duration, new FloatInterpolator())
		{

		}
	}
}
