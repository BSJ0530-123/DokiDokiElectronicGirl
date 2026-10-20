using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOrExit : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Load Main Scene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
