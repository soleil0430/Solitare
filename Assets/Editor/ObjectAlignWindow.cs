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

    public List<Transform> targets = new List<Transform>(); //대상들
    public Vector3 interval;                                //간격

    ScriptableObject thisWindow;
    SerializedObject serializedObject;
    SerializedProperty targetsProperty;
    private void OnGUI()
    {
        //targets를 EditorGUILayout를 활용해서 윈도우에 보이게 하는 과정
        thisWindow = this;
        serializedObject = new SerializedObject(thisWindow);
        targetsProperty = serializedObject.FindProperty("targets");
        EditorGUILayout.PropertyField(targetsProperty, true);
        serializedObject.ApplyModifiedProperties();

        //간격 입력
        interval = EditorGUILayout.Vector3Field(new GUIContent("Position Interval"), interval);

        //target이 1개 이상 있으면
        if (targets.Count > 0)
        {
            Vector3 startPosition = targets[0].localPosition;               //target의 first
            Vector3 endPosition = targets[targets.Count - 1].localPosition; //target의 last
            Vector3 startToEnd = endPosition - startPosition;               //시작점->끝점

            //입력한 간격만큼 배치
            if (GUILayout.Button("Interval) Align"))
            {
                for (int i = 0; i < targets.Count; i++)
                {
                    targets[i].localPosition = startPosition + interval * i;
                }
            }

            //자동 배치
            if (GUILayout.Button("Start to End Align"))
            {
                //간격은 시작점->끝점을 target 개수-1 만큼 나눔
                interval = startToEnd / (targets.Count - 1);

                for (int i = 0; i < targets.Count; ++i)
                {
                    targets[i].localPosition = startPosition + interval * i;
                }
            }
        }
    }
}
