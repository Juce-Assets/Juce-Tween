using System;
using UnityEngine;

namespace Juce.Tween
{
    internal interface ITweener
    {
        bool IsPlaying { get; }
        void SetEase(EaseDelegate easeFunction);
        void Update();
        void Complete();
    }
}
