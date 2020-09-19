using System;
using UnityEngine;
using Juce.Tween;
using TMPro;

public class TextMeshProTests : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve = default;
    [SerializeField] private TextMeshProUGUI text = default;

    private SequenceTween sequenceTween;

    // Start is called before the first frame update
    void Start()
    {
        sequenceTween = new SequenceTween();

        sequenceTween.Append(text.TweenCharColor(0, Color.black, 10));

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
