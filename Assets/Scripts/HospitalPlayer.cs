using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HospitalPlayer : MonoBehaviour
{
    public float Speed = 10;
    public Animator animator;
    [Header("ConversationPanel")]
    public GameObject ConversationPanel;
    public Text QuestionText;
    public GameObject LeftButton;
    public GameObject MiddleButton;
    public GameObject RightButton;
    public Image LeftPersonImage;
    public Image RightPersonImage;
    public Image RightPersonImage2;
    public Image RightPersonImage3;
    bool canMove = false;
    bool canClick = true;
    public List<string> Conversation = new List<string>();
    public Sprite father;
    public Sprite doctor;
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.Instance.isFightWithGirlFriend==true)
        {
            QuestionText.text = Conversation[GameManager.Instance.SentenceNumber];
        }
        if(GameManager.Instance.isVirusWar==true)
        {
            QuestionText.text = Conversation[GameManager.Instance.SentenceNumber];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetFloat("y", 1);
                animator.SetBool("Run", true);
                transform.Translate(0, Speed * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                animator.SetFloat("y", -1);
                animator.SetBool("Run", true);
                transform.Translate(0, -Speed * Time.deltaTime, 0);

            }
            else if (Input.GetKey(KeyCode.A))
            {
                animator.SetFloat("x", -1);
                animator.SetBool("Run", true);
                transform.Translate(-Speed * Time.deltaTime, 0, 0);

            }
            else if (Input.GetKey(KeyCode.D))
            {
                animator.SetFloat("x", 1);
                animator.SetBool("Run", true);
                transform.Translate(Speed * Time.deltaTime, 0, 0);

            }
            else
            {
                animator.SetFloat("x", 0);
                animator.SetFloat("y", 0);
                animator.SetBool("Run", false);
            }
        }
        //Debug.Log(canClick);
        QuestionText.text = Conversation[GameManager.Instance.SentenceNumber];
        if (canClick&&Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.SentenceNumber++;
            if(GameManager.Instance.SentenceNumber==8)
            {
                LeftPersonImage.enabled = true;
                RightPersonImage.enabled = false;
            }
            if (GameManager.Instance.SentenceNumber == 9)
            {
                LeftPersonImage.enabled = false;
                RightPersonImage.enabled = true;
            }
            if(GameManager.Instance.SentenceNumber==28)
            {
                RightPersonImage3.enabled = false;
                RightPersonImage.sprite = father;
                RightPersonImage.enabled = true;
            }
            if (GameManager.Instance.SentenceNumber == 29)
            {
                RightPersonImage.enabled = false;
                LeftPersonImage.enabled = true;
            }
            if (GameManager.Instance.SentenceNumber == 31)
            {
                RightPersonImage.enabled = true;
                RightPersonImage.sprite = doctor;
                LeftPersonImage.enabled = false;
            }
            Close();
        }
    }
    
    void Close()
    {
        if(GameManager.Instance.SentenceNumber == 3)
        {
            GameManager.Instance.isStart = true;
            ClosePanel();
        }
        if(GameManager.Instance.SentenceNumber == 6)
        {
            GameManager.Instance.task1 = true;
            ClosePanel();
        }
        if(GameManager.Instance.SentenceNumber == 11)
        {
            GameManager.Instance.task2 = true;
            ClosePanel();
            SceneManager.LoadScene("Fight With Girl Friend");
        }
        if (GameManager.Instance.SentenceNumber == 15)
        {
            GameManager.Instance.task3 = true;
            ClosePanel();
        }
        if (GameManager.Instance.SentenceNumber == 18)
        {
            GameManager.Instance.task4 = true;
            ClosePanel();
        }
        if (GameManager.Instance.SentenceNumber == 21)
        {
            GameManager.Instance.task5 = true;
            ClosePanel();
            SceneManager.LoadScene("Virus War");
        }
        if (GameManager.Instance.SentenceNumber == 25)
        {
            GameManager.Instance.task6 = true;
            ClosePanel();
        }
        if(GameManager.Instance.SentenceNumber==38)
        {
            GameManager.Instance.task7 = true;
            //ClosePanel();
            RightPersonImage.enabled = false;
            RightPersonImage2.enabled = false;
            RightPersonImage3.enabled = false;
            LeftButton.SetActive(true);
            RightButton.SetActive(true);
            MiddleButton.SetActive(true);
        }
    }

    void ClosePanel()
    {
        ConversationPanel.SetActive(false);
        RightPersonImage.enabled = false;
        RightPersonImage2.enabled = false;
        RightPersonImage3.enabled = false;
        canClick = false;
        canMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Conversation1"))
        {
            if(GameManager.Instance.task2==false)
            {
                canMove = false;
                canClick = true;
                ConversationPanel.SetActive(true);
                LeftPersonImage.enabled = false;
                RightPersonImage.enabled = true;
            }
        }
        if (collision.CompareTag("Conversation2"))
        {
            if(GameManager.Instance.task5==false&&GameManager.Instance.task4)
            {
                canMove = false;
                canClick = true;
                ConversationPanel.SetActive(true);
                LeftPersonImage.enabled = false;
                RightPersonImage2.enabled = true;
            }
        }
        if (collision.CompareTag("Conversation3"))
        {
            if (GameManager.Instance.task1==false)
            {
                canMove = false;
                canClick = true;
                ConversationPanel.SetActive(true);
                LeftPersonImage.enabled = false;
                RightPersonImage3.enabled = true;
            }
            if(GameManager.Instance.task4==false&&GameManager.Instance.isFightWithGirlFriend)
            {
                canMove = false;
                canClick = true;
                ConversationPanel.SetActive(true);
                LeftPersonImage.enabled = false;
                RightPersonImage3.enabled = true;
            }
            if(GameManager.Instance.task6&&GameManager.Instance.task7==false)
            {
                canMove = false;
                canClick = true;
                ConversationPanel.SetActive(true);
                LeftPersonImage.enabled = false;
                RightPersonImage3.enabled = true;
            }
        }
    }
}
