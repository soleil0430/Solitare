using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class TouchTest : MonoBehaviour
{
    public GameObject m_Parent;
    private GameObject[] m_Children;

    void Start()
    {
    }

    private void OnValidate()
    {
        m_Children = GetChildren(m_Parent);
        Order(true);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Order(true); // 오름차순
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Order(false); // 내림차순
        }
    }

    void Order(bool isAscending)
    {
        if (isAscending)
            m_Children = m_Children.OrderBy(go => go.name).ToArray();

        else
            m_Children = m_Children.OrderByDescending(go => go.name).ToArray();

        for (int i = 0; i < m_Children.Length; i++)
        {
            m_Children[i].transform.SetSiblingIndex(i);
        }
    }

    GameObject[] GetChildren(GameObject parent)
    {
        GameObject[] children = new GameObject[parent.transform.childCount];

        for (int i = 0; i < parent.transform.childCount; i++)
        {
            children[i] = parent.transform.GetChild(i).gameObject;
        }

        return children;
    }
}
