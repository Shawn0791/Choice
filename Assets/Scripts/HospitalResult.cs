using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HospitalResult : MonoBehaviour
{
    public Text text;
    public GameObject DistortionsPanel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Story");
    }

    IEnumerator Story()
    {
        text.text = "You broke up with your girlfriend";
        yield return new WaitForSeconds(3);
        text.text = "I hope you won't regret it later";
        yield return new WaitForSeconds(3);
        text.text = "Do you remember the junkie";
        yield return new WaitForSeconds(3);
        text.text = "Did you really do the right thing? He's addicted again because of you.";
        yield return new WaitForSeconds(4);
        text.text = "Remember that multiple-choice question you've been wrestling with for the rest of your life";
        yield return new WaitForSeconds(6);
        text.text = "Your life has been changed forever because of this";
        yield return new WaitForSeconds(4);
        switch (GameManager.Instance.buttonID)
        {
            case 1:
                text.text = "Didn't do the leader's job, got shunned around the hospital";
                yield return new WaitForSeconds(4);
                text.text = "You didn't treat your father, and your family doesn't understand you";
                yield return new WaitForSeconds(5);
                text.text = "But only you know, life is not cheap, this is medical ethics";
                yield return new WaitForSeconds(4);
                break;
            case 2:
                text.text = "You failed to complete the work given to you by your leader and you were fired";
                yield return new WaitForSeconds(6);
                text.text = "To heal your family, you violate the medical principle that life has no value";
                yield return new WaitForSeconds(4);
                text.text = "It was posted on the Internet, and you spent the rest of your life under public pressure";
                yield return new WaitForSeconds(6);
                break;
            case 3:
                text.text = "You seize the opportunity and get a promotion and a raise";
                yield return new WaitForSeconds(4);
                text.text = "But your family doesn't understand you at all, sees you as mercenary and disowns you";
                yield return new WaitForSeconds(6);
                text.text = "Your colleagues are giving you a hard time about it";
                yield return new WaitForSeconds(4);
                break;
        }
        text.text = "You are lost in thought";
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Jumping");
    }

    // Update is called once per frame
    void Update()
    {
        DistortionsPanel.GetComponent<Image>().color = new Color(1, 0, 0, 0.6f);
    }
}
