using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class DialogueLine
{
    public string name; // Имя персонажа
    public string sentence; // Текст диалога
    public Sprite characterSprite; // Спрайт персонажа
}

public class ManagmentTrainingDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI nameText;
    public Image characterImage;
    public DialogueLine[] lines;
    public float textSpeed;

    private int index;
    private bool isTyping = false;

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isTyping)
        {
            NextLine();
        }
    }

    void StartDialogue()
    {
        index = 0;
        UpdateDialogueUI(index); 
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        textComponent.text = "";
        foreach (char c in lines[index].sentence.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isTyping = false;
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            UpdateDialogueUI(index); 
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void UpdateDialogueUI(int lineIndex)
    {
        nameText.text = lines[lineIndex].name;
        characterImage.sprite = lines[lineIndex].characterSprite;

        float offsetForText = 200 + 10; 

        // Настройка RectTransform для textComponent
        RectTransform textRectTransform = textComponent.GetComponent<RectTransform>();
        textRectTransform.anchorMin = new Vector2(0, 0);
        textRectTransform.anchorMax = new Vector2(1, 0);
        textRectTransform.pivot = new Vector2(0, 0);
        textRectTransform.offsetMin = new Vector2(offsetForText, textRectTransform.offsetMin.y); // Устанавливаем отступ слева
        textRectTransform.offsetMax = new Vector2(-10, textRectTransform.offsetMax.y); // Небольшой отступ справа

        // Настройка RectTransform для nameText, чтобы он был над textComponent
        RectTransform nameTextRectTransform = nameText.GetComponent<RectTransform>();
        nameTextRectTransform.anchorMin = new Vector2(0, 1);
        nameTextRectTransform.anchorMax = new Vector2(1, 1);
        nameTextRectTransform.pivot = new Vector2(0.5f, 1);
        nameTextRectTransform.offsetMax = new Vector2(-10, -10); // Небольшой отступ от верхнего края канваса
        nameTextRectTransform.offsetMin = new Vector2(offsetForText, -nameText.preferredHeight - 10); // Высота nameText плюс небольшой отступ
    }



}
