using System;
using UnityEngine;

namespace Juce.Tween
{
    internal interface ITweener
    {
        bool IsPlaying { get; }
        bool IsCompleted { get; }
        void SetEase(EaseDelegate easeFunction);
        void Init();
        void Update();
        void Complete();
    }
}
