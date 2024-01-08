using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    //单例模式的使用，底下的代码别改
    public static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }

            return _instance;
        }
    }

    public int CurrentPage = 0;
    public float Pressure;
    public bool isStart = false;
    public bool task1 = false;
    public bool task2 = false;
    public bool task3 = false;
    public bool task4 = false;
    public bool task5 = false;
    public bool task6 = false;
    public bool task7 = false;
    public int SentenceNumber;
    public bool isFightWithGirlFriend = false;
    public bool isVirusWar = false;
    public bool isJumping = false;
    public int buttonID=1;
}
