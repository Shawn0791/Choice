using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scissors : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject startPosPrefab;

    private CircleCollider2D coll;
    private bool isStart;
    private Vector3 creatPos;
    private Animator anim;
    private void Start()
    {
        coll = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            coll.enabled = true;
            anim.SetBool("cutting", true);
            FollowTheMouse();

            if (!isStart)
            {
                isStart = true;
                creatPos = transform.position;
                Invoke("CreatStartPoint", 5);
            }

        }
        else if (Input.GetMouseButtonUp(0))
        {
            coll.enabled = false;
            anim.SetBool("cutting", false);
        }
    }

    private void FollowTheMouse()
    {
        Vector3 pos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x, pos.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("StartPos")&&isStart)
        {
            GameSuccess();
        }
        else
        {
            GameOver();
        }
    }

    private void CreatStartPoint()
    {
        Instantiate(startPosPrefab, creatPos, Quaternion.identity);
        isStart = true;
    }

    private void GameOver()
    {
        gameOverUI.SetActive(true);
    }
    private void GameSuccess()
    {
        SceneManager.LoadScene(14);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
