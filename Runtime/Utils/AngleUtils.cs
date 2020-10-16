using System;
using UnityEngine;

namespace Juce.Tween
{
    internal static class AngleUtils
    {
        public static float Clamp360(float eulerAngles)
        {
            float result = Mathf.Abs(eulerAngles) - Mathf.CeilToInt(eulerAngles / 360f) * 360f;

            if (eulerAngles > 0)
            {
                if (result < 0)
                {
                    result += 360f;
                }
            }
            else
            {
                result = -result;

                if (result > 0)
                {
                    result -= 360f;
                }
            }

            return result;
        }
    }
}
