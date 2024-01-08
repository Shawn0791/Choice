using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HappyDieController : MonoBehaviour
{
    public Sprite page1;
    public Sprite page2;
    public Sprite page3;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.buttonID == 3)
        {
            gameObject.GetComponent<Book>().bookPages[3] = page1;
        }
        else if (GameManager.Instance.buttonID == 2)
        {
            gameObject.GetComponent<Book>().bookPages[3] = page2;
        }
        else if (GameManager.Instance.buttonID == 1)
        {
            gameObject.GetComponent<Book>().bookPages[3] = page3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
