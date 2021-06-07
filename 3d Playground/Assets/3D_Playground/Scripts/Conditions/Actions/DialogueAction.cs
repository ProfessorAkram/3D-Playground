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

[AddComponentMenu("3D Playground/Actions/Dialogue")]
public class DialogueAction : Action
{
    //check if dialogue is closed
    bool dialogueClosed;

    //reference to dialogue group
    GameObject goDialogue;

    //the canvas for the UI Interaction
    GameObject ui_canvas;

    //reference to main camera
    Camera mainCamera;

    //Ui Interantion 
    UiInteraction uiInterantion;


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
        Debug.Log(goDialogue);

        //set the dialogue
        setDialogue();
        setUiInteraction();
        setButton();

        return true;
    }


    // Update is called every frame
    void Update()
    {
        //if goDialogue exsists
        if (!dialogueClosed)
        {
            if (uiInterantion.ui_element.name == btn.name)
            {
                dialogueClosed = true;
                //run button action [UPDATE IN FUTRE TO ACCEPT MULTIPLE ACTIONS]
                goDialogue.GetComponent<DialogueUI>().CloseDialogue();

            }

        }

        if (goDialogue && dialogueClosed)
        {
            Destroy(goDialogue, 5);
            if (this.gameObject.GetComponent<ConditionCollision>().destroyOnCollision)
            {
                Destroy(this.gameObject, 5);
            }
        }

    }//end Update() 


    //set the dialogue text to display [UPDATE IN FUTURE TO ACCEPT ARRAYS]
    void setDialogue()
    {
        //Get the text box of game object Dialogue
        textBox = goDialogue.GetComponent<DialogueUI>().dialogueTextBox;
        textBox.text = dialogueText;//set the text value


    }

    //setup the main camera to add the UiInteraction compoenent 
    void setUiInteraction()
    {
        //set main camera
        mainCamera = Camera.main;

        //check if a UiInteraction is not on the main camera
        if (mainCamera.gameObject.GetComponent<UiInteraction>() == null)
        {
            //add the UiInteraction component to the main camera 
            mainCamera.gameObject.AddComponent(typeof(UiInteraction));
        }

        //get the uiInteraction of the main camera
        uiInterantion = mainCamera.GetComponent<UiInteraction>();

        //set the ui canvas for interaction
        ui_canvas = goDialogue.GetComponent<DialogueUI>().dialogueCanvas;
        uiInterantion.setUICanvas(ui_canvas);

    }

    //sets the button text for the dialogue [UPDATE IN FUTURE TO CHANGE BASED ON AMOUNT OF DIALOGUE]
    void setButton()
    {
        btn = goDialogue.GetComponent<DialogueUI>().button;
        btnTXT = btn.GetComponentInChildren<TMP_Text>();
        btnTXT.text = "x";
    }



}