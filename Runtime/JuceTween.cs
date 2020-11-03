using Juce.Utils.Singletons;
using System;
using System.Collections.Generic;

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

        public int GetAliveTweensCounts()
        {
            int aliveTweensCount = 0;

            for (int i = 0; i < aliveTweens.Count; ++i)
            {
                aliveTweensCount += aliveTweens[i].GetNestedTweenChildsCount() + 1;
            }

            return aliveTweensCount;
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

            if (syncNow)
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