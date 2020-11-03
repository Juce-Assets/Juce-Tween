using UnityEditor;

namespace Juce.Tween
{
    [CustomEditor(typeof(JuceTween))]
    public class JuceTweenCE : Editor
    {
        private JuceTween CustomTarget => (JuceTween)target;

        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField($"Alive tweens: {CustomTarget.GetAliveTweensCounts()}", EditorStyles.boldLabel);
        }
    }
}