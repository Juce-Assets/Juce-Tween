using System;

namespace Juce.Tween
{
    internal class FloatTweener : Tweener<float>
    {
		internal FloatTweener(Getter getter, Setter setter, float finalValue, float duration)
			: base(getter, setter, finalValue, duration, new FloatInterpolator())
		{

		}
	}
}
