using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetUI : MonoBehaviour
{
    public void ResetGame()
    {
        SceneManager.LoadScene(gameObject.scene.name);
    }
}
