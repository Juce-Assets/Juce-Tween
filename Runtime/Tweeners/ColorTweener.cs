using System;
using UnityEngine;

namespace Juce.Tween
{
	internal class ColorTweener : Tweener<Color>
	{
		internal ColorTweener(Validate validate, Getter getter, Setter setter, Color finalValue, float duration)
			: base(validate, getter, setter, finalValue, duration, new ColorInterpolator())
		{

		}
	}
}
