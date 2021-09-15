using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class ObjectAlignWindow : EditorWindow
{
    [MenuItem("Codenoob/Object Position Sort")]
    static void Init()
    {
        ObjectAlignWindow window = EditorWindow.GetWindow<ObjectAlignWindow>();

        window.Show();
    }


    public Transform startPoint;
    public Transform endPoint;

    public List<Transform> targets = new List<Transform>();
    public Vector3 interval;

    ScriptableObject thisWindow;
    SerializedObject serializedObject;
    SerializedProperty targetsProperty;
    private void OnGUI()
    {
        //startPoint = EditorGUILayout.ObjectField(new GUIContent("Start Point"), startPoint, typeof(Transform)) as Transform;
        //endPoint = EditorGUILayout.ObjectField(new GUIContent("End Point"), endPoint, typeof(Transform)) as Transform;

        thisWindow = this;
        serializedObject = new SerializedObject(thisWindow);
        targetsProperty = serializedObject.FindProperty("targets");
        EditorGUILayout.PropertyField(targetsProperty, true);
        serializedObject.ApplyModifiedProperties();


        interval = EditorGUILayout.Vector3Field(new GUIContent("Position Interval"), interval);


        if (targets.Count > 0)
        {
            Vector3 startPosition = targets[0].localPosition;
            Vector3 endPosition = targets[targets.Count - 1].localPosition;
            Vector3 startToEnd = endPosition - startPosition;


            if (GUILayout.Button("Interval) Align"))
            {
                for (int i = 0; i < targets.Count; i++)
                {
                    targets[i].localPosition = startPosition + interval * i;
                }
            }



            if (GUILayout.Button("Start to End Align"))
            {
                interval = startToEnd / (targets.Count - 1);

                for (int i = 0; i < targets.Count; ++i)
                {
                    targets[i].localPosition = startPosition + interval * i;
                }
            }
        }
    }

}
