﻿/*****
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


[AddComponentMenu("3D Playground/Movement/Jump")]
[RequireComponent(typeof(Rigidbody))]

public class Jump : MonoBehaviour
{

    //Instance of PlayerInput (script)
    PlayerInput input;

    //reference to the rigidbody component
    Rigidbody go_Rigidbody;

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

    //Awake loads before scene start
    private void Awake()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        go_Rigidbody = GetComponent<Rigidbody>();

        //set Drag on the game object. Drag are between .001 (solid block of metal) and 10 (feather).
        //go_Rigidbody.drag= 0.001f;

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


    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (canJump && input.PlayerActions.Jump.triggered)
        {
            go_Rigidbody.AddForce(transform.up * jumpStrength, ForceMode.VelocityChange);
            canJump = !checkGround;
        }
    }//end FixedUpdate()

    //When player enters a collision
    private void OnCollisionEnter(Collision collisionData)
    {
        //if we are checking for the ground and we hit the ground tagged object
        if (checkGround && collisionData.gameObject.CompareTag(groundTag))
        {
            canJump = true; //set can jump to true
        }//end if
    }//end OnCollisionEnter(Collision collisionData)

}
