using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jumping : MonoBehaviour
{
    public Mesh Pasture;
    public Material Grass;
    public float Speed = 10;
    private int Cure = 0;
    public GameObject Black;
    public float BlackSpeed;
    public float CureSpeed;
    public AudioSource audioSource;
    public AudioClip clip;
    public GameObject Hint;
    public Text HintText;
    public List<GameObject> Land = new List<GameObject>();
    public Material WasteLand;
    public Material Desert;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("HintTime");
        Go();
    }

    IEnumerator HintTime()
    {
        yield return new WaitForSeconds(5);
        Hint.SetActive(false);
    }

    void Go()
    {
        index = UnityEngine.Random.Range(0, Land.Count);
        Land[index].tag = "Desert";
        Land[index].GetComponent<MeshRenderer>().material = WasteLand;
        //for(float cd=0;cd<=3;cd+=Time.deltaTime)
        //{

        //}
        //Land[index].tag = "Untagged";
        //Land[index].GetComponent<MeshRenderer>().material = Desert;
        //Go();
    }

    //IEnumerator Go()
    //{
    //    index = UnityEngine.Random.Range(0, Land.Count);
    //    Land[index].tag = "Desert";
    //    Land[index].GetComponent<MeshRenderer>().material = WasteLand;
    //    //yield return new WaitForSeconds(3);
    //    //Land[index].tag = "Untagged";
    //    //Land[index].GetComponent<MeshRenderer>().material = Desert;
    //    yield return null;
    //}

    float ColorAlpha = 0.7f;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Translate(x * Speed * Time.deltaTime, y * Speed * Time.deltaTime, 0);
        if(Cure>=22)
        {
            Hint.SetActive(true);
            HintText.text = "Press the Space to wake up";
            ColorAlpha += BlackSpeed * Time.deltaTime;
            Black.GetComponent<Image>().color = new Color(0, 0, 0, ColorAlpha);
            if(Input.GetKey(KeyCode.Space))
            {
                ColorAlpha -= CureSpeed * Time.deltaTime;
            }
        }
        if(ColorAlpha>=1)
        {
            SceneManager.LoadScene("Jumping");
        }
        else if(ColorAlpha<=0)
        {
            BlackSpeed = 0;
            HintText.text = "Wake Up!";
            GameManager.Instance.Pressure += 0.2f;
            SceneManager.LoadScene("BlackMaze");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Desert"))
        {
            other.GetComponent<MeshFilter>().mesh = Pasture;
            other.GetComponent<MeshRenderer>().material = Grass;
            other.tag = "Untagged";
            if(Land.Count>=2)
            {
                Land.RemoveAt(index);
                Go();
            }
            Cure++;
            audioSource.PlayOneShot(clip);
        }
    }
}
