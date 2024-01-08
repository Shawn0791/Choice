using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager:MonoBehaviour
{
    //单例模式的使用，底下的代码别改
    public static MusicManager instance;
    public GameObject GameOverUI;
    private void Awake()
    {
        instance = this;
    }

    public int CurrentPage = 0;

    private int index = 0;
    public Note[] notes;
    public void CheckCurrentMusic(int i)
    {
        if (i == notes[index].typeIndex)
        {
            notes[index].ChangeColor();
            index++;
            CheckWin();
        }
        else
        {
            GameOver();
        }
    }
    private void CheckWin()
    {
        if (index > 13)
        {
            Invoke("LoadNext", 0.5f);
        }
    }

    private void LoadNext()
    {
        SceneManager.LoadScene(10);
    }

    private void GameOver()
    {
        GameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
