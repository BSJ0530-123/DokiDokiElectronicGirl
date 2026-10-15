using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SettingConsole : MonoBehaviour
{
    public GameObject SettingPanel;
    private int EscCount = 0;

    private void Start()
    {
        SettingPanel.SetActive(false);
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            SettingPanel.SetActive(true);
            EscCount++;
            if (EscCount > 1)
            {
                SettingPanel.SetActive(false);
                EscCount = 0;
            }
            
        }
    }
}
