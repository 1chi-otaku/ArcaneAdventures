using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixCursor : MonoBehaviour
{
    private void Awake()
    {
        // Сделать курсор видимым и разблокировать его при загрузке сцены
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnDestroy()
    {
        // При уничтожении объекта сохранить состояние курсора
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
