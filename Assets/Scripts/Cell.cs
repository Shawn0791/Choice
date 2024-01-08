using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public List<Vector2> CellList = new List<Vector2>();
    public GameObject cell;

    // Start is called before the first frame update
    void Start()
    {
        BornCell();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BornCell()
    {
        Vector2 randomPos = Vector2.zero;
        for (int i = 0; i < 50; i++)
        {
            randomPos.x = Random.Range(-50.0f, 50.0f);
            randomPos.y = Random.Range(-50.0f, 50.0f);
            if (Vector2.Distance(randomPos, new Vector2(CellList[i].x, CellList[i].y)) < 1)
            {
                break;
            }
            else
            {
                Instantiate(cell, gameObject.transform);
                cell.transform.position = randomPos;
                CellList.Add(randomPos);
            }
        }
    }
}
