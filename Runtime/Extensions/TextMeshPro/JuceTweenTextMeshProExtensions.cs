
#if JUCE_TEXT_MESH_PRO_EXTENSIONS

using System;
using UnityEngine;
using Juce.Tween;

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

#if JUCE_EXPERIMENTAL

    public static Tween TweenCharColor(this TextMeshProUGUI textMeshProUGUI, int charIndex, Color to, float duration)
    {
        if (textMeshProUGUI.textInfo.characterInfo.Length <= charIndex)
        { 
            throw new ArgumentNullException($"Char index was out of range at {nameof(TweenCharColor)}");
        }

        TMP_CharacterInfo characterInfo = textMeshProUGUI.textInfo.characterInfo[charIndex];

        int meshIndex = characterInfo.materialReferenceIndex;
        int vertexIndex = characterInfo.vertexIndex;

        Color32[] vertexColors = textMeshProUGUI.textInfo.meshInfo[meshIndex].colors32;

        if (vertexColors == null)
        {
            textMeshProUGUI.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
            textMeshProUGUI.ForceMeshUpdate();

            vertexColors = textMeshProUGUI.textInfo.meshInfo[meshIndex].colors32;
        }

        Tweener<Color>.Getter[] getters = new Tweener<Color>.Getter[4];
        getters[0] = () => vertexColors[vertexIndex + 0];
        getters[1] = () => vertexColors[vertexIndex + 1];
        getters[2] = () => vertexColors[vertexIndex + 2];
        getters[3] = () => vertexColors[vertexIndex + 3];

        Tweener<Color>.Setter[] setters = new Tweener<Color>.Setter[4];
        setters[0] = x => vertexColors[vertexIndex + 0] = x;
        setters[1] = x => vertexColors[vertexIndex + 1] = x;
        setters[2] = x => vertexColors[vertexIndex + 2] = x;
        setters[3] = x => { vertexColors[vertexIndex + 3] = x; textMeshProUGUI.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32); };

        Color[] finalValues = new Color[4];
        finalValues[0] = to;
        finalValues[1] = to;
        finalValues[2] = to;
        finalValues[3] = to;

        Tween tween = Tween.To(getters, setters, finalValues, duration);
        tween.SetTarget(textMeshProUGUI);
        return tween;
    }

    public static Tween TweenCharColorAlpha(this TextMeshProUGUI textMeshProUGUI, int charIndex, float to, float duration)
    {
        if (textMeshProUGUI.textInfo.characterInfo.Length <= charIndex)
        {
            throw new ArgumentNullException($"Char index was out of range at {nameof(TweenCharColorAlpha)}");
        }

        float to255 = to * 255.0f;

        TMP_CharacterInfo characterInfo = textMeshProUGUI.textInfo.characterInfo[charIndex];

        int meshIndex = characterInfo.materialReferenceIndex;
        int vertexIndex = characterInfo.vertexIndex;

        Color32[] vertexColors = textMeshProUGUI.textInfo.meshInfo[meshIndex].colors32;

        if (vertexColors == null)
        {
            textMeshProUGUI.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
            textMeshProUGUI.ForceMeshUpdate();

            vertexColors = textMeshProUGUI.textInfo.meshInfo[meshIndex].colors32;
        }

        Tweener<float>.Getter[] getters = new Tweener<float>.Getter[4];
        getters[0] = () => vertexColors[vertexIndex + 0].a;
        getters[1] = () => vertexColors[vertexIndex + 1].a;
        getters[2] = () => vertexColors[vertexIndex + 2].a;
        getters[3] = () => vertexColors[vertexIndex + 3].a;

        Tweener<float>.Setter[] setters = new Tweener<float>.Setter[4];
        setters[0] = x => vertexColors[vertexIndex + 0].a = (byte)x;
        setters[1] = x => vertexColors[vertexIndex + 1].a = (byte)x;
        setters[2] = x => vertexColors[vertexIndex + 2].a = (byte)x;
        setters[3] = x => { vertexColors[vertexIndex + 3].a = (byte)x; textMeshProUGUI.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32); };

        float[] finalValues = new float[4];
        finalValues[0] = to;
        finalValues[1] = to;
        finalValues[2] = to;
        finalValues[3] = to;

        Tween tween = Tween.To(getters, setters, finalValues, duration);
        tween.SetTarget(textMeshProUGUI);
        return tween;
    }

    public static Tween TweenCharTransform(this TextMeshProUGUI textMeshProUGUI, int charIndex, Matrix4x4 to, float duration)
    {
        if (textMeshProUGUI.textInfo.characterInfo.Length <= charIndex)
        {
            throw new ArgumentNullException($"Char index was out of range at {nameof(TweenCharTransform)}");
        }

        TMP_CharacterInfo characterInfo = textMeshProUGUI.textInfo.characterInfo[charIndex];

        int meshIndex = characterInfo.materialReferenceIndex;
        int vertexIndex = characterInfo.vertexIndex;

        Vector3[] vertexCoords = textMeshProUGUI.textInfo.meshInfo[meshIndex].vertices;

        if (vertexCoords == null)
        {
            textMeshProUGUI.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices);
            textMeshProUGUI.ForceMeshUpdate();

            vertexCoords = textMeshProUGUI.textInfo.meshInfo[meshIndex].vertices;
        }

        Vector2 charMidBasline = (vertexCoords[vertexIndex + 0] + vertexCoords[vertexIndex + 2]) / 2;
        Vector3 offset = charMidBasline;

        Tweener<Vector3>.Getter[] getters = new Tweener<Vector3>.Getter[4];
        getters[0] = () => vertexCoords[vertexIndex + 0];
        getters[1] = () => vertexCoords[vertexIndex + 1];
        getters[2] = () => vertexCoords[vertexIndex + 2];
        getters[3] = () => vertexCoords[vertexIndex + 3];

        Tweener<Vector3>.Setter[] setters = new Tweener<Vector3>.Setter[4];
        setters[0] = x => vertexCoords[vertexIndex + 0] = x;
        setters[1] = x => vertexCoords[vertexIndex + 1] = x;
        setters[2] = x => vertexCoords[vertexIndex + 2] = x;
        setters[3] = x => { vertexCoords[vertexIndex + 3] = x; textMeshProUGUI.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices); };

        Vector3[] finalValues = new Vector3[4];
        finalValues[0] = to.MultiplyPoint3x4(vertexCoords[vertexIndex + 0] - offset);
        finalValues[1] = to.MultiplyPoint3x4(vertexCoords[vertexIndex + 1] - offset);
        finalValues[2] = to.MultiplyPoint3x4(vertexCoords[vertexIndex + 2] - offset);
        finalValues[3] = to.MultiplyPoint3x4(vertexCoords[vertexIndex + 3] - offset);

        finalValues[0] += offset;
        finalValues[1] += offset;
        finalValues[2] += offset;
        finalValues[3] += offset;

        Tween tween = Tween.To(getters, setters, finalValues, duration);
        tween.SetTarget(textMeshProUGUI);

        tween.OnComplete(() =>
        {
            textMeshProUGUI.textInfo.meshInfo[meshIndex].mesh.vertices = textMeshProUGUI.textInfo.meshInfo[meshIndex].vertices;
            textMeshProUGUI.UpdateGeometry(textMeshProUGUI.textInfo.meshInfo[meshIndex].mesh, meshIndex);
        });

        return tween;
    }

    public static Tween TweenCharOffset(this TextMeshProUGUI textMeshProUGUI, int charIndex, Vector2 to, float duration)
    {
        Matrix4x4 matrix = Matrix4x4.TRS(to, Quaternion.identity, Vector3.one);
        return textMeshProUGUI.TweenCharTransform(charIndex, matrix, duration);
    }

    public static Tween TweenCharRotation(this TextMeshProUGUI textMeshProUGUI, int charIndex, float to, float duration)
    {
        Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, to), Vector3.one);
        return textMeshProUGUI.TweenCharTransform(charIndex, matrix, duration);
    }

    public static Tween TweenCharScale(this TextMeshProUGUI textMeshProUGUI, int charIndex, Vector2 to, float duration)
    {
        Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, to);
        return textMeshProUGUI.TweenCharTransform(charIndex, matrix, duration);
    }
#endif

}

#endif
