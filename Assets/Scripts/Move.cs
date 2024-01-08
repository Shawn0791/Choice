using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public float Speed = 10;
    public Image Mask;
    public Text CellNumberText;
    public int CellNumber;
    public GameObject QuestionPanel;
    public Text Question;
    private float speed = 0.05f;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioClip clip;
    public GameObject HitPanel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Hit");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Translate(x * Speed * Time.deltaTime, y * Speed * Time.deltaTime, 0);
        Mask.fillAmount -= speed * Time.deltaTime;
        if(Mask.fillAmount<=0)
        {
            audioSource2.enabled = false;
            SceneManager.LoadScene("VirusWar");
        }
    }

    IEnumerator Hit()
    {
        yield return new WaitForSeconds(5);
        HitPanel.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag=="Cell")
        {
            Destroy(collision.collider.gameObject);
            audioSource.PlayOneShot(clip);
            Mask.fillAmount += 0.2f;
            CellNumber++;
            CellNumberText.text = CellNumber.ToString() + "/20";
            StartCoroutine("BigScale");
            if(CellNumber>=20)
            {
                speed = 0;
                audioSource2.enabled = false;
                QuestionPanel.SetActive(true);
            }
        }
    }

    IEnumerator BigScale()
    {
        transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(0.1f);
        transform.localScale = new Vector3(0.9f, 0.9f, 1);
    }
    public List<Button> buttons = new List<Button>();
    public void Yes()
    {
        GameManager.Instance.Pressure += 0.2f;
        Question.text = "The morphine got him hooked again.";
        buttons[0].GetComponent<Button>().interactable = false;
        buttons[1].GetComponent<Button>().interactable = false;
        StartCoroutine("ChangeScene");
    }

    public void No()
    {
        GameManager.Instance.Pressure += 0.2f;
        Question.text = "He had been detoxing successfully for a long time, and the pain made him buy drugs again.";
        buttons[0].GetComponent<Button>().interactable = false;
        buttons[1].GetComponent<Button>().interactable = false;
        StartCoroutine("ChangeScene");
    }

    IEnumerator ChangeScene()
    {
        GameManager.Instance.isVirusWar = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Hospital");
    }
}
