/*****
 * Author: Akram Taghavi-Burris
 * Date Created: May 31, 2021
 * Last Updated: May 31, 2021
 * Description: Rotate object with left mouse click
 * Project: 3D Playground - a drag and drop framework for 3d game development derived from Unity's own 2D Playground framework.
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;


[AddComponentMenu("3D Playground/Movement/Rotate")]
[RequireComponent(typeof(Rigidbody))]

public class Rotate : PhysicsObject
{
   	//Instance of PlayerInput (script)
	PlayerInput input;

	//reference to main camera
	Camera mainCamera;

	//refence to camera's clickcheck
	ClickCheck clicked;

	[Header("Rotate")]
	[Header("Use the left mouse button to slowly rotate the object")]

	//rotation is along the x,y, or z axis
	[Tooltip("Which direction to rotate object: x , y, z")]
	//rotation Directions
	public string rotationDirection;

	[Tooltip("How fast the object rotates when clicked")]
	// This is the force that rotate the object every frame
	public float rotationSpeed = 2.5f;

	Vector3 myRotation; 

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

		//set main camera
		mainCamera = Camera.main;

		//check if a ClickCheck is not on the main camera
		if(mainCamera.gameObject.GetComponent<ClickCheck>() == null)
        {
			//add the ClickCheck component to the main camera 
			mainCamera.gameObject.AddComponent(typeof(ClickCheck));
		}

	}//end Awake()

	// Start is called before the first frame update
	private void Start()
	{
		//get the ClickCheck of the main camera
		clicked = mainCamera.GetComponent<ClickCheck>();

		//set string to lowercase
		rotationDirection.ToLower();

		//Set rotation
		switch (rotationDirection)
        {
			case "x":
				myRotation = Vector3.left;
				break;
			case "y":
				myRotation = Vector3.up;
				break;
			case "z":
				myRotation = Vector3.forward;
				break;
			default:
				myRotation = Vector3.forward;
				break;
		}//end switch

	}

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
	
		if (clicked.clickedObj == this.name) {

		transform.Rotate(myRotation, rotationSpeed);
			clicked.clickedObj = null;

		}//end if(Rotate)

		//if debugCode is true
		if (debugCode) { DebugCode(); }

	}//end Update() 




	//outputs values to log for debugging.
	void DebugCode()
	{
		//output the transform position
		Debug.Log(gameObject.name + " Rotation: " + transform.rotation);
	}//end DebugCode()



}
