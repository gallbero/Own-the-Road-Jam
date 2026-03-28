using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    // The URL you want to open
    public string url = "https://www.nyc.gov/html/dot/html/pr2026/activate-additional-red-light-cameras.shtml";

    // This function will be called when the button is clicked
    public void OpenWebsite()
    {
        Application.OpenURL(url);
    }
}

