using System;
using UnityEngine;

namespace Juce.Tween
{
    public class WaitTimeTween : Tween
    {
        private readonly float duration;

        private float elapsedTime;

        public WaitTimeTween(float duration)
        {
            this.duration = duration;
        }

        protected override void StartInternal()
        {
            elapsedTime = 0.0f;

            if (duration <= 0)
            {
                MarkAsFinished();
            }
        }

        protected override void UpdateInternal()
        {
            float dt = Time.deltaTime * JuceTween.TimeScale * TimeScale;

            elapsedTime += dt;

            if (elapsedTime >= duration)
            {
                MarkAsFinished();
            }
        }
    }
}
