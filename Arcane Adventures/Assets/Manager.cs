using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public Cube[] cube;
    public bool isWin;
    public void win()
    {
        for(int i = 0; i < cube.Length; i++)
        {
            if (cube[i].number != cube[i].numberCell)
                return;
        }
        isWin = true;
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("GameScene2");
        }
        if(isWin)
        {

            StartCoroutine(ReloadSceneAfterDelay(2f));
            SceneManager.LoadScene("GameScene2");
        }
    }
    IEnumerator ReloadSceneAfterDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameScene2");
    }
}
