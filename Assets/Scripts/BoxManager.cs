using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxManager : MonoBehaviour
{
    public GameObject[] objs;

    void Update()
    {
        if (objs[0].activeSelf == true &&
objs[1].activeSelf == true &&
objs[2].activeSelf == true &&
objs[3].activeSelf == true)
        {
            Destroy(GameObject.FindGameObjectWithTag("BGM"));
            SceneManager.LoadScene("Hospital");
        }
    }
}
