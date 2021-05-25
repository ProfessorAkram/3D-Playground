/*****
 * Author: Akram Taghavi-Burris
 * Date Created: May 24, 2021
 * Last Updated: May 24, 2021
 * Description: Move game object with controls
 * Project: 3D Playground - a drag and drop framework for 3d game development derived from Unity's own 2D Playground framework.
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;


[AddComponentMenu("3D Playground/Movement/Move")]
[RequireComponent(typeof(Rigidbody))]

public class Move : MonoBehaviour
{

    //Instance of PlayerInput (script)
    PlayerInput input;

    //reference to the rigidbody component
    Rigidbody go_Rigidbody;

    //current movement
    Vector2 move;
    
    //check for movement
    bool movementPressed;

    [Header("Movement")]
    [Space(5)]  
    [Header("[The GameObject moves when input is triggered]")]
   
    //variable for the speed of movement
    [Tooltip("the speed in the horizontal direction (left and right)")]
    public float moveSpeedX;

    [Tooltip("the speed in the vertical direction (backwards and forwards)")]
    public float moveSpeedY; 

    //Awake loads before scene start
    private void Awake()
    {
		//Fetch the Rigidbody from the GameObject with this script attached
		go_Rigidbody = GetComponent<Rigidbody>();

        //Freeze all rotation
        go_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

        //create new instace of playerInput 
        input = new PlayerInput();

        //When movement is preformed get the context and set the current movement to the read value
        input.PlayerActions.Movment.performed += ctx =>
        {
          //  Debug.Log(ctx.ReadValueAsObject()); //Debug Check to see what the input is reading
            move = ctx.ReadValue<Vector2>(); //get the vector of movement
            movementPressed = move.x != 0 || move.y != 0; //set movmementPressed if we are not at zero
        };

        //When movement is cancled (zero) the movment
        input.PlayerActions.Movment.canceled += ctx => move = Vector2.zero;


    }//end Awake()



    //when game object is Enabled
    private void OnEnable()
    {
        //enable the playerInput actions
        input.PlayerActions.Enable();

    }//ednd OnEnable()

    //when game object is Disabled
    private void OnDisable()
    {
        //disable the playerInput actions
        input.PlayerActions.Disable();

    }//ednd OnEnable()


    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        Vector3 go_Move = new Vector3(move.x * moveSpeedX, 0, move.y * moveSpeedY);
        go_Rigidbody.velocity = go_Move; 
    }//end FixedUpdate()

}
