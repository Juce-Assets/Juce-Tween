using System;
using UnityEngine;
using Juce.Tween;

public class TweeningTests : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve = default;

    private SequenceTween sequenceTween;

    // Start is called before the first frame update
    void Start()
    {
        float val = 0;

        sequenceTween = new SequenceTween();

        Tween tween = Tween.To(() => { return transform.position; }, (Vector2 newVal) => { transform.position = newVal; 
            UnityEngine.Debug.Log(val); }, new Vector2(1, 0), 4);

        Tween tween2 = Tween.To(() => { return transform.position; }, (Vector2 newVal) => { transform.position = newVal; 
            UnityEngine.Debug.Log(val); }, new Vector2(-1, 0), 4);

        tween.SetEase(animationCurve);
        tween2.SetEase(animationCurve);

        sequenceTween.Append(tween);
        sequenceTween.Append(tween2);

        sequenceTween.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("c"))
        {
            sequenceTween.Complete();
        }

        if (Input.GetKeyDown("k"))
        {
            sequenceTween.Kill();
        }
    }
}
