using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugUI : MonoBehaviour
{
    public Text text;

    private void Awake()
    {
        if (GameManager.isDebugging)
        {
            text.text = "Debug Mode On";
        }
        else
        {
            text.text = "Debug Mode Off";
        }
    }

    public void SetDebug()
    {
        GameManager.isDebugging = !GameManager.isDebugging;
        if (GameManager.isDebugging)
        {
            text.text = "Debug Mode On";
        }
        else
        {
            text.text = "Debug Mode Off";
        }
    }
}
