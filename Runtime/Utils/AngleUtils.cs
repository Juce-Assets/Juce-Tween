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

        public static Vector3 Clamp360(Vector3 eulerAngles)
        {
            return new Vector3(Clamp360(eulerAngles.x), Clamp360(eulerAngles.y), Clamp360(eulerAngles.z));
        }

        public static Vector3 DeltaAngle(Vector3 current, Vector3 target)
        {
            return new Vector3(Mathf.DeltaAngle(current.x, target.x), Mathf.DeltaAngle(current.y, target.y), Mathf.DeltaAngle(current.z, target.z));
        }
    }
}