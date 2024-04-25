using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    public GameObject settingsCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSettingsCanvas();

            Time.timeScale = settingsCanvas.activeSelf ? 0f : 1f;
        }
    }

    void ToggleSettingsCanvas()
    {
        settingsCanvas.SetActive(!settingsCanvas.activeSelf);
    }

    public void ReturnToGame()
    {
        Time.timeScale = 1f;

        settingsCanvas.SetActive(false);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}