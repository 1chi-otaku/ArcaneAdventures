using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMovementBeach : MonoBehaviour
{
    public PlayerControlNoPhoton movementscipt; // Укажите объект, у которого нужно изменить переменную
    private float originalVolume;

    private void Start()
    {
        StartCoroutine(DisableMovementForSeconds(11f));
    }

    private IEnumerator DisableMovementForSeconds(float seconds)
    {
        originalVolume = movementscipt.footstepsSound.volume;

        movementscipt.footstepsSound.volume = 0f;
        movementscipt.sprintSound.volume = 0f;

        // Ждем указанное количество секунд
        yield return new WaitForSeconds(seconds);

        movementscipt.isMovementAllowed = true;
        movementscipt.footstepsSound.volume = originalVolume;
        movementscipt.sprintSound.volume = originalVolume;
    }
}
