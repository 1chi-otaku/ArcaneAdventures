using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class task : MonoBehaviour
{
    RectTransform rectTransform;
    public float floatHeight = 0.5f; 
    public float floatSpeed = 1.0f; 
    private void Start()
    {

        rectTransform = GetComponent<RectTransform>();
    }
    private void Update()
    {
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        rectTransform.position = new Vector3(transform.position.x, newY+0.3f, transform.position.z);
    }
}

