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


[AddComponentMenu("3D Playground/Movement/Jump")]
[RequireComponent(typeof(Rigidbody))]

public class Jump : PhysicsObject
{

    //Instance of PlayerInput (script)
    PlayerInput input;

    [Header("Jump Setup")]
    [Space(5)]
    [Header("[The GameObject jumps on button (space bar) press]")]

    //variable for the speed of movement
    [Tooltip("the strength of the jump force")]
    public float jumpStrength;

    //current movement
    Vector3 jump = new Vector3(0, 2, 0);

    [Header("Ground Setup")]
    	//if the object collides with another object tagged as this, it can jump again
	public string groundTag = "Ground";

	//this determines if the script has to check for when the player touches the ground to enable him to jump again
	//if not, the player can jump even while in the air
	public bool checkGround = true;

	private bool canJump = true;

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
        if (canJump && input.PlayerActions.Jump.triggered)
        {
            //add jump force
            go_Rigidbody.AddForce(transform.up * jumpStrength, ForceMode.VelocityChange);
            
            //no longer on ground
            canJump = !checkGround;

            //if debugCode is true
            if (debugCode) { DebugCode(); }
        }

    }//end Update()

    //When player enters a collision
    private void OnCollisionEnter(Collision collisionData)
    {
        //if we are checking for the ground and we hit the ground tagged object
        if (checkGround && collisionData.gameObject.CompareTag(groundTag))
        {
            canJump = true; //set can jump to true
        }//end if
    }//end OnCollisionEnter(Collision collisionData)


    //outputs values to log for debugging.
    void DebugCode()
    {
        //output the transform position
            Debug.Log(gameObject.name + " Jump");
    }//end DebugCode()
}
