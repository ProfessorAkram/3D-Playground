/*****
 * Author: Akram Taghavi-Burris
 * Date Created: May 27, 2021
 * Last Updated: May 27, 2021
 * Description: Level manager sets the defaults for the level
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameManager))]
public class LevelManager : MonoBehaviour
{
    GameManager gm; //reference to game manager

    [Header("Level SETTINGS")] //compenent section heading

    public int levelLives = 3; // numver of lives in level
    [Tooltip("Image representing lives count. If left null a number will display")]
    public GameObject livesImage;

    [Tooltip("Can the level be beat by a score")]
    public bool canBeatLevel = false; //can the level be beat by a score
    public int beatLevelScore; // the score value to beat level

    [Tooltip("Is the level timed")]
    public bool timedLevel = false; //is the leve timed 
    public float startTime = 5.0f; //time for level (if level is timed)

    public static int playerLives = 3; //the number of player lives


    //Awake loads before scene start
    void Awake()
    {
        
        
    }//end Awake()

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        gm.Lives = playerLives;
        gm.gameUI.HUDSetup();
    }//end Start()

    // Update is called once per frame
    void Update()
    {
        
    }


}