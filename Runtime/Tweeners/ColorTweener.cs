using System;
using UnityEngine;

namespace Juce.Tween
{
	internal class ColorTweener : Tweener<Color>
	{
		internal ColorTweener(Getter getter, Setter setter, Color finalValue, float duration)
			: base(getter, setter, finalValue, duration, new ColorInterpolator())
		{

		}
	}
}
