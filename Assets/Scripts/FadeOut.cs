using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public int nextSceneIndex;

    public void NextScene()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
}
