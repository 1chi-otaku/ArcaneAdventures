using UnityEngine;
using UnityEngine.UI;

public class ClearInputField : MonoBehaviour
{
    public InputField inputField;

    public void ClearInput()
    {
        if (inputField != null)
        {
            inputField.text = ""; // Очищаем текст в input field
        }
    }
}