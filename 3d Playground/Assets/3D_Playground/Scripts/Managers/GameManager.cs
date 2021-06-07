/*****
 * Author: Akram Taghavi-Burris
 * Date Created: May 27, 2021
 * Last Updated: May 27, 2021
 * Description: Game mamanger script to conrol basic game behaviors and variables. 
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager: MonoBehaviour
{
    /*** VARIABLES ***/


    #region GameManager Singleton
    /**Static varibles are the same for all instances of a class. 
      *More on static vairbles https://learn.unity.com/tutorial/statics-l
    **/

    //set a static varible of the class named instance
    static GameManager instance; //instance of the GameManger
    public static GameManager Instance { get { return instance; } } //access to read only private variable instance [get methods]

    //Check to make sure only one instance of the GameManager is in the scene
    void CheckGameManagerIsInScene()
    {
        //Check if instnace is null
        if (instance == null)
        {
            instance = this; //set instance to this instance of the game object
        }
        else //else if instance is not null a Game Manager must already exsist
        {
            Destroy(this.gameObject); //In this case you need to delete this instance
        }
        DontDestroyOnLoad(this); //Do not delete the GameManager when scenes load
    }//end CheckGameManagerIsInScene()
    #endregion

    public GameObject userInterface; //the UI prefab for the game;

    [HideInInspector]
    public GameUI gameUI;//the GameUI component of the UI object
 
    [Header("GENERAL SETTINGS")] //compenent section heading
    public Sprite gameTitleLogo; //Image of the game title/logo
    public string gameTitle = "Untitled Game";  //name of the game
    public string gameCredits = "Made by Me"; //game creator(s)
    public string copyrightDate = "Copyright " + thisDay; //date cretaed

    [Space(10)] //space between compenent sections

    [Header("GAME SETTINGS")] //compenent section heading

    [Tooltip("If not set, the player will default to the gameObject tagged as Player.")]
    public GameObject player; //player obeject

    public static int score;  //score value
    public static int lives; // number of lives for player
    //access to private variable Lives [get/set methods]
    public int Lives { get { return lives; } set { lives = value; } }

    public string looseMessage = "You Loose"; //Message if player looses
    public string winMessage = "You Win"; //Message if player wins

    [Header("Only check one item at a time to debug properly.")]
    [Header("DEBUG")]
    [Tooltip("Check to show Main Menu")]
    public bool debugMainMenu = false;
    [Tooltip("Check to show Pause")]
    public bool debugPauseMenu = false;
    [Tooltip("Check to show HUD")]
    public bool debugLevelHUD = false;
    [Tooltip("Check to show End")]
    public bool debugEndScreen = false;


    public static int currentScene = 0; //the current level id
    public static int gameLevelScene = 3;//the first game level
  
    bool died = false;//player has died
     //access to private variable died [get/set methods]
    public bool Died { get { return died; } set { died = value; } }

    //Game State Varaiables
    [HideInInspector] public enum gameStates { Playing, Death, GameOver, BeatLevel };//enumof game states
    [HideInInspector] public gameStates gameState = gameStates.Playing;//current game state
    [HideInInspector] public bool gameIsOver = false;//is the game over
   




    private float currentTime; //sets current time for timer
    private bool gameStarted = false; //test if games has started
    private static string thisDay = System.DateTime.Now.ToString("yyyy"); //today's date as string



    /*** MEHTODS ***/
    //Awake is called when the game loads (before Start)
    void Awake()
    {
        //runs the method to check for the GameManager
        CheckGameManagerIsInScene();

        //store the current scene
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex; 

    }//end Awake()

    // Start is called before the first frame update
    private void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(userInterface, new Vector3(0, 0, 0), Quaternion.identity);
        gameUI = userInterface.GetComponent<GameUI>();

        //check Debug
        DebugCode();
    }//end Start()

    void DebugCode()
    {

    }//end DebugCode()



}//end GameManager
