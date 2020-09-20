using System;
using System.Collections.Generic;
using UnityEngine;

namespace Juce.Tween
{
    public class JuceTween : MonoBehaviour
    {
        private readonly List<Tween> aliveTweens = new List<Tween>();
        private readonly List<Tween> tweensToRemove = new List<Tween>();

        private float timeScale;

        private static JuceTween instance;

        public static JuceTween Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = CreateInstance();
                }

                return instance;

            }
        }

        public static float TimeScale
        {
            get { return Instance.timeScale; }
            set { Instance.timeScale = value; }
        }

        private static JuceTween CreateInstance()
        {
            GameObject juceTweenGameObject = new GameObject("JuceTween");
            DontDestroyOnLoad(juceTweenGameObject);

            return juceTweenGameObject.AddComponent<JuceTween>();
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
