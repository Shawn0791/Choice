using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene3Questions : MonoBehaviour
{
    [Header("PressurePanel")]
    public GameObject PressurePanel;
    public Image PressureImageMask;
    [Header("DistortionsPanel")]
    public GameObject DistortionsPanel;
    public float ColorAlpha = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PressureImageMask.fillAmount = GameManager.Instance.Pressure;
        //Debug.Log(PressureImageMask.fillAmount);
        ColorAlpha = GameManager.Instance.Pressure;
        DistortionsPanel.GetComponent<Image>().color = new Color(1, 0, 0, ColorAlpha);
    }

    public void Left()
    {
        GameManager.Instance.buttonID = 1;
        SceneManager.LoadScene("Hospital Result");
    }

    public void Middle()
    {
        GameManager.Instance.buttonID = 2;
        SceneManager.LoadScene("Hospital Result");
    }

    public void Right()
    {
        GameManager.Instance.buttonID = 3;
        SceneManager.LoadScene("Hospital Result");
    }
}
