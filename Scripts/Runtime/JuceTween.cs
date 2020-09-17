using System;
using UnityEngine;

namespace Juce.Tween
{
    public class JuceTween : MonoBehaviour
    {
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

        private void Init()
        {
            timeScale = 1.0f;
        }
    }
}
