using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Return : MonoBehaviour
{
    public Image mainMenuImage; // ссылка на главное изображение
    public Image currentImage; // ссылка на текущее изображение (ваше подменю)

    // ... другие переменные и методы, если нужны

    public void ReturnToMainMenu()
    {
        // Скрываем текущее изображение
        currentImage.gameObject.SetActive(false);

        // Отображаем главное изображение
        mainMenuImage.gameObject.SetActive(true);
    }
}
