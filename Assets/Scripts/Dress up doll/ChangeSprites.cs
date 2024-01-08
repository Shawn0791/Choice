using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprites : MonoBehaviour
{
    private List<GameObject> objs = new List<GameObject>();
    private int index;
    private void Start()
    {
        UpdateList();
    }
    public void PreviousOne()
    {
        if (index <= 0)
            index = transform.childCount-1;
        else
            index--;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        transform.GetChild(index).gameObject.SetActive(true);
    }

    public void NextOne()
    {
        if (index >= transform.childCount-1)
            index = 0;
        else
            index++;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        transform.GetChild(index).gameObject.SetActive(true);
    }

    private void UpdateList()
    {
        objs.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            objs.Add(transform.GetChild(i).gameObject);
        }
    }
}
