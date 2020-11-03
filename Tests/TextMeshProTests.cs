using Juce.Tween;
using TMPro;
using UnityEngine;

public class TextMeshProTests : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve = default;
    [SerializeField] private TextMeshProUGUI text = default;

    private SequenceTween sequenceTween;

    // Start is called before the first frame update
    private void Start()
    {
        sequenceTween = new SequenceTween();

        //sequenceTween.Append(text.TweenCharScale(0, new Vector2(2, 2), 1));
        //sequenceTween.Append(text.TweenCharRotation(0, 60, 1));
        //sequenceTween.Append(text.TweenCharOffset(0, new Vector3(-10, 0, 0), 1));
        //sequenceTween.Append(text.TweenCharColor(0, Color.black, 1));
        //sequenceTween.Append(text.TweenCharColor(0, Color.white, 1));
        //sequenceTween.Append(text.TweenCharColorAlpha(0, 0, 1));

        sequenceTween.SetEase(animationCurve);

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
    }
}