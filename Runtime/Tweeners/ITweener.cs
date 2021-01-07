namespace Juce.Tween
{
    internal interface ITweener
    {
        float Duration { get; }
        bool UseGeneralTimeScale { get; set; }
        float TimeScale { get; set; }
        bool IsPlaying { get; }
        bool IsCompleted { get; }
        float Progress { get; }

        void SetEase(EaseDelegate easeFunction);

        void Init();

        void Start();

        void Reset(ResetMode mode);

        void Update();

        void Complete();
    }
}