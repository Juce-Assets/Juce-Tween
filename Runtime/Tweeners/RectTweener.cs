using System;
using UnityEngine;

namespace Juce.Tween
{
	internal class RectTweener : Tweener<Rect>
	{
		internal RectTweener(Getter getter, Setter setter, Rect finalValue, float duration)
			: base(getter, setter, finalValue, duration, new RectInterpolator())
		{

		}
	}
}
