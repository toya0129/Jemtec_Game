using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class QuestionScript : MonoBehaviour
{
    [SerializeField]
    private GameSceneController gameSceneController;
    [SerializeField]
    private GameObject panel_area;
    
    [SerializeField]
    private GameObject[,] panel = new GameObject[5,5];

    // 先頭2要素が部分一致の際変更される
    private List<string> correct_figure = new List<string>()
    {
        "13,16,6,7,11,12",
        "13,16,6,7,11,12",
        "13,16,6,7,11,12",
        "13,16,6,7,11,12",
        "13,16,6,7,11,12",
        "13,16,6,7,11,12",
        "13,16,6,7,11,12",
        "13,16,6,7,11,12",
        "13,16,6,7,11,12",
        "13,16,6,7,11,12"
    };

    [SerializeField]
    private GameObject description_text;
    [SerializeField]
    private GameObject remember_timer_text;
    [SerializeField]
    private GameObject start_timer_text;

    private int[] remember_timer = { 3, 5, 7 };
    private int start_timer = 3;

    [SerializeField]
    private List<int> now_figure = new List<int>();
    private int now_question = 0;

    private void Awake()
    {
        Initialized();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetCorrectFigure();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Initialized()
    {
        // panel set
        for (int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                panel[i,j] = panel_area.transform.GetChild(i).GetChild(j).gameObject;
            }
        }
    }

    private void SetCorrectFigure()
    {
        ResetPanel();
        description_text.GetComponent<Text>().text = "この図形を覚えてください";
        now_question = Random.Range(0, correct_figure.Count);

        string[] figure = correct_figure[now_question].Split(',');

        for(int i = 0; i < figure.Length; i++)
        {
            now_figure.Add(int.Parse(figure[i]));
            int row = now_figure[i] / 5;
            int column = now_figure[i] % 5;
            panel[row, column].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
        StartCoroutine(TimerStart(remember_timer[gameSceneController.GameLevel - 1], remember_timer_text, 0));
    }

    private void SetGenerateFigure(int question_number)
    {
        ResetPanel();
        description_text.GetComponent<Text>().text = "この図形は一つ前の図形と\n全く同じですか？";
        int rand = Random.Range(0, 10);
        List<int> generate = new List<int>();
        
        switch (rand)
        {
            // 部分的に一致
            case 0:
            case 1:
            case 2:
            case 3:
                gameSceneController.Correct_Answer = "Partially";
                for (int x = 0; x < now_figure.Count; x++)
                {
                    generate.Add(now_figure[x]);
                }

                int remove_panel = generate[Random.Range(0, 1)];
                generate.Remove(remove_panel);

                int add_rand = Random.Range(0, 2);

                while (add_rand != 0)
                {
                    int change_panel = generate[Random.Range(0, now_figure.Count - 1)];
                    int direction_rand = Random.Range(0, 4);

                    switch (direction_rand)
                    {
                        case 0:
                            change_panel -= 5; 
                            break;
                        case 1:
                            change_panel += 1;
                            break;
                        case 2:
                            change_panel += 5;
                            break;
                        case 3:
                            change_panel -= 1;
                            break;
                        default:
                            break;
                    }

                    bool add_flag = false;
                    if (change_panel < 0 || change_panel > 24)
                    {

                    }
                    else
                    {
                        if (change_panel != remove_panel)
                        {
                            for (int a = 0; a < generate.Count; a++)
                            {
                                if (generate[a] == change_panel)
                                {
                                    add_flag = false;
                                    break;
                                }
                                add_flag = true;
                            }
                        }
                        else
                        {
                            add_flag = false;
                        }
                    }

                    if (add_flag)
                    {
                        generate.Add(change_panel);
                        add_rand--;
                    }

                }

                if (!CheckGenerate(now_figure, generate))
                {
                    gameSceneController.Correct_Answer = "Yes";
                }
                break;
            // 完全に一致
            case 4:
            case 5:
            case 6:
                gameSceneController.Correct_Answer = "Yes";
                generate = now_figure;
                break;
            // 全く違う
            case 7:
            case 8:
            case 9:
                gameSceneController.Correct_Answer = "No";
                int generate_rand = Random.Range(0, 25);
                generate.Add(generate_rand);

                while(generate.Count < now_figure.Count)
                {
                    bool generate_flag = false;
                    int direction_rand = Random.Range(0, 4);
                    switch (direction_rand)
                    {
                        case 0:
                            generate_rand -= 5;
                            break;
                        case 1:
                            generate_rand += 1;
                            break;
                        case 2:
                            generate_rand += 5;
                            break;
                        case 3:
                            generate_rand -= 1;
                            break;
                        default:
                            break;
                    }

                    if (generate_rand < 0 || generate_rand > 24)
                    {
                        switch (direction_rand)
                        {
                            case 0:
                                generate_rand += 5;
                                break;
                            case 1:
                                generate_rand -= 1;
                                break;
                            case 2:
                                generate_rand -= 5;
                                break;
                            case 3:
                                generate_rand += 1;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        for (int g = 0; g < generate.Count; g++)
                        {
                            if (generate[g] == generate_rand)
                            {
                                generate_flag = false;
                                break;
                            }
                            generate_flag = true;
                        }
                    }

                    if (generate_flag)
                    {
                        generate.Add(generate_rand);
                    }
                }

                if (!CheckGenerate(now_figure, generate))
                {
                    gameSceneController.Correct_Answer = "Yes";
                }
                break;
            default:
                gameSceneController.Correct_Answer = "Yes";
                generate = now_figure;
                break;
        }

        for (int i = 0; i < generate.Count; i++)
        {
            int row = generate[i] / 5;
            int column = generate[i] % 5;
            panel[row, column].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }

        StartCoroutine(TimerStart(start_timer, start_timer_text, 1));
    }

    public bool CheckGenerate(List<int> now, List<int> gene)
    {
        int match = 0;

        for(int n = 0; n < now.Count; n++)
        {
            for(int g = 0; g < gene.Count; g++)
            {
                if(now[n] == gene[g])
                {
                    match += 1;
                }
            }
        }

        if (match >= gene.Count)
        {
            return false;
        }
        return true;
    }

    public void NextInterval()
    {
        correct_figure.RemoveAt(now_question);
        now_figure = new List<int>();
        StartCoroutine(TimerStart(start_timer, remember_timer_text, 2));
    }

    private void ResetPanel()
    {
        for (int a = 0; a < 5; a++)
        {
            for (int b = 0; b < 5; b++)
            {
                panel[a, b].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
        }
    }

    IEnumerator TimerStart(int end_time, GameObject set_text, int flag)
    {
        set_text.transform.parent.gameObject.SetActive(true);
        while (end_time >= 0)
        {
            set_text.GetComponent<Text>().text = end_time.ToString();
            yield return new WaitForSeconds(1f);
            end_time--;
        }
        set_text.transform.parent.gameObject.SetActive(false);

        switch(flag)
        {
            case 0:
                SetGenerateFigure(now_question);
                break;
            case 2:
                gameSceneController.correct_image.SetActive(false);
                gameSceneController.incorrect_image.SetActive(false);
                SetCorrectFigure();
                break;
            default:
                break;
        }
        yield break;
    }
}
