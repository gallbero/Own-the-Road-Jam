using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreController: MonoBehaviour
{
    public static ScoreController instance;
    public ScoreView scoreView;
    public int score = 0;

    void Awake()
    {
        instance = this;
        scoreView = GetComponent<ScoreView>(); 
    }

    public void AddPoint()
    {
        score++;
        scoreView.UpdateScore(score);
    }

   public void ShowEndPanel()
    {
       scoreView.ShowEndPanel();
    }

    void RestartScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}