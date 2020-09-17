using System;
using UnityEngine;

namespace Juce.Tween
{
	internal class Vector2Tweener : Tweener<Vector2>
	{
		internal Vector2Tweener(Vector2 initialValue, Setter setter, Vector2 finalValue, float duration)
			: base(initialValue, setter, finalValue, duration, new Vector2Interpolator())
		{

		}
	}
}
