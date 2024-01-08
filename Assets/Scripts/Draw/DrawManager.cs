using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawManager : MonoBehaviour
{
    public Color currentColor=Color.white;
    public int finishedAreaNum;
    public SpriteRenderer pen;

    public static DrawManager instance;
    private void Awake()
    {
        instance = this;
        Cursor.visible = false;
    }

    public void CheckNum()
    {
        if (finishedAreaNum >= 19)
        {
            Cursor.visible = true;
            SceneManager.LoadScene(8);
        }
    }

    public void RefreshPenColor()
    {
        pen.color = currentColor;
    }
}
