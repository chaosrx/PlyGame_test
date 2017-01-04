#if UNITY_4_6 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9

using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using plyBloxKit;
using Lyn;

// OnClickTriggerBloxEvent_v3
// by RaiuLyn
// https://twitter.com/RaiuLyn
// http://raiulyn.wordpress.com 
// http://forum.plyoung.com/users/raiulyn
// ============================================================================================================

[CustomPropertyDrawer(typeof(EventParam))]
public class ParamDrawer: PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty Param = property.FindPropertyRelative("ParamName");
        SerializedProperty Scope = property.FindPropertyRelative("_scope");
        SerializedProperty Type = property.FindPropertyRelative("_type");
        SerializedProperty String = property.FindPropertyRelative("str_value");
        SerializedProperty Int = property.FindPropertyRelative("int_value");
        SerializedProperty Float = property.FindPropertyRelative("float_value");
        SerializedProperty Bool = property.FindPropertyRelative("bool_value");
        SerializedProperty Vector3 = property.FindPropertyRelative("vector3_value");
        SerializedProperty Vector2 = property.FindPropertyRelative("vector2_value");
        SerializedProperty Gameobject = property.FindPropertyRelative("gameobject_value");
        SerializedProperty Component = property.FindPropertyRelative("component_value");
        SerializedProperty Object = property.FindPropertyRelative("object_value");
        SerializedProperty Item = property.FindPropertyRelative("item_value");
        SerializedProperty ItemSearch = property.FindPropertyRelative("item_search");

        EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        Rect ScopePrefixRect = new Rect(position.x, position.y, position.width, 15);
        EditorGUI.PrefixLabel(ScopePrefixRect, new GUIContent("Scope", "Scope of variable"));
        Rect ScopeRect = new Rect(position.x, position.y + 15, position.width, 15);
        EditorGUI.PropertyField(ScopeRect, Scope, GUIContent.none);

        Rect ParamPrefixRect = new Rect(position.x, position.y + 30, position.xMin, 15);
        EditorGUI.PrefixLabel(ParamPrefixRect, new GUIContent("Param Name", "Name of the Temp variable"));
        Rect ParamRect = new Rect(position.x, position.y + 45, position.xMin, 15);
        EditorGUI.PropertyField(ParamRect, Param, GUIContent.none);

        Rect TypePrefixRect = new Rect(position.x, position.y + 60, position.width, 15);
        EditorGUI.PrefixLabel(TypePrefixRect, new GUIContent("Type", "Type of the Temp variable"));
        Rect TypeRect = new Rect(position.x, position.y + 75, position.width, 15);
        EditorGUI.PropertyField(TypeRect, Type, GUIContent.none);

        Rect ValuePrefixRect = new Rect(position.x, position.y + 90, position.width, 15);
        EditorGUI.PrefixLabel(ValuePrefixRect, new GUIContent("Value", "Value of the Temp variable"));
        Rect ValueRect = new Rect(position.x, position.y + 105, position.width, 15);
        switch (Type.enumValueIndex)
        {
            case 0:
                EditorGUI.PropertyField(ValueRect, String, GUIContent.none);
                break;
            case 1:
                EditorGUI.PropertyField(ValueRect, Int, GUIContent.none);
                break;
            case 2:
                EditorGUI.PropertyField(ValueRect, Float, GUIContent.none);
                break;
            case 3:
                EditorGUI.PropertyField(ValueRect, Bool, GUIContent.none);
                break;
            case 4:
                EditorGUI.PropertyField(ValueRect, Vector3, GUIContent.none);
                break;
            case 5:
                EditorGUI.PropertyField(ValueRect, Vector2, GUIContent.none);
                break;
            case 6:
                EditorGUI.PropertyField(ValueRect, Gameobject, GUIContent.none);
                break;
            case 7:
                EditorGUI.PropertyField(ValueRect, Component, GUIContent.none);
                break;
            case 8:
                EditorGUI.PropertyField(ValueRect, Object, GUIContent.none);
                break;
            case 9:
                EditorGUI.PropertyField(ValueRect, Item, GUIContent.none);
                Rect ItemSearchPrefixRect = new Rect(position.x, position.y + 120, position.width, 15);
                EditorGUI.PrefixLabel(ItemSearchPrefixRect, new GUIContent("Ident Type", "Type to search item"));
                Rect ItemSearchRect = new Rect(position.x, position.y + 135, position.width, 15);
                switch (ItemSearch.enumValueIndex)
	            {
                    case 0:
                        EditorGUI.PropertyField(ItemSearchRect, ItemSearch, GUIContent.none);
                        break;
                    case 1:
                        EditorGUI.PropertyField(ItemSearchRect, ItemSearch, GUIContent.none);
                        break;
                    case 2:
                        EditorGUI.PropertyField(ItemSearchRect, ItemSearch, GUIContent.none);
                        break;
                    case 3:
                        EditorGUI.PropertyField(ItemSearchRect, ItemSearch, GUIContent.none);
                        break;
	            }
                break;
        }



        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
    
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        SerializedProperty Type = property.FindPropertyRelative("_type");

        switch (Type.enumValueIndex)
        {
            default:
                return base.GetPropertyHeight(property, label) + 20;
            case 0:
                return base.GetPropertyHeight(property, label) + 120;
            case 1:
                return base.GetPropertyHeight(property, label) + 120;
            case 2:
                return base.GetPropertyHeight(property, label) + 120;
            case 3:
                return base.GetPropertyHeight(property, label) + 120;
            case 4:
                return base.GetPropertyHeight(property, label) + 120;
            case 5:
                return base.GetPropertyHeight(property, label) + 120;
            case 6:
                return base.GetPropertyHeight(property, label) + 120;
            case 7:
                return base.GetPropertyHeight(property, label) + 120;
            case 8:
                return base.GetPropertyHeight(property, label) + 120;
            case 9:
                return base.GetPropertyHeight(property, label) + 150;
        }
    }
}

#endif