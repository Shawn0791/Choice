using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightWithGirlFriend : MonoBehaviour
{
    public Text ConversationText;
    public Image HpImageMask;
    public Image HpImageMask2;
    public List<Button> buttons = new List<Button>();
    public Image Black;
    private bool Click = false;
    public AudioSource audio;
    public AudioSource audio2;
    public AudioClip clip;
    public AudioClip clip2;
    public Text BlackText;
    private bool Play = true;
    // Start is called before the first frame update
    void Start()
    {
        BlackText.enabled = false;
    }
    float temp;
    // Update is called once per frame
    void Update()
    {
        Black.fillAmount -= 0.7f * Time.deltaTime;
        if(Black.fillAmount<=0)
        {
            Black.enabled = false;
            Click = true;
        }
        if(HpImageMask.fillAmount<=0)
        {
            temp += Time.deltaTime;
            if(temp>=2)
            {
                Black.enabled = true;
                Black.fillAmount = 1;
                BlackText.enabled = true;
                audio2.enabled = false;
                if (Play)
                {
                    audio.PlayOneShot(clip2);
                    Play = false;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    GameManager.Instance.Pressure += 0.2f;
                    //Debug.Log(GameManager.Instance.Pressure);
                    GameManager.Instance.isFightWithGirlFriend = true;
                    SceneManager.LoadScene("Hospital");
                }
            }
            
        }
    }

    public void Skill(int number)
    {
        if(Click)
        {
            switch (number)
            {
                case 0:
                    ConversationText.text = "What are you fucking saying!";
                    HpImageMask.fillAmount -= 0.25f;
                    HpImageMask2.fillAmount += 0.25f;
                    break;
                case 1:
                    ConversationText.text = "You're an idiot!";
                    HpImageMask.fillAmount -= 0.25f;
                    HpImageMask2.fillAmount += 0.25f;
                    break;
                case 2:
                    ConversationText.text = "...";
                    HpImageMask.fillAmount -= 0.25f;
                    HpImageMask2.fillAmount += 0.25f;
                    break;
                case 3:
                    ConversationText.text = "Be quiet!";
                    HpImageMask.fillAmount -= 0.25f;
                    HpImageMask2.fillAmount += 0.25f;
                    break;
            }
            buttons[number].GetComponent<Button>().interactable = false;
            audio.PlayOneShot(clip);
        }
    }
}
