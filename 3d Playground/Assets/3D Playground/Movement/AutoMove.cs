/*****
 * Author: Akram Taghavi-Burris
 * Date Created: May 24, 2021
 * Last Updated: May 25, 2021
 * Description: Auto moves game object
 * Project: 3D Playground - a drag and drop framework for 3d game development derived from Unity's own 2D Playground framework.
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("3D Playground/Movement/Auto Move")]
[RequireComponent(typeof(Rigidbody))]

public class AutoMove : PhysicsObject
{
	[Header("[TIP: if the object doesn't move, try a larger number for the direction]")]
	[Header("Movement")]
	[Header("[The GameObject moves automatically in a specific direction]")]

	// These are the forces that will push the object every frame
	// don't forget they can be negative too!
	[Tooltip("The amount of force in a direction." )]
	public Vector3 direction = new Vector3(1f, 0f, 0f);

	//is the push relative or absolute to the world?
    public bool relativeToRotation = true;

	[Header("Debug")]
	//Debug code
	[Tooltip("When checked will output values to console")]
	public bool debugCode = false; 


	// FixedUpdate is called once per frame
	void FixedUpdate()
	{
		if (relativeToRotation)
		{
			//add relative force * 2
			go_Rigidbody.AddRelativeForce(direction * 2f); 

		}
		else
		{
			//add force *2 
			go_Rigidbody.AddForce(direction * 2f);
		}//end if (relativeToRotation)

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
		Debug.Log(gameObject.name + " AutoMove Transform: " + transform.localPosition);
	}//end DebugCode()

}
