using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DrawButton : MonoBehaviour
{
    public void SetColor()
    {
        DrawManager.instance.currentColor = GetComponent<Image>().color;
        DrawManager.instance.RefreshPenColor();
    }
}
