using System;
using UnityEngine;

namespace Juce.Tween
{
	internal class Vector4Tweener : Tweener<Vector4>
	{
		internal Vector4Tweener(Getter currValueGetter, Setter setter, Getter finalValueGetter, float duration)
			: base(currValueGetter, setter, finalValueGetter, duration, new Vector4Interpolator())
		{

		}
	}
}
