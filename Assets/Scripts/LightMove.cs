using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LightMove : MonoBehaviour
{
    public float Speed = 10;
    public GameObject BlackPanel;
    public Text text;
    public GameObject ChoosePanel;
    public Text ChoiceText;
    public int temp;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Sentence");
    }

    IEnumerator Sentence()
    {
        text.text = "Wake Up!";
        yield return new WaitForSeconds(2);
        text.text = "Don't sleep again!";
        yield return new WaitForSeconds(2);
        text.text = "Listen to the sounds around you";
        yield return new WaitForSeconds(2);
        text.text = "Doctor: Your father has brain cancer ";
        yield return new WaitForSeconds(2);
        text.text = "Doctor: Now has the option of undergoing surgery";
        yield return new WaitForSeconds(3);
        text.text = "Doctor: It has a 60% success rate";
        yield return new WaitForSeconds(3);
        text.text = "Doctor: And even if the surgery is successful";
        yield return new WaitForSeconds(2);
        text.text = "Doctor: He may live up to six months";
        yield return new WaitForSeconds(3);
        text.text = "Your Daughter: I don't want to lose my father, we want to do the operation";
        yield return new WaitForSeconds(3);
        text.text = "Doctor: This can be a long and painful treatment";
        yield return new WaitForSeconds(3);
        text.text = "Doctor: So ask the patient what he thinks when he wakes up";
        yield return new WaitForSeconds(3);
        BlackPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Translate(x * Speed * Time.deltaTime, y * Speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChoosePanel.SetActive(true);
        if (collision.CompareTag("Exit"))
        {
            ChoiceText.text = "Have you decided to go ahead with the operation?";
            temp = 0;
        }
        else if(collision.CompareTag("Exit2"))
        {
            ChoiceText.text = "Have you decided to give up the operation?";
            temp = 1;
        }
    }

    public void Yes(int i)
    {
        i = temp;
        if(i==0)
        {
            SceneManager.LoadScene("SadDie");
        }
        else
        {
            SceneManager.LoadScene("HappyDie");
        }
    }
    public void No()
    {
        ChoosePanel.SetActive(false);
    }
}
