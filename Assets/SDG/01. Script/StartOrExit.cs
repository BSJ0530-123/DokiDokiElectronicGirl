using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOrExit : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Load Main Scene");
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
