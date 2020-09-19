using System;
using UnityEngine;
using Juce.Tween;

public class SpriteRendererTests : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve = default;
    [SerializeField] private SpriteRenderer spriteRenderer = default;

    private SequenceTween sequenceTween;

    // Start is called before the first frame update
    void Start()
    {
        sequenceTween = new SequenceTween();

        sequenceTween.Append(spriteRenderer.TweenColorAlpha(0, 4));

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
    }
}
