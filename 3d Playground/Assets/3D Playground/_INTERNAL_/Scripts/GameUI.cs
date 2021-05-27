/*****
 * Author: Akram Taghavi-Burris
 * Date Created: May 27, 2021
 * Last Updated: May 27, 2021
 * Description: game UI object setup and functions
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //using TextMesh Pro
using System; //using system data 


public class GameUI : MonoBehaviour
{
    GameManager gm; //reference to game manager

    [Header("MAIN MENU")]//compenent section heading
    public GameObject mainMenu; //canvas for the main menu
    public Image logoImage; //display for the game title/logo image
    public TMP_Text titleDisplay; //text display for title
    public TMP_Text creditsDisplay; //text display for credits
    public TMP_Text copyrightDisplay; //text display for copyright

    [Space(10)] //space between compenent sections
   
    [Header("HUD MENU")]//compenent section heading
    public GameObject levelHUD; //canvas for the in game HUD

    public string scoreTitle = "Score: ";  //text before score value
    public TMP_Text scoreTitleDisplay; //display text before the score
    public TMP_Text scoreValueDisplay; //text display for score

    [Space(10)] //space between compenent sections

    public string livesTitle = "Lives: "; //text before lives value
    public GameObject lives; // game object representing lives
    public TMP_Text livesTitleDisplay; //display text before the lives
    public TMP_Text livesValueDisplay; //text display for lives

    [Space(10)] //space between compenent sections

    public string timerTitle = "Timer: "; //text before timer value
    public TMP_Text timerTitleDisplay; //display text before the timer
    public TMP_Text timerValueDisplay; //text display for timer

    [Space(10)] //space between compenent sections

    [Header("PAUSE MENU")]//compenent section heading
    public GameObject pauseMenu; //canvas for the pause menu

    [Space(10)] //space between compenent sections

    [Header("END MENU")]//compenent section heading
    public GameObject endScreen; //end screen canves

    public string gameOver = "Game Over"; //text before lives value
    public TMP_Text gameOverDisplay; // text display for end message

    [Space(10)] //space between compenent sections

    public TMP_Text messageDisplay; // text display for end message

    //Awake is called when the game loads (before Start)
    void Awake()
    {
        gameObject.tag = "HUD";
    }//end Awake()

    // Start is called before the first frame update
    private void Start()
    {
        gm = GameManager.Instance;

        //HIDE all Interfaces
        hideInterface(mainMenu);

        //Setup all Interfaces
        MainMenuSetup();

        //check Debug
        DebugCode();

    }//end Start()

    //Debug code
    void DebugCode()
    {
        //debug menus referenced by game manager
        if (gm.debugMainMenu) { showInterface(mainMenu);}
        if (gm.debugLevelHUD) { showInterface(levelHUD); }
        if (gm.debugPauseMenu) { showInterface(pauseMenu); }
        if (gm.debugEndScreen) { showInterface(endScreen); }

    }//end DebugCode()

    public void hideInterface(GameObject myUI)
    {
        myUI.SetActive(false);
    }

    public void showInterface(GameObject myUI)
    {
        myUI.SetActive(true);
    }//end showInteface


    //Main menu on inital start of game
    public void MainMenuSetup()
    {
        titleDisplay.text = gm.gameTitle; //sets the game title
        //creditsDisplay.text = gm.gameCredits; //set game credits
        //copyrightDisplay.text = gm.copyrightDate; //set game copyright
    }//end MainMenu()


        //setup for the HUD 
        public void HUDSetup()
    {

    }//end HUDSetup()



}
