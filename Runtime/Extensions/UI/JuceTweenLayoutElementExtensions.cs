using System;
using UnityEngine;
using Juce.Tween;
using UnityEngine.UI;

public static class JuceTweenLayoutElementExtensions
{
    public static Tween TweenFlexibleWidth(this LayoutElement layoutElement, float to, float duration)
    {
        Tween tween = Tween.To(() => layoutElement.flexibleWidth, x => layoutElement.flexibleWidth = x, to, duration);
        tween.SetTarget(layoutElement);
        return tween;
    }

    public static Tween TweenFlexibleHeight(this LayoutElement layoutElement, float to, float duration)
    {
        Tween tween = Tween.To(() => layoutElement.flexibleHeight, x => layoutElement.flexibleHeight = x, to, duration);
        tween.SetTarget(layoutElement);
        return tween;
    }

    public static Tween TweenFlexibleSize(this LayoutElement layoutElement, Vector2 to, float duration)
    {
        Tween widthTween = TweenFlexibleWidth(layoutElement, to.x, duration);
        Tween heightTween = TweenFlexibleHeight(layoutElement, to.y, duration);

        GroupTween groupTween = new GroupTween();
        groupTween.Add(widthTween);
        groupTween.Add(heightTween);

        return groupTween;
    }

    public static Tween TweenMinWidth(this LayoutElement layoutElement, float to, float duration)
    {
        Tween tween = Tween.To(() => layoutElement.minWidth, x => layoutElement.minWidth = x, to, duration);
        tween.SetTarget(layoutElement);
        return tween;
    }

    public static Tween TweenMinHeight(this LayoutElement layoutElement, float to, float duration)
    {
        Tween tween = Tween.To(() => layoutElement.minHeight, x => layoutElement.minHeight = x, to, duration);
        tween.SetTarget(layoutElement);
        return tween;
    }

    public static Tween TweenMinSize(this LayoutElement layoutElement, Vector2 to, float duration)
    {
        Tween widthTween = TweenMinWidth(layoutElement, to.x, duration);
        Tween heightTween = TweenMinHeight(layoutElement, to.y, duration);

        GroupTween groupTween = new GroupTween();
        groupTween.Add(widthTween);
        groupTween.Add(heightTween);

        return groupTween;
    }

    public static Tween TweenPreferedWidth(this LayoutElement layoutElement, float to, float duration)
    {
        Tween tween = Tween.To(() => layoutElement.preferredWidth, x => layoutElement.preferredWidth = x, to, duration);
        tween.SetTarget(layoutElement);
        return tween;
    }

    public static Tween TweenPreferedHeight(this LayoutElement layoutElement, float to, float duration)
    {
        Tween tween = Tween.To(() => layoutElement.preferredHeight, x => layoutElement.preferredHeight = x, to, duration);
        tween.SetTarget(layoutElement);
        return tween;
    }

    public static Tween TweenPreferedSize(this LayoutElement layoutElement, Vector2 to, float duration)
    {
        Tween widthTween = TweenPreferedWidth(layoutElement, to.x, duration);
        Tween heightTween = TweenPreferedHeight(layoutElement, to.y, duration);

        GroupTween groupTween = new GroupTween();
        groupTween.Add(widthTween);
        groupTween.Add(heightTween);

        return groupTween;
    }
}
