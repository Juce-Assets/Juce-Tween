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

        public static Color ChangeColorKeepingAlpha(Color color, Color alphaToKeep)
        {
            color.a = alphaToKeep.a;

            return color;
        }
    }
}