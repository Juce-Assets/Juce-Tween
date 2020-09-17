using System;
using UnityEngine;
using Juce.Tween;

public class TweeningTests : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve = default;

    private Tween tween;

    // Start is called before the first frame update
    void Start()
    {
        float val = 0;

        tween = Tween.To(transform.position, (Vector2 newVal) => { transform.position = newVal; 
            UnityEngine.Debug.Log(val); }, new Vector2(1, 0), 4);

        tween.SetEase(animationCurve);

        JuceTween.Play(tween);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("c"))
        {
            tween.Complete();
        }

        if (Input.GetKeyDown("k"))
        {
            tween.Kill();
        }
    }
}
