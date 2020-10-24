using System;
using UnityEngine;

namespace Juce.Tween
{
	internal class RectTweener : Tweener<Rect>
	{
		internal RectTweener(Getter currValueGetter, Setter setter, Getter finalValueGetter, float duration)
			: base(currValueGetter, setter, finalValueGetter, duration, new RectInterpolator())
		{

		}
	}
}
