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
            PlayerPrefs.SetInt("FifteenCompleted", PlayerPrefs.GetInt("FifteenCompleted") + 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameScene2");
        }
        if(isWin)
        {
            PlayerPrefs.SetInt("FifteenCompleted", PlayerPrefs.GetInt("FifteenCompleted") + 1);
            PlayerPrefs.Save();
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
