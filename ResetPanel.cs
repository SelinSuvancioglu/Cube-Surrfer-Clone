using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetPanel : MonoBehaviour
{
    public bool IsReset;
    public void ResetGame()
    {
        IsReset = true;
        gameObject.transform.GetChild(0).gameObject.active = false;
        Time.timeScale = 1;
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
    public void OpenResetGamePanel()
    {
        Time.timeScale = 0;
        gameObject.transform.GetChild(0).gameObject.active = true;
    }
    public void CloseResetGamePanel()
    {
        Time.timeScale = 1;
        gameObject.transform.GetChild(0).gameObject.active = false;
    }
}
