using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    public GameObject winpanel;
    private TextMeshProUGUI Scoretext;
    public GameObject EndPanel;
    // Start is called before the first frame update
    void Start()
    {
        winpanel.SetActive(false);  
        Scoretext = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        EndPanel.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        Scoretext.text = "Score: " + score;
    }

    public void ShowWinPanel()
    {
        winpanel.SetActive(true);
    }   



    public void ShowEndPanel()
    {
        EndPanel.SetActive(true);
    }
}
