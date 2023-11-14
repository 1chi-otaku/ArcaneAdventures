using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPrompt : MonoBehaviour
{
    //Канвас, который отображает кнопку E на экране.
    public Canvas EpromptCanvas;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" )
        {
            //Отображение кнопки E.
            EpromptCanvas.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player" )
        {
            EpromptCanvas.enabled = false;
        }
    }
}
