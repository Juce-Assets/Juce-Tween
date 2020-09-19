using System;
using UnityEngine;

namespace Juce.Tween
{
	internal class Vector3Tweener : Tweener<Vector3>
	{
		internal Vector3Tweener(Validate validate, Getter getter, Setter setter, Vector3 finalValue, float duration)
			: base(validate, getter, setter, finalValue, duration, new Vector3Interpolator())
		{

		}
	}
}
