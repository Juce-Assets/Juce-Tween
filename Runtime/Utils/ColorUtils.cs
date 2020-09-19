using System;
using UnityEngine;

namespace Juce.Tween
{
    internal static class ColorUtils
    {
        public static Color ChangeAlpha(Color color, float alpha)
        {
            color.a = alpha;

            return color;
        }
    }
}
