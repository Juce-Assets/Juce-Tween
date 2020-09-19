using System;

namespace Juce.Tween
{
    internal class FloatTweener : Tweener<float>
    {
		internal FloatTweener(Validate validate, Getter getter, Setter setter, float finalValue, float duration)
			: base(validate, getter, setter, finalValue, duration, new FloatInterpolator())
		{

		}
	}
}
