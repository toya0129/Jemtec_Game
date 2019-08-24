using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void Transition (int sceneNumber){
        switch(sceneNumber){
            case 0:
                SceneManager.LoadScene("TitleScene");
                break;
            case 1:
                SceneManager.LoadScene("LevelSelectScene");
                break;
            case 2:
                SceneManager.LoadScene("GameScene");
                break;
            case 3:
                SceneManager.LoadScene("ResultScene");
                break;
            case 4:
                SceneManager.LoadScene("RankingScene");
                break;
            case 5:
                Application.Quit();
                break;
            default:
                break;
        }
    }
}
