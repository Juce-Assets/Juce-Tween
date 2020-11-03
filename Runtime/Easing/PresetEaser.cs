using UnityEngine;

namespace Juce.Tween
{
    internal class PresetEaser
    {
        private const float C1 = 1.70158f;
        private const float C2 = C1 * 1.525f;
        private const float C3 = C1 + 1;
        private const float C4 = (2 * Mathf.PI) / 3;
        private const float C5 = (2 * Mathf.PI) / 4.5f;

        private const float N1 = 7.5625f;
        private const float D1 = 2.75f;

        public static EaseDelegate GetEaseDelegate(Ease ease)
        {
            EaseDelegate result;

            switch (ease)
            {
                default:
                case Ease.Linear: result = Linear; break;
                case Ease.InSine: result = InSine; break;
                case Ease.OutSine: result = OutSine; break;
                case Ease.InOutSine: result = InOutSine; break;
                case Ease.InQuad: result = InQuad; break;
                case Ease.OutQuad: result = OutQuad; break;
                case Ease.InOutQuad: result = InOutQuad; break;
                case Ease.InCubic: result = InCubic; break;
                case Ease.OutCubic: result = OutCubic; break;
                case Ease.InOutCubic: result = InOutCubic; break;
                case Ease.InQuart: result = InQuart; break;
                case Ease.OutQuart: result = OutQuart; break;
                case Ease.InOutQuart: result = InOutQuart; break;
                case Ease.InQuint: result = InQuint; break;
                case Ease.OutQuint: result = OutQuint; break;
                case Ease.InOutQuint: result = InOutQuint; break;
                case Ease.InExpo: result = InExpo; break;
                case Ease.OutExpo: result = OutExpo; break;
                case Ease.InOutExpo: result = InOutExpo; break;
                case Ease.InCirc: result = InCirc; break;
                case Ease.OutCirc: result = OutCirc; break;
                case Ease.InOutCirc: result = InOutCirc; break;
                case Ease.InBack: result = InBack; break;
                case Ease.OutBack: result = OutBack; break;
                case Ease.InOutBack: result = InOutBack; break;
                case Ease.InElastic: result = InElastic; break;
                case Ease.OutElastic: result = OutElastic; break;
                case Ease.InOutElastic: result = InOutElastic; break;
                case Ease.InBounce: result = InBounce; break;
                case Ease.OutBounce: result = OutBounce; break;
                case Ease.InOutBounce: result = InOutBounce; break;
            }

            return result;
        }

        private static float Linear(float a, float b, float t)
        {
            return Lerp(a, b, t);
        }

        private static float InSine(float a, float b, float t)
        {
            return Lerp(a, b, 1 - Mathf.Cos((t * Mathf.PI) / 2f));
        }

        private static float OutSine(float a, float b, float t)
        {
            return Lerp(a, b, Mathf.Sin((t * Mathf.PI) / 2f));
        }

        private static float InOutSine(float a, float b, float t)
        {
            return Lerp(a, b, -(Mathf.Cos(t * Mathf.PI) - 1) / 2f);
        }

        private static float InQuad(float a, float b, float t)
        {
            return Lerp(a, b, t * t);
        }

        private static float OutQuad(float a, float b, float t)
        {
            return Lerp(a, b, 1 - (1 - t) * (1 - t));
        }

        private static float InOutQuad(float a, float b, float t)
        {
            return Lerp(a, b, t < 0.5f ? 2 * t * t : 1 - Mathf.Pow(-2 * t + 2, 2) / 2);
        }

        private static float InCubic(float a, float b, float t)
        {
            return Lerp(a, b, t * t * t);
        }

        private static float OutCubic(float a, float b, float t)
        {
            return Lerp(a, b, 1 - Mathf.Pow(1 - t, 3));
        }

        private static float InOutCubic(float a, float b, float t)
        {
            return Lerp(a, b, t < 0.5f ? 4 * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 3) / 2);
        }

        private static float InQuart(float a, float b, float t)
        {
            return Lerp(a, b, t * t * t * t);
        }

        private static float OutQuart(float a, float b, float t)
        {
            return Lerp(a, b, 1 - Mathf.Pow(1 - t, 4));
        }

        private static float InOutQuart(float a, float b, float t)
        {
            return Lerp(a, b, t < 0.5f ? 8 * t * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 4) / 2);
        }

        private static float InQuint(float a, float b, float t)
        {
            return Lerp(a, b, t * t * t * t * t);
        }

        private static float OutQuint(float a, float b, float t)
        {
            return Lerp(a, b, 1 - Mathf.Pow(1 - t, 5));
        }

        private static float InOutQuint(float a, float b, float t)
        {
            return Lerp(a, b, t < 0.5f ? 16 * t * t * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 5) / 2);
        }

        private static float InExpo(float a, float b, float t)
        {
            return Lerp(a, b, t == 0 ? 0 : Mathf.Pow(2, 10 * t - 10));
        }

        private static float OutExpo(float a, float b, float t)
        {
            return Lerp(a, b, t == 1 ? 1 : 1 - Mathf.Pow(2, -10 * t));
        }

        private static float InOutExpo(float a, float b, float t)
        {
            return Lerp(a, b, t == 0 ? 0 : t == 1 ? 1 : t < 0.5f ? Mathf.Pow(2, 20 * t - 10) / 2 : (2 - Mathf.Pow(2, -20 * t + 10)) / 2);
        }

        private static float InCirc(float a, float b, float t)
        {
            return Lerp(a, b, 1 - Mathf.Sqrt(1 - Mathf.Pow(t, 2)));
        }

        private static float OutCirc(float a, float b, float t)
        {
            return Lerp(a, b, Mathf.Sqrt(1 - Mathf.Pow(t - 1, 2)));
        }

        private static float InOutCirc(float a, float b, float t)
        {
            return Lerp(a, b, t < 0.5f ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * t, 2))) / 2 : (Mathf.Sqrt(1 - Mathf.Pow(-2 * t + 2, 2)) + 1) / 2);
        }

        private static float InBack(float a, float b, float t)
        {
            return Lerp(a, b, C3 * t * t * t - C1 * t * t);
        }

        private static float OutBack(float a, float b, float t)
        {
            return Lerp(a, b, 1 + C3 * Mathf.Pow(t - 1, 3) + C1 * Mathf.Pow(t - 1, 2));
        }

        private static float InOutBack(float a, float b, float t)
        {
            return Lerp(a, b, t < 0.5f ? (Mathf.Pow(2 * t, 2) * ((C2 + 1) * 2 * t - C2)) / 2 : (Mathf.Pow(2 * t - 2, 2) * ((C2 + 1) * (t * 2 - 2) + C2) + 2) / 2);
        }

        private static float InElastic(float a, float b, float t)
        {
            return Lerp(a, b, t == 0 ? 0 : t == 1 ? 1 : -Mathf.Pow(2, 10 * t - 10) * Mathf.Sin((t * 10 - 10.75f) * C4));
        }

        private static float OutElastic(float a, float b, float t)
        {
            return Lerp(a, b, t == 0 ? 0 : t == 1 ? 1 : Mathf.Pow(2, -10 * t) * Mathf.Sin((t * 10 - 0.75f) * C4) + 1);
        }

        private static float InOutElastic(float a, float b, float t)
        {
            return Lerp(a, b, t == 0 ? 0 : t == 1 ? 1 : t < 0.5f ? -(Mathf.Pow(2, 20 * t - 10) * Mathf.Sin((20 * t - 11.125f) * C5)) / 2 : (Mathf.Pow(2, -20 * t + 10) * Mathf.Sin((20 * t - 11.125f) * C5)) / +1);
        }

        private static float InBounce(float a, float b, float t)
        {
            return Lerp(a, b, 1 - RawOutBounce(1 - t));
        }

        private static float OutBounce(float a, float b, float t)
        {
            return Lerp(a, b, RawOutBounce(t));
        }

        private static float InOutBounce(float a, float b, float t)
        {
            return Lerp(a, b, t < 0.5f ? (1 - RawOutBounce(1 - 2 * t)) / 2 : (1 + RawOutBounce(2 * t - 1)) / 2);
        }

        private static float RawOutBounce(float t)
        {
            if (t < 1 / D1)
            {
                return N1 * t * t;
            }

            if (t < 2 / D1)
            {
                return N1 * (t -= 1.5f / D1) * t + 0.75f;
            }

            if (t < 2.5f / D1)
            {
                return N1 * (t -= 2.25f / D1) * t + 0.9375f;
            }

            return N1 * (t -= 2.625f / D1) * t + 0.984375f;
        }

        private static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * t;
        }
    }
}