using System.Collections;
using UnityEngine;
using TMPro;
using WebSocketSharp;

public class DialogueWindow : MonoBehaviour
{
    public TMP_Text Text;
    private string CurrentText;

    CanvasGroup Group;
    private void Start()
    {
        Group  = GetComponent<CanvasGroup>();
        Group.alpha = 0;
    }
    public void Show(string text)
    {
        Group.alpha = 1;
        CurrentText = text;
        StartCoroutine(DisplayText());
    }
    public void Hide()
    {
        StopAllCoroutines();
        Group.alpha = 0;
    }
    private IEnumerator DisplayText()
    {
        Text.text = "";
        foreach (char c in CurrentText.ToCharArray())
        {
            Text.text +=c;
            yield return new WaitForSecondsRealtime(0.1f);
        }
        yield return null;
    }
}
