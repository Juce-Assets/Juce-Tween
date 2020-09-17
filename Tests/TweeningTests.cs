using Juce.Tween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweeningTests : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        JuceTween.Instance.gameObject.name = JuceTween.Instance.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
