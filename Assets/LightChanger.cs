using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public bool isGreen = true;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.green;
        isGreen = true;
    }

    void OnMouseDown()
    {
        if (!isGreen)
        {
            spriteRenderer.color = Color.green;
            isGreen = true;
        }
        else
        {
            spriteRenderer.color = Color.red;
            isGreen = false;

        }
    }
}
