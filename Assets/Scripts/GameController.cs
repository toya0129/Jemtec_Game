using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private SceneLoad sceneLoad;

    private int game_score = 0;
    private int game_level = 0;
    private float clear_time = 0.0f;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectLevel(int level_number)
    {
        switch (level_number)
        {
            case 1:
                game_level = 1;
                sceneLoad.Transition(2);
                break;
            case 2:
                game_level = 2;
                sceneLoad.Transition(2);
                break;
            case 3:
                game_level = 3;
                sceneLoad.Transition(2);
                break;
            default:
                break;
        }
    }

    #region getter and setter
    public int Level
    {
        get { return game_level; }
        set { game_level = value; }
    }

    public int Score
    {
        get { return game_score; }
        set { game_score = value; }
    }

    public float Time
    {
        get { return clear_time; }
        set { clear_time = value; }
    }
    #endregion
}
