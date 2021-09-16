using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AreaBase))]
[CanEditMultipleObjects]
public class AreaBaseEditor : Editor
{
    AreaBase _target;

    private void OnEnable()
    {
        _target = target as AreaBase;
    }

    public List<Card> cards;

    ScriptableObject sObj;
    SerializedObject seObj;
    SerializedProperty sPro;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        cards = new List<Card>(_target.cardList);

        sObj = this;
        seObj = new SerializedObject(sObj);
        sPro = seObj.FindProperty("cards");

        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.PropertyField(sPro);
        seObj.ApplyModifiedProperties();
        EditorGUI.EndDisabledGroup();

        Repaint();
    }
}
