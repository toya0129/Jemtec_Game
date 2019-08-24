using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class Ranking : MonoBehaviour
{
    [SerializeField]
    List<Text> rankingTextList = new List<Text>();
    [SerializeField]
    List<Text> rankingText_time = new List<Text>();

    void Start()
    {
        for(int i = 0; i < 5; i++){
            this.rankingTextList[i].text = "Score = " + PlayerPrefs.GetInt("ranking" + i.ToString(), 0).ToString() + "点";
        }
    }
}
