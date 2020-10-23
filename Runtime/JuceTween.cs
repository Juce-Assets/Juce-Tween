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

        public int AliveTweensCount => aliveTweens.Count;

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

        internal static void Add(Tween tween, bool syncNow)
        {
            if (tween == null)
            {
                throw new ArgumentNullException($"Tried to play a null {nameof(Tween)} on {nameof(JuceTween)} instance");
            }

            if (!Instance.aliveTweens.Contains(tween))
            {
                Instance.aliveTweens.Add(tween);
            }

            if(syncNow)
            {
                Instance.UpdateTweens();
            }
        }

        private void UpdateTweens()
        {
            TweenUtils.UpdateSimultaneous(aliveTweens, tweensToRemove);
        }
    }
}
