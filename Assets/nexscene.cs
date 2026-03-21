using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nexscene : MonoBehaviour
{
    public void nextscene(string nextscene)
    {

        SceneManager.LoadScene(nextscene);
    }
}
