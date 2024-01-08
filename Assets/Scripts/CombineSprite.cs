using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CombineSprite : MonoBehaviour,IPointerClickHandler
{
    private Animator anim;
    private bool showNext;

    public GameObject[] NextSprites;

    public Enter enter;
    public enum Enter
    {
        Fade, Left, Right, Up, Down,
    }
    public Leave leave;
    public enum Leave
    {
        Fade, Left, Right, Up, Down,
    }
    public Click click;
    public enum Click
    {
        CloseThis,Stay, Button,OneTimeButton,Dialog,
    }
    public bool isMultClose;
    public GameObject[] multipleClose;
    public GameObject canvas;

    private void Start()
    {
        anim = GetComponent<Animator>();

        SetStates();
    }

    private void Update()
    {
        ClickBehavior();
    }

    private void SetStates()
    {
        switch (enter)
        {
            case Enter.Fade:
                anim.SetBool("FadeIn", true);
                break;
            case Enter.Left:
                anim.SetBool("EnterLeft", true);
                break;
            case Enter.Right:
                anim.SetBool("EnterRight", true);
                break;
            case Enter.Up:
                anim.SetBool("EnterUpward", true);
                break;
            case Enter.Down:
                anim.SetBool("EnterDown", true);
                break;
        }
    }

    private void ClickBehavior()
    {
        if (Input.GetMouseButton(0))
        {
            switch (click)
            {
                case Click.CloseThis:
                    ShowNext();
                    Finish();
                    break;
                case Click.Stay:
                    if (!showNext)
                        ShowNext();
                    break;
                case Click.Dialog:
                    CheckText();
                    break;
            }
        }
    }

    private void ShowNext()
    {
        for (int i = 0; i < NextSprites.Length; i++)
        {
            NextSprites[i].SetActive(true);
        }
        showNext = true;
    }

    public void Finish()
    {
        switch (leave)
        {
            case Leave.Fade:
                anim.SetTrigger("FadeOut");
                break;
            case Leave.Left:
                anim.SetTrigger("LeaveLeft");
                break;
            case Leave.Right:
                anim.SetTrigger("LeaveRight");
                break;
            case Leave.Up:
                anim.SetTrigger("LeaveUp");
                break;
            case Leave.Down:
                anim.SetTrigger("LeaveDown");
                break;
        }

        if (isMultClose)
            CloseMultiple();
    }

    private void CloseMultiple()//如果要关闭自身，则自身必须是最后一个
    {
        for (int i = 0; i < multipleClose.Length; i++)
        {
            multipleClose[i].transform.GetChild(0).GetComponent<CombineSprite>().Finish();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (click == Click.Button)
        {
            if (!showNext)
                ShowNext();
        }
        else if (click == Click.OneTimeButton)
        {
            ShowNext();
            Finish();
        }
    }

    private void CheckText()
    {
        string now = canvas.transform.GetChild(0).GetComponent<Text>().text;
        string ori = canvas.transform.GetChild(0).GetComponent<TextEffects>().str;
        if (now == ori)
        {
            canvas.SetActive(false);
            ShowNext();
            Finish();
        }
    }

    public void EnterFinish()
    {
        anim.SetBool("FadeIn", false);
        anim.SetBool("EnterLeft", false);
        anim.SetBool("EnterRight", false);
        anim.SetBool("EnterUpward", false);
        anim.SetBool("EnterDown", false);

        if (click == Click.Dialog)
        {
            canvas.SetActive(true);
        }
    }
    public void DestroyThis()
    {
        Destroy(transform.parent.gameObject);
    }
}
