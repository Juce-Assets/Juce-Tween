using System;
using UnityEngine;
using Juce.Tween;

#if JUCE_TWEEN_TEXT_MESH_PRO_EXTENSIONS

using TMPro;

public static class JuceTweenTextMeshProExtensions
{
    public static Tween TweenFontSize(this TextMeshProUGUI textMeshProUGUI, float to, float duration)
    {
        Tween tween = Tween.To(() => textMeshProUGUI.fontSize, x => textMeshProUGUI.fontSize = x, to, duration);
        tween.SetTarget(textMeshProUGUI);
        return tween;
    }

    public static Tween TweenColor(this TextMeshProUGUI textMeshProUGUI, Color to, float duration)
    {
        Tween tween = Tween.To(() => textMeshProUGUI.color, x => textMeshProUGUI.color = x, to, duration);
        tween.SetTarget(textMeshProUGUI);
        return tween;
    }

    public static Tween TweenColorAlpha(this TextMeshProUGUI textMeshProUGUI, float to, float duration)
    {
        float to255 = to * 255.0f;
        Tween tween = Tween.To(() => textMeshProUGUI.color.a, x => textMeshProUGUI.color =
            ColorUtils.ChangeAlpha(textMeshProUGUI.color, x), to, duration);
        tween.SetTarget(textMeshProUGUI);
        return tween;
    }

    public static Tween TweenFaceColor(this TextMeshProUGUI textMeshProUGUI, Color to, float duration)
    {
        Tween tween = Tween.To(() => textMeshProUGUI.faceColor, x => textMeshProUGUI.faceColor = x, to, duration);
        tween.SetTarget(textMeshProUGUI);
        return tween;
    }

    public static Tween TweenFaceColorAlpha(this TextMeshProUGUI textMeshProUGUI, float to, float duration)
    {
        float to255 = to * 255.0f;
        Tween tween = Tween.To(() => textMeshProUGUI.faceColor.a, x => textMeshProUGUI.faceColor =
            ColorUtils.ChangeAlpha(textMeshProUGUI.faceColor, x), to, duration);
        tween.SetTarget(textMeshProUGUI);
        return tween;
    }

    public static Tween TweenMaxVisibleCharacters(this TextMeshProUGUI textMeshProUGUI, int to, float duration)
    {
        Tween tween = Tween.To(() => textMeshProUGUI.maxVisibleCharacters, x => textMeshProUGUI.maxVisibleCharacters = x, to, duration);
        tween.SetTarget(textMeshProUGUI);
        return tween;
    }

    public static Tween TweenCharColor(this TextMeshProUGUI textMeshProUGUI, int charIndex, Color to, float duration)
    {
        Tween tween = Tween.To(() => 
        {
            TMP_CharacterInfo characterInfo = textMeshProUGUI.textInfo.characterInfo[charIndex];
            int meshIndex = characterInfo.materialReferenceIndex;
            int vertexIndex = characterInfo.vertexIndex;

            Color32[] vertexColors = textMeshProUGUI.textInfo.meshInfo[meshIndex].colors32;

            if(vertexColors == null)
            {
                textMeshProUGUI.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
                textMeshProUGUI.ForceMeshUpdate();

                vertexColors = textMeshProUGUI.textInfo.meshInfo[meshIndex].colors32;
            }

            return vertexColors[vertexIndex];

        }, 
        x =>
        {
            TMP_CharacterInfo characterInfo = textMeshProUGUI.textInfo.characterInfo[charIndex];
            int meshIndex = characterInfo.materialReferenceIndex;
            int vertexIndex = characterInfo.vertexIndex;

            Color32[] vertexColors = textMeshProUGUI.textInfo.meshInfo[meshIndex].colors32;

            vertexColors[vertexIndex + 0] = x;
            vertexColors[vertexIndex + 1] = x;
            vertexColors[vertexIndex + 2] = x;
            vertexColors[vertexIndex + 3] = x;

            textMeshProUGUI.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
        }, 
        to, duration);
        tween.SetTarget(textMeshProUGUI);
        return tween;
    }
}

#endif
