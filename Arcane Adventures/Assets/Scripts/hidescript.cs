using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidescript : MonoBehaviour
{
    CanvasGroup gr;
    void Start()
    {
        gr = GetComponent<CanvasGroup>();
        gr.alpha = 1;
    }
    public void Open()
    {
        gr.alpha = 1;
    }
    public void Hide()
    {
        gr.alpha = 0;
    }

    
}
