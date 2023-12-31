using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {

        public bool finished { get; protected set; }

        protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont, float delay, AudioClip sound, float delayBetweenCutscenes)
        {
            //textHolder.color = textColor;
            textHolder.font = textFont;
            Debug.Log("Text Color: " + textColor.ToString());

            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                SoundManager.instance.PlaySound(sound);
                yield return new WaitForSeconds(delay);
            }
            //yield return new WaitForSeconds(delayBetweenCutscenes);
            yield return new WaitUntil(() => Input.GetMouseButton(0));
            finished = true;
        }
    }
}