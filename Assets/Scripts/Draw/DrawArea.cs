using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawArea : MonoBehaviour,IPointerClickHandler
{
    private bool isDraw;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isDraw)
        {
            DrawManager.instance.finishedAreaNum++;
            isDraw = true;
        }

        GetComponent<SpriteRenderer>().color = DrawManager.instance.currentColor;
        DrawManager.instance.CheckNum();
    }
}
