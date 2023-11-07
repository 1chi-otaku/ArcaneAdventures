using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;
using UnityEngine.UI;
public class ShowPuzzle : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas PuzzleCanvas;
    public PlayerControlNoPhoton playerControl;
    public Text UserInputText;
    public string SecretCode = "MISTY";

    public bool SecretCodeEntered = false;

    //reference to the door animation
    public Animator GateOpen;

    public void Update()
    {
        if(UserInputText.text.ToUpper() == SecretCode.ToUpper() && SecretCodeEntered == false)
        {
            SecretCodeEntered = true;
            EPromptCanvas.enabled = false;
            PuzzleCanvas.enabled = false;
            playerControl.isMovementAllowed = true;
            Cursor.lockState = CursorLockMode.Locked;
            GateOpen.SetBool("IsPuzzleSolved", true);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && SecretCodeEntered == false)
        {
            //Проверка если кнопка E нажата.
            if(Input.GetKey(KeyCode.E)) {
                //Показывает канвас паззла.
                
                PuzzleCanvas.enabled = true;
                //Скрывает E кнопку с интерфейса.
                EPromptCanvas.enabled = false;
                playerControl.isMovementAllowed = false;
                Cursor.lockState = CursorLockMode.None;
            }
            if(Input.GetKey(KeyCode.Escape)) {
                
                ExitButton();
            }
        }
    }

    public void ExitButton()
    {
        PuzzleCanvas.enabled = false;
        EPromptCanvas.enabled = true;
        playerControl.isMovementAllowed = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
