using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffects : MonoBehaviour
{
    public int speed;

    public string str;
    Text tex;
    int i = 0;   //调整这个可以调整出现的速度
    int index = 0;
    string str1 = "";
    bool ison = true;

    void Start()
    {
        tex = GetComponent<Text>();
        str = tex.text;
        tex.text = "";
        i = speed;
    }

    void Update()
    {
        if (ison)
        {
            i -= 1;
            if (i <= 0)
            {
                if (index >= str.Length)
                {
                    ison = false;
                    return;
                }
                str1 = str1 + str[index].ToString();
                tex.text = str1;
                index += 1;
                i = speed;
            }
        }

    }
}
