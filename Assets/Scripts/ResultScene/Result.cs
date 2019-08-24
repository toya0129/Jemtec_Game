using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class Result : MonoBehaviour
{
    private GameController gameController;

    int gameScore = 0;
    float gameTime = 0f;

    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        gameScore = (int)gameController.Score;
        gameTime = (float)gameController.Time;
    }

    void Start()
    {
        List<int> scoreList = new List<int>();
        List<float> timeList = new List<float>();
        bool isLarge = false;
        for(int i = 0; i < 5; i++){
            scoreList.Add(PlayerPrefs.GetInt("ranking" + i.ToString(), 0));
            timeList.Add(PlayerPrefs.GetFloat("time" + i.ToString(), 0.0f));
            if(gameScore > scoreList[i] && !isLarge){
                scoreList.Insert(i, gameScore);
                timeList.Insert(i, gameTime);
                isLarge = true;
            }
        }

        for(int i = 0; i < 5; i++){
            PlayerPrefs.SetInt("ranking" + i.ToString(), scoreList[i]);
            PlayerPrefs.SetFloat("time" + i.ToString(), timeList[i]);
        }
        PlayerPrefs.Flush();
    }

    public int GameScore{
        set { gameScore = value;}
    }
}
