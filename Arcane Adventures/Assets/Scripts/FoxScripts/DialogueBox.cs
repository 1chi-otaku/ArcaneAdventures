using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    public GameObject targetObject;

    private void Start()
    {
        targetObject.SetActive(true);
    }

    private void Update()
    {
        // ����� ����� �������� ������� ��� ������������ ���������� targetObject, ���� �����
    }
}