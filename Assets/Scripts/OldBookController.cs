using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OldBookController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameManager.Instance.CurrentPage);
        if (GameManager.Instance.CurrentPage == 4)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("End");
            }
        }
    }
}
