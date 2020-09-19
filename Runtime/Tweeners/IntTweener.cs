using System;

namespace Juce.Tween
{
	internal class IntTweener : Tweener<int>
	{
		internal IntTweener(Getter getter, Setter setter, int finalValue, float duration)
			: base(getter, setter, finalValue, duration, new IntInterpolator())
		{

		}
	}
}
