﻿/************************************************************************************
Copyright      :   Copyright 2017 MicroLight, LLC. All Rights reserved.
Description    :   FlagsFromEnumAttributeDrawer.cs
ProjectName    :   MicroLight
ProductionDate :   2017-04-05 11:50:20
Author         :   T-CODE
************************************************************************************/
using System;
using UnityEditor;
using UnityEngine;

namespace MicroLight.UnityPlugin.Utility
{
    [CustomPropertyDrawer(typeof(FlagsFromEnumAttribute))]
    public class FlagsFromEnumAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // First get the attribute since it contains the range for the slider
            var ffeAttribute = attribute as FlagsFromEnumAttribute;

            EditorGUI.BeginProperty(position, label, property);

            if (property.propertyType != SerializedPropertyType.Integer)
            {
                EditorGUI.LabelField(position, label.text, "Use FlagFromEnum with integer.");
            }
            else if (ffeAttribute.EnumType == null || !ffeAttribute.EnumType.IsEnum)
            {
                EditorGUI.LabelField(position, label.text, "Set FlagFromEnum argument with enum type.");
            }
            else
            {
                position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), new GUIContent(property.displayName));
                property.intValue = EditorGUI.MaskField(position, property.intValue, Enum.GetNames(ffeAttribute.EnumType));
            }

            property.serializedObject.ApplyModifiedProperties();

            EditorGUI.EndProperty();
        }
    }
}