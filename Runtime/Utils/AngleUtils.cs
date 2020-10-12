using System;
using UnityEngine;

namespace Juce.Tween
{
    internal static class AngleUtils
    {
        public static float Clamp360(float eulerAngles)
        {
            float result = eulerAngles - Mathf.CeilToInt(eulerAngles / 360f) * 360f;

            if (result < 0)
            {
                result += 360f;
            }

            return result;
        }
    }
}
