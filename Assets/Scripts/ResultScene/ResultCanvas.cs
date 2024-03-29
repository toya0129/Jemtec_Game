﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultCanvas : MonoBehaviour
{
    private GameController gameController;

    [SerializeField]
    private Text score_text;
    [SerializeField]
    private Text time_text;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        score_text.text = "Score = " + gameController.Score.ToString() + "点";
        time_text.text = "Time = " + gameController.Time.ToString() + "秒";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
