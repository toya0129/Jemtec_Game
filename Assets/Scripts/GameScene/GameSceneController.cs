using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    [SerializeField]
    private QuestionScript questionScript;

    public string correct_answer = null;

    public GameObject correct_image;
    public GameObject incorrect_image;

    private int total_score = 0;
    private int game_level = 1;

    // Start is called before the first frame update
    void Start()
    {
        correct_image.SetActive(false);
        incorrect_image.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick_Answer(string answer_button)
    {
        if(answer_button == correct_answer)
        {
            total_score += game_level * 10;
            correct_image.SetActive(true);
        }
        else
        {
            incorrect_image.SetActive(true);
        }

        correct_answer = null;
        questionScript.NextInterval();
    }

    #region getter and setter
    public string Correct_Answer
    {
        set { correct_answer = value; }
        get { return correct_answer; }
    }
    public int GameLevel
    {
        get { return game_level; }
        set { game_level = value; }
    }
    #endregion
}
