/*****
 * Author: Akram Taghavi-Burris
 * Date Created: May 25, 2021
 * Last Updated: May 31, 2021
 * Description: Auto rotates game object
 * Project: 3D Playground - a drag and drop framework for 3d game development derived from Unity's own 2D Playground framework.
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("3D Playground/Movement/Auto Rotate")]
[RequireComponent(typeof(Rigidbody))]

public class AutoRotate : PhysicsObject
{
	
	[Header("Auto Rotate")]

	//rotation is along the x,y, or z axis
	[Tooltip("Which direction to rotate object: x , y, z")]
	//rotation Directions
	public string rotationDirection;

	[Header("[TIP: if the object rotates too slowly, try a larger amount]")]
	[Tooltip("How fast the object rotates when clicked")]
	// This is the force that rotate the object every frame
	public float rotationSpeed = 2.5f;

	Vector3 myRotation;

	[Header("Debug")]
	//Debug code
	[Tooltip("When checked will output values to console")]
	public bool debugCode = false;


	//when the scene starts
	private void Start()
    {
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


	// Update is called every frame
	private void Update()
	{
		//rotate object
		transform.Rotate(myRotation, rotationSpeed);

		//if debugCode is true
		if (debugCode) { DebugCode(); }

	}//end Update()
	


	//outputs values to log for debugging.
	void DebugCode()
	{
		//output the transform position
		Debug.Log(gameObject.name + " AutoRotate Rotation: " + transform.rotation);
	}//end DebugCode()


}
