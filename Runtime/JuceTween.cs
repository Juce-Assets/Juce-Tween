using System;
using System.Collections.Generic;
using Juce.Utils.Singletons;

namespace Juce.Tween
{
    public class JuceTween : AutoStartMonoSingleton<JuceTween>
    {
        private readonly List<Tween> aliveTweens = new List<Tween>();
        private readonly List<Tween> tweensToRemove = new List<Tween>();

        private float timeScale;

        public static float TimeScale
        {
            get { return Instance.timeScale; }
            set { Instance.timeScale = value; }
        }

        private void Awake()
        {
            Init();
        }

        private void Update()
        {
            UpdateTweens();
        }

        private void Init()
        {
            timeScale = 1.0f;
        }

        internal static void Play(Tween tween)
        {
            if(tween == null) throw new ArgumentNullException($"Tried to play a null {nameof(Tween)} on {nameof(JuceTween)} instance");

            Instance.aliveTweens.Add(tween);
        }

        private void UpdateTweens()
        {
            TweenUtils.UpdateSimultaneous(aliveTweens, tweensToRemove);
        }
    }
}
