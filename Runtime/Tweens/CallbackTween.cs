using System;

namespace Juce.Tween
{
    public class CallbackTween : Tween
    {
        private readonly Action action;

        public CallbackTween(Action action)
        {
            this.action = action;
        }

        protected override void StartInternal()
        {
            action?.Invoke();

            MarkAsFinished();
        }
    }
}