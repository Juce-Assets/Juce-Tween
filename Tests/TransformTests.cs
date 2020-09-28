using System;
using UnityEngine;
using Juce.Tween;

public class TransformTests : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve = default;
    [SerializeField] private Transform toTween = default;

    private SequenceTween sequenceTween;

    // Start is called before the first frame update
    void Start()
    {
        sequenceTween = new SequenceTween();

        sequenceTween.Append(toTween.TweenPosition(new Vector2(1, 0), 1));
        sequenceTween.Join(toTween.TweenLocalScale(new Vector2(2, 2), 4));
        sequenceTween.Join(toTween.TweenRotation(new Vector3(0.0f, 0.0f, 360.0f), 4));
        sequenceTween.Append(toTween.TweenPosition(new Vector2(-1, 0), 1));

        sequenceTween.SetEase(animationCurve);

        sequenceTween.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            sequenceTween.Complete();
        }

        if (Input.GetKeyDown("k"))
        {
            sequenceTween.Kill();
        }

        if (Input.GetKeyDown("d"))
        {
            Destroy(this.gameObject);
        }

        if (Input.GetKeyDown("r"))
        {
            sequenceTween.Kill();
            sequenceTween.Reset();
            sequenceTween.Play();
        }
    }
}
