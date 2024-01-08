using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DollManager : MonoBehaviour
{
    public static DollManager instance;
    private void Awake()
    {
        instance = this;
    }

    public void GameSuccess()
    {
        SceneManager.LoadScene(12);
    }
}
