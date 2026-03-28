using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    public bool ismenu = true;
    public GameObject winpanel;
    private TextMeshProUGUI Scoretext;
    public GameObject EndPanel;
    // Start is called before the first frame update
    
    void Start()
    {
        if (ismenu) return;
        {
            winpanel.SetActive(false);
            Scoretext = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
            EndPanel.SetActive(false);

        }

         
    }

    public void UpdateScore(string score)
    {
        if (ismenu) return;
        {
            Scoretext.text = "Score: " + score.ToString();
        }   
    }

    public void ShowWinPanel()
    {
       if (ismenu) return;
        {
            winpanel.SetActive(true);
        }

        
    }   



    public void ShowEndPanel()
    {
        if (ismenu) return;
        {
            EndPanel.SetActive(true);
        }



    }
}
