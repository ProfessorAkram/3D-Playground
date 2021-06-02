/*****
 * Author: Akram Taghavi-Burris
 * Date Created: June 1, 2021
 * Last Updated: June 2, 2021
 * Description: Sets up the fade in and out for the dialogue group
 * Project: 3D Playground - a drag and drop framework for 3d game development derived from Unity's own 2D Playground framework.
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[AddComponentMenu("3D Playground/Actions/Dialogue")]
public class DialogueAction : Action
{
	//reference to dialogue group
	GameObject goDialogue; 



    [Header("Dialogue UI")]
    public GameObject dialogueUI;
    RectTransform panel;
    TMP_Text textBox;
	Button btn;
    TMP_Text btnTXT;

    [Header("Dialogue Text")]
    public string dialogueText;


	//ExecuteAction runs the action and must return a true or false.
	public override bool ExecuteAction(GameObject other)
    {
        //create instance of dialogue group
        goDialogue = Instantiate(dialogueUI);

		//set the dialogue
		setDialogue();
		setButton();

        return true;
    }

	//set the dialogue text to display [UPDATE IN FUTURE TO ACCEPT ARRAYS]
    void setDialogue()
    {
        //Get the text box of game object Dialogue
        textBox = goDialogue.GetComponent<DialogueUI>().dialogueTextBox;
        textBox.text = dialogueText;//set the text value


    }

    //sets the button text for the dialogue [UPDATE IN FUTURE TO CHANGE BASED ON AMOUNT OF DIALOGUE]
	void setButton()
    {
		btn = goDialogue.GetComponent<DialogueUI>().button;
        btnTXT = btn.GetComponentInChildren<TMP_Text>();
        btnTXT.text = "x";
	}



}
