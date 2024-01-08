using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        
    }
    int i = 1;
    float cd;
    // Update is called once per frame
    void Update()
    {
        if (cd >= 0.5f)
        {
            gameObject.GetComponent<Image>().sprite = sprites[i];
            i++;
            if (i >= 3)
            {
                i = 0;
            }
            cd = 0;
        }
        cd += Time.deltaTime;
        
    }
}
