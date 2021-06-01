/*****
 * Author: Akram Taghavi-Burris
 * Date Created: May 24, 2021
 * Last Updated: May 25, 2021
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

public class Move : PhysicsObject
{

    //Instance of PlayerInput (script)
    PlayerInput input;


    //current movement
    Vector2 move; //vector 2 because we only need two values to be used in the vector3
    
    //check for movement
    bool movementPressed;

    [Header("Movement")]
    [Space(5)]
    [Header("[The GameObject moves when input is triggered]")]

    //variable for the speed of movement
    [Tooltip("how fast the object moves")]
    public float moveSpeed;

    [Header("Debug")]
	//Debug code
	[Tooltip("When checked will output values to console")]
	public bool debugCode = false;

    //Awake loads before scene start
    protected override void Awake()
    {
        //loades the awake from the base class
        base.Awake();

        //create new instace of playerInput 
        input = new PlayerInput();

        //When movement is preformed get the context and set the current movement to the read value
        input.PlayerActions.Movment.performed += ctx =>
        {
          //  Debug.Log(ctx.ReadValueAsObject()); //Debug Check to see what the input is reading
            move = ctx.ReadValue<Vector2>(); //get the vector of movement
            //set movmementPressed if we are not at zero
            movementPressed = move.x != 0 || move.y != 0;
          
            //if debugCode is true
            if (debugCode) { DebugCode(); }
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


    // Update is called every frame
    void Update()
    {
        //Get the velocity for Y
        float velocityY = go_Rigidbody.velocity.y;

        //set vector3 for new velocity 
        Vector3 go_Move = new Vector3(move.x * moveSpeed, velocityY, move.y * moveSpeed);
        
        //apply speed to velocity
        go_Rigidbody.velocity = go_Move;

    }//end Update()


    //outputs values to log for debugging.
    void DebugCode()
    {
        //output the transform position
        Debug.Log(gameObject.name + " Move Transform: " + transform.localPosition);
    }//end DebugCode()



}
