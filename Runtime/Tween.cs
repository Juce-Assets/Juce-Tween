using System;
using System.Collections.Generic;
using UnityEngine;

namespace Juce.Tween
{
	public class Tween
	{
		private readonly List<ITweener> aliveTweeners = new List<ITweener>();
		private readonly List<ITweener> tweenersToRemove = new List<ITweener>();

		private EaseDelegate easeFunction;

		public bool IsPlaying { get; protected set; }
		public bool IsCompleted { get; protected set; }
		public bool IsKilled { get; protected set; }

		public event Action OnComplete;
		public event Action OnKill;
		public event Action OnCompleteOrKill;

		public Tween()
        {
			SetEase(Ease.Linear);
		}

		public static Tween To(float initialValue, Tweener<float>.Setter setter, float finalValue, float duration)
        {
			Tween tween = new Tween();
			tween.Add(initialValue, setter, finalValue, duration);
			return tween;
        }

		public static Tween To(Vector2 initialValue, Tweener<Vector2>.Setter setter, Vector2 finalValue, float duration)
		{
			Tween tween = new Tween();
			tween.Add(initialValue, setter, finalValue, duration);
			return tween;
		}

		public static Tween To(Vector3 initialValue, Tweener<Vector3>.Setter setter, Vector3 finalValue, float duration)
		{
			Tween tween = new Tween();
			tween.Add(initialValue, setter, finalValue, duration);
			return tween;
		}

		internal void Add(float initialValue, Tweener<float>.Setter setter, float finalValue, float duration)
		{
			Add(new FloatTweener(initialValue, setter, finalValue, duration));
		}

		internal void Add(Vector2 initialValue, Tweener<Vector2>.Setter setter, Vector2 finalValue, float duration)
		{
			Add(new Vector2Tweener(initialValue, setter, finalValue, duration));
		}

		internal void Add(Vector3 initialValue, Tweener<Vector3>.Setter setter, Vector3 finalValue, float duration)
		{
			Add(new Vector3Tweener(initialValue, setter, finalValue, duration));
		}

		internal void Add(ITweener tweener)
        {
			aliveTweeners.Add(tweener);
		}

		public void SetEase(Ease ease)
        {
			easeFunction = PresetEaser.GetEaseDelegate(ease);
		}

		public void SetEase(AnimationCurve animationCurve)
        {
			easeFunction = AnimationCurveEaser.GetEaseDelegate(animationCurve);
		}

		public void Play()
		{
			if(IsPlaying)
            {
				return;
            }

			IsPlaying = true;
			IsCompleted = false;

			for (int i = 0; i < aliveTweeners.Count; ++i)
			{
				aliveTweeners[i].SetEase(easeFunction);
			}
		}

		public void Complete()
		{
			if (!IsPlaying)
			{
				return;
			}

			for (int i = 0; i < aliveTweeners.Count; ++i)
			{
				aliveTweeners[i].Complete();
			}

			aliveTweeners.Clear();
			tweenersToRemove.Clear();

			IsPlaying = false;
			IsCompleted = true;
			IsKilled = false;
			OnComplete?.Invoke();
			OnCompleteOrKill?.Invoke();
		}

		public void Kill()
        {
			if (!IsPlaying)
			{
				return;
			}

			aliveTweeners.Clear();
			tweenersToRemove.Clear();

			IsPlaying = false;
			IsCompleted = false;
			IsKilled = true;
			OnKill?.Invoke();
			OnCompleteOrKill?.Invoke();
		}

		public void Update()
        {
			if(!IsPlaying)
            {
				return;
            }

			for(int i = 0; i < aliveTweeners.Count; ++i)
            {
				ITweener currTweener = aliveTweeners[i];

				currTweener.Update();

				if(!currTweener.IsPlaying)
                {
					tweenersToRemove.Add(currTweener);
				}
			}

			for(int i = 0; i < tweenersToRemove.Count; ++i)
            {
				aliveTweeners.Remove(tweenersToRemove[i]);
			}

			tweenersToRemove.Clear();

			if(aliveTweeners.Count == 0)
            {
				IsPlaying = false;
				IsCompleted = true;
				IsKilled = false;
				OnComplete?.Invoke();
				OnCompleteOrKill?.Invoke();
			}
		}
	}
}
