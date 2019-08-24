using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class Result : MonoBehaviour
{
    int gameScore = 0;
    
    void Start()
    {
        List<int> scoreList = new List<int>();
        bool isLarge = false;
        for(int i = 0; i < 5; i++){
            scoreList.Add(PlayerPrefs.GetInt("ranking" + i.ToString(), 0));
            if(gameScore > scoreList[i] && !isLarge){
                scoreList.Insert(i, gameScore);
                isLarge = true;
            }
        }

        for(int i = 0; i < 5; i++){
            PlayerPrefs.SetInt("ranking" + i.ToString(), scoreList[i]);
        }
        PlayerPrefs.Flush();
    }

    public int GameScore{
        set { gameScore = value;}
    }
}
