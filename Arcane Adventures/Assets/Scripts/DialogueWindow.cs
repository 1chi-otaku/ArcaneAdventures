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
        // Получаем компонент CanvasGroup
        group = GetComponent<CanvasGroup>();
        // Начинаем с видимого состояния (предполагается, что должно быть видимым)
        group.alpha = 1;

        // Настройка позиции и размера изображения персонажа
        RectTransform rectTransform = characterImage.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0); // Левый нижний угол
        rectTransform.anchorMax = new Vector2(0, 0); // Левый нижний угол
        rectTransform.pivot = new Vector2(0, 0); // Поворот вокруг левого нижнего угла
        rectTransform.anchoredPosition = new Vector2(10, 10); // Отступ от левого нижнего угла
        rectTransform.sizeDelta = new Vector2(200, 200); // Размеры изображения теперь 200x200 пикселей
                                                         // Настройка позиции и размера текстового компонента
                                                         // Настройка позиции и размера текстового компонента
        RectTransform textRectTransform = textComponent.GetComponent<RectTransform>();
        textRectTransform.anchorMin = new Vector2(0, 0);
        textRectTransform.anchorMax = new Vector2(1, 1);
        textRectTransform.pivot = new Vector2(0, 0);

        // Устанавливаем отступ слева равным ширине картинки плюс небольшой отступ
        textRectTransform.offsetMin = new Vector2(200 + 20, textRectTransform.offsetMin.y);
        // Вы можете настроить offsetMax, если необходимо ограничить текст с других сторон
    }

    public void Show(string text, Sprite characterSprite)
    {
        currentText = text;
        characterImage.sprite = characterSprite;
        group.alpha = 1; // Сделать всё видимым
        StartCoroutine(TypeLine());
    }

    public void Hide()
    {
        StopAllCoroutines();
        group.alpha = 0; // Сделать всё невидимым
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
