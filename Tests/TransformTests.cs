using Juce.Tween;
using UnityEngine;

public class TransformTests : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve = default;
    [SerializeField] private Transform toTween = default;

    private SequenceTween sequenceTween;

    private Tween toKill;

    // Start is called before the first frame update
    private void Start()
    {
        sequenceTween = new SequenceTween();

        //sequenceTween.Append(toTween.TweenPosition(new Vector2(-1, 0), 0));
        //sequenceTween.Append(toTween.TweenPosition(new Vector2(1, 0), 1));
        //sequenceTween.Join(toTween.TweenLocalScale(new Vector2(1.4f, 1.4f), 1));
        //sequenceTween.Join(toTween.TweenRotation(new Vector3(0.0f, 0.0f, 360.0f), 1));
        //sequenceTween.Append(toTween.TweenPosition(new Vector2(-1, 0), 1));
        //sequenceTween.Join(toTween.TweenLocalScale(new Vector2(1.0f, 1.0f), 1));
        //sequenceTween.Join(toTween.TweenRotation(new Vector3(0.0f, 0.0f, -360.0f), 1));

        sequenceTween.Play();
    }

    // Update is called once per frame
    private void Update()
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
            toKill.Restart();
        }
    }
}