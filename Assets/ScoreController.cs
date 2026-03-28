using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreController: MonoBehaviour
{
    public int scoreToWin = 35;
    public static ScoreController instance;
    public ScoreView scoreView;
    public int score = 0;

    public bool ismenu = true;
    void Awake()
    {
      
        instance = this;
       if (!ismenu)
       {
            scoreView = GetComponent<ScoreView>();
            scoreView.UpdateScore(score + "/" + scoreToWin);
        }     

       
    }

    public void AddPoint()
    {
        if (ismenu) return;
        {
            score++;
            scoreView.UpdateScore(score + "/" + scoreToWin);
            if (score >= scoreToWin)
            {
                scoreView.ShowWinPanel();
            }
        }

    }

   public void ShowEndPanel()
   {
        if (ismenu) return;
        {
            scoreView.ShowEndPanel();

        }
        
       
   }


    public void nextscene(string nextscene)
    {
        
        SceneManager.LoadScene(nextscene);
    }
    public void RestartScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}