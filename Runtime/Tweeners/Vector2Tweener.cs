using System;
using UnityEngine;

namespace Juce.Tween
{
	internal class Vector2Tweener : Tweener<Vector2>
	{
		internal Vector2Tweener(Validate validate, Getter getter, Setter setter, Vector2 finalValue, float duration)
			: base(validate, getter, setter, finalValue, duration, new Vector2Interpolator())
		{

		}
	}
}
