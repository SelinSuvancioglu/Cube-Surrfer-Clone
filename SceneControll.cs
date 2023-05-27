using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneControll : MonoBehaviour
{
    [SerializeField] GameObject LosePanel, WinPanel, StartPanel, EndPanell, CanvasForCoinText;
    public Toplayici toplayici;
    public GameObject Level, LevelWrite;
    public int LevelCount;
    private int DefaultLevelIndex = 1;
    public TMP_Text LevelCountText;

    public void Start()
    {
        //Level = GameObject.Find("WhichLevel");
        //LevelWrite = GameObject.Find("Level");
        CanvasForCoinText = GameObject.Find("CanvasForCoinText");
        LevelWrite = CanvasForCoinText.transform.GetChild(7).gameObject;
        Level = CanvasForCoinText.transform.GetChild(8).gameObject;
        Level.active = true;
        LevelWrite.active = true;
        toplayici.movementStop();
        LevelCountText = Level.GetComponent<TMP_Text>();
        SaveTheLevel();
        //DefaultLevelIndex = 0;
        SaveDefaultLevel();
        //PlayerPrefs.DeleteAll();
        start1level();
    }
    public void TryAgain()
    {
        LosePanel.active = false;
        Level.active = true;
        LevelWrite.active = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        WinPanel.active = false;
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
           Level.active = true;
           LevelWrite.active = true;
           increaseLevel();
            DefaultLevelIndex = 0;
            PlayerPrefs.SetInt("key2", DefaultLevelIndex);
            //SceneManager.LoadScene(0);
            SceneManager.LoadScene(DefaultLevelIndex);

        }
        else
        {
            Level.active = true;
            LevelWrite.active = true;
            ++DefaultLevelIndex;
            PlayerPrefs.SetInt("key2", DefaultLevelIndex);
            increaseLevel();
            SceneManager.LoadScene(DefaultLevelIndex);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void ClickPlay()
    {
        Debug.Log("Seviye indisi: " + DefaultLevelIndex);
        StartPanel.active = false;
        Level.active = false;
        LevelWrite.active = false;
        toplayici.OnMovement();
    }

    //public void ReturnLevel1()
    //{
    //    EndPanell.active = false;
    //    SceneManager.LoadScene(0);
    //}
    public void increaseLevel()
    {
        LevelCount = int.Parse(LevelCountText.text);
        ++LevelCount;
        PlayerPrefs.SetInt("key1", LevelCount);
        LevelCountText.text = LevelCount.ToString();

    }
    public void SaveTheLevel() // Canvastaki seviye yazýsýýný koruyor
    {
        if (PlayerPrefs.HasKey("key1"))
        {
            LevelCount = PlayerPrefs.GetInt("key1");
            LevelCountText.text = LevelCount.ToString();
        }
        else
        {
            PlayerPrefs.SetInt("key1", 1);
            LevelCountText.text = PlayerPrefs.GetInt("key").ToString();
        }
    }

    public void SaveDefaultLevel() // Mevcut sahne indexini koruyor
    {
        if (PlayerPrefs.HasKey("key2"))
        {
            DefaultLevelIndex = PlayerPrefs.GetInt("key2");
            if (SceneManager.GetActiveScene().buildIndex != DefaultLevelIndex)
            {
                SceneManager.LoadScene(DefaultLevelIndex);
            }
            else
            {
                Debug.Log("Zaten seviyedesin");
            }

        }
        else
        {
            PlayerPrefs.SetInt("key2", 0);
            //LevelCountText.text = PlayerPrefs.GetInt("key2").ToString();
        }
    }
    public void start1level()
    {
        LevelCount = int.Parse(LevelCountText.text);
        if (LevelCount == 0)
        {
            LevelCount = 1;
            PlayerPrefs.SetInt("key1", LevelCount);
            LevelCountText.text = LevelCount.ToString();
        }
    }

}



