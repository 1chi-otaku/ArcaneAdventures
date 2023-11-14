using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueWindow : MonoBehaviour
{
    public TMP_Text textComponent;
    public Image characterImage;
    private string currentText;
    private CanvasGroup group;

    private void Start()
    {
        // �������� ��������� CanvasGroup
        group = GetComponent<CanvasGroup>();
        // �������� � �������� ��������� (��������������, ��� ������ ���� �������)
        group.alpha = 1;

        // ��������� ������� � ������� ����������� ���������
        RectTransform rectTransform = characterImage.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0); // ����� ������ ����
        rectTransform.anchorMax = new Vector2(0, 0); // ����� ������ ����
        rectTransform.pivot = new Vector2(0, 0); // ������� ������ ������ ������� ����
        rectTransform.anchoredPosition = new Vector2(10, 10); // ������ �� ������ ������� ����
        rectTransform.sizeDelta = new Vector2(200, 200); // ������� ����������� ������ 200x200 ��������
                                                         // ��������� ������� � ������� ���������� ����������
                                                         // ��������� ������� � ������� ���������� ����������
        RectTransform textRectTransform = textComponent.GetComponent<RectTransform>();
        textRectTransform.anchorMin = new Vector2(0, 0);
        textRectTransform.anchorMax = new Vector2(1, 1);
        textRectTransform.pivot = new Vector2(0, 0);

        // ������������� ������ ����� ������ ������ �������� ���� ��������� ������
        textRectTransform.offsetMin = new Vector2(200 + 20, textRectTransform.offsetMin.y);
        // �� ������ ��������� offsetMax, ���� ���������� ���������� ����� � ������ ������
    }

    public void Show(string text, Sprite characterSprite)
    {
        currentText = text;
        characterImage.sprite = characterSprite;
        group.alpha = 1; // ������� �� �������
        StartCoroutine(TypeLine());
    }

    public void Hide()
    {
        StopAllCoroutines();
        group.alpha = 0; // ������� �� ���������
    }

    private IEnumerator TypeLine()
    {
        textComponent.text = "";
        foreach (char c in currentText.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
}
