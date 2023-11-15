using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NIkitaWindow : MonoBehaviour
{
    public TMP_Text textComponent;
    private string currentText;
    private CanvasGroup group;

    private void Start()
    {
        group = GetComponent<CanvasGroup>();
        group.alpha = 0;
        
    }

    public void Show(string text)
    {
        currentText = text;
        group.alpha = 1; 
        StartCoroutine(TypeLine());
    }

    public void Hide()
    {
        StopAllCoroutines();
        group.alpha = 0; 
    }

    private IEnumerator TypeLine()
    {
        textComponent.text = "";
        foreach (char c in currentText.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

}
