using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
	private GameController gameController;

    [SerializeField]
    private QuestionScript questionScript;

    public string correct_answer = null;

    public GameObject correct_image;
    public GameObject incorrect_image;

    private int total_score = 0;
    private int game_level = 0;

    private int[] rem_time;

    private float time = 0.0f;

    private void Awake()
	{
		gameController = GameObject.Find("GameController").GetComponent<GameController>();
		game_level = gameController.Level;
	}

    // Start is called before the first frame update
    void Start()
    {
        rem_time = questionScript.Remember_Time;
		correct_image.SetActive(false);
        incorrect_image.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    public void OnClick_Answer(string answer_button)
    {
        if(answer_button == correct_answer)
        {
            total_score += 1;
            correct_image.SetActive(true);
        }
        else
        {
            incorrect_image.SetActive(true);
        }

        correct_answer = null;
        questionScript.NextInterval();
    }

    public void GameFinish()
	{
        float t = time - (rem_time[game_level - 1] + 3) * questionScript.MaxQuestion;
        gameController.Time = t;
        gameController.Score = total_score * 10 - (int)t;
		GameObject.Find("SceneLoad").GetComponent<SceneLoad>().Transition(3);
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
