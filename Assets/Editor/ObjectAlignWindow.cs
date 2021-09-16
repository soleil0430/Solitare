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

    public List<Transform> targets = new List<Transform>(); //����
    public Vector3 interval;                                //����

    ScriptableObject thisWindow;
    SerializedObject serializedObject;
    SerializedProperty targetsProperty;
    private void OnGUI()
    {
        //targets�� EditorGUILayout�� Ȱ���ؼ� �����쿡 ���̰� �ϴ� ����
        thisWindow = this;
        serializedObject = new SerializedObject(thisWindow);
        targetsProperty = serializedObject.FindProperty("targets");
        EditorGUILayout.PropertyField(targetsProperty, true);
        serializedObject.ApplyModifiedProperties();

        //���� �Է�
        interval = EditorGUILayout.Vector3Field(new GUIContent("Position Interval"), interval);

        //target�� 1�� �̻� ������
        if (targets.Count > 0)
        {
            Vector3 startPosition = targets[0].localPosition;               //target�� first
            Vector3 endPosition = targets[targets.Count - 1].localPosition; //target�� last
            Vector3 startToEnd = endPosition - startPosition;               //������->����

            //�Է��� ���ݸ�ŭ ��ġ
            if (GUILayout.Button("Interval) Align"))
            {
                for (int i = 0; i < targets.Count; i++)
                {
                    targets[i].localPosition = startPosition + interval * i;
                }
            }

            //�ڵ� ��ġ
            if (GUILayout.Button("Start to End Align"))
            {
                //������ ������->������ target ����-1 ��ŭ ����
                interval = startToEnd / (targets.Count - 1);

                for (int i = 0; i < targets.Count; ++i)
                {
                    targets[i].localPosition = startPosition + interval * i;
                }
            }
        }
    }
}
