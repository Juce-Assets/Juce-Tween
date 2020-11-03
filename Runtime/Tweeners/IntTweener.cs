namespace Juce.Tween
{
    internal class IntTweener : Tweener<int>
    {
        internal IntTweener(Getter currValueGetter, Setter setter, Getter finalValueGetter, float duration)
            : base(currValueGetter, setter, finalValueGetter, duration, new IntInterpolator())
        {
        }
    }
}