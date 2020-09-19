using System;
using UnityEngine;

namespace Juce.Tween
{
	internal class Vector4Tweener : Tweener<Vector4>
	{
		internal Vector4Tweener(Getter getter, Setter setter, Vector4 finalValue, float duration)
			: base(getter, setter, finalValue, duration, new Vector4Interpolator())
		{

		}
	}
}
