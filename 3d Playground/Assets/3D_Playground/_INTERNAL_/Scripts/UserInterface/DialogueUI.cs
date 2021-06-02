/*****
 * Author: Akram Taghavi-Burris
 * Date Created: June 1, 2021
 * Last Updated: June 1, 2021
 * Description: Sets up the fade in and out for the dialogue group
 * Project: 3D Playground - a drag and drop framework for 3d game development derived from Unity's own 2D Playground framework.
 ****/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    CanvasGroup dialogueGroup;
    public GameObject dialogueCanvas;
    public RectTransform panel;
    public TMP_Text dialogueTextBox;
    public Button button;


    [Header("Dialogue Animation") ]
    [Tooltip("Set ture to fade in, false to fade out")]
    public bool fadeIn= true; 
    [Tooltip("Amount of time for fade animation")]
    public float fadeDuration = 1.5f;

    float timeElapsed;
    float transparent = 0;
    float opaque = 1;
    float startValue;
    float endValue;

    private void Awake()
    {
        dialogueGroup = GetComponent<CanvasGroup>();
        dialogueGroup.alpha = transparent;
    }

    private void Start()
    {
        StartCoroutine(FadeDialogue());
        Debug.Log(dialogueGroup);

    }

    public void CloseDialogue()
    {
        Debug.Log("CloseDialouge");
        StartCoroutine("FadeDialogue");

    }

    // Dialogue box fades in and out
  IEnumerator FadeDialogue()
     {// fade from opaque to transparent

        timeElapsed = 0;

        //if sets the fade in or out
        if (fadeIn)
        { //time to fade in
            Debug.Log("Fade In= " + fadeIn);
            startValue = transparent;
            endValue = opaque;
            fadeIn = false;
        }
        else
        {
            Debug.Log("Fade In= " + fadeIn);
            startValue = opaque;
            endValue = transparent;
            fadeIn = true;
        }

        //While loop runs the animation over time
            while (timeElapsed < fadeDuration)
            {
                dialogueGroup.alpha = Mathf.Lerp(startValue, endValue, timeElapsed / fadeDuration);
                timeElapsed += Time.deltaTime;
            yield return null;
        }

            dialogueGroup.alpha = endValue;
            yield return null;

        }//end FadeDialogue()




}
