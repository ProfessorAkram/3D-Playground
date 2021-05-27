/*****
 * Author: Akram Taghavi-Burris
 * Date Created: May 25, 2021
 * Last Updated: May 25, 2021
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
	[Header("[TIP: if the object rotates too slowly, try a larger amount]")]
	[Header("Auto Rotate")]
	[Header("[The GameObject rotates along the Y axis, at a given speed]")]

	// This is the force that rotate the object every frame
	public float rotationSpeed = 5;

	[Header("Debug")]
	//Debug code
	[Tooltip("When checked will output values to console")]
	public bool debugCode = false;

	//angular velocity of the game object
	Vector3 m_EulerAngleVelocity;



	//when the scene starts
    private void Start()
    {
		m_EulerAngleVelocity = new Vector3(0, rotationSpeed, 0);
	}

    // FixedUpdate is called once per frame
    void FixedUpdate()
	{
		Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
		go_Rigidbody.MoveRotation(go_Rigidbody.rotation * deltaRotation);

	}//end FixedUpdate()

	// Update is called every frame
	private void Update()
	{
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
