using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    private TextMeshProUGUI Scoretext;
    public GameObject EndPanel;
    // Start is called before the first frame update
    void Start()
    {
        Scoretext = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        EndPanel.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        Scoretext.text = "Score: " + score;
    }

    public void ShowEndPanel()
    {
        EndPanel.SetActive(true);
    }
}
