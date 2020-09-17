using System;
using UnityEngine;

namespace Juce.Tween
{
	internal class Vector3Tweener : Tweener<Vector3>
	{
		internal Vector3Tweener(Vector3 initialValue, Setter setter, Vector3 finalValue, float duration)
			: base(initialValue, setter, finalValue, duration, new Vector3Interpolator())
		{

		}
	}
}
