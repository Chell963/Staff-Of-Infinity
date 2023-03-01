using Data;
using UnityEditor;
using UnityEngine;

namespace Utils.Editor
{
    [CustomPropertyDrawer(typeof(HorizontalBounds))]
    public class HorizontalBoundsDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, true);
        }
 
        public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
        {
            var name = property.displayName;
            
            property.Next(true);
            var left = property.Copy();
            property.Next(true);
            var right = property.Copy();

            var position = EditorGUI.PrefixLabel(rect, new GUIContent(name));

            var third = position.width / 3;

            EditorGUIUtility.labelWidth = 40f;
            position.width *= 0.3f;
            EditorGUI.indentLevel = 0;
            
            EditorGUI.BeginProperty(position, label, left);
            {
                EditorGUI.BeginChangeCheck();
                var newVal = EditorGUI.FloatField(position, new GUIContent("Left"), left.floatValue);
                if (EditorGUI.EndChangeCheck())
                    left.floatValue = newVal;
            }
            EditorGUI.EndProperty();

            position.x += third;

            EditorGUI.BeginProperty(position, label, right);
            {
                EditorGUI.BeginChangeCheck();
                var newVal = EditorGUI.FloatField(position, new GUIContent("Right"), right.floatValue);
                if (EditorGUI.EndChangeCheck())
                    right.floatValue = newVal;
            }
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(VerticalBounds))]
    public class VerticalBoundsDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, true);
        }
 
        public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
        {
            var name = property.displayName;
            
            property.Next(true);
            var down = property.Copy();
            property.Next(true);
            var up = property.Copy();
            
            var position = EditorGUI.PrefixLabel(rect, new GUIContent(name));

            var third = position.width / 3;

            EditorGUIUtility.labelWidth = 40f;
            position.width *= 0.3f;
            EditorGUI.indentLevel = 0;
            
            EditorGUI.BeginProperty(position, label, down);
            {
                EditorGUI.FloatField(position, new GUIContent("Down"), down.floatValue);
            }
            EditorGUI.EndProperty();

            position.x += third;

            EditorGUI.BeginProperty(position, label, up);
            {
                EditorGUI.FloatField(position, new GUIContent("Up"), up.floatValue);
            }
            EditorGUI.EndProperty();
        }
    }
}
