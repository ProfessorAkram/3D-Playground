/*****
 * Author: Akram Taghavi-Burris
 * Date Created: May 31, 2021
 * Last Updated: May 31, 2021
 * Description: Checks for a collision then runs a series of actions
 * Project: 3D Playground - a drag and drop framework for 3d game development derived from Unity's own 2D Playground framework.
 ****/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("3D Playground/Conditions/Condition Collision")]
//Requires a collider be set
[RequireComponent(typeof(ObjectCollider))]
public class ConditionCollision : ConditionBase
{
	//refence to object's collider
	Collider objCollider;


	[Header("IF NO COLLIDER IS SET, A DEFULAT BOX COLLIDER IS ADDED")]
	[Header("THIS CONDITION REQUIRES YOU TO SET THE OBJECT COLLIDER")]
	[Space(10)] //space between compenent sections
	public bool didYouSetCollider = false;

	[Header("Destory object on Collsion")]
	public bool destroyOnCollision = true;

	[Header("Debug")]
	//Debug code
	[Tooltip("When checked will output values to console")]
	public bool debugCode = false;

	bool onStart = true; //check if start of scene

	string hitObj; //the object hit

	// Update is called every frame
	void Update()
	{
		//if debugCode is true
		if (debugCode)
		{
			DebugCollider(onStart);
		}
	}

	// This function will be called when something touches the trigger collider
	void OnCollisionEnter(Collision collision)
	{
		hitObj = collision.gameObject.name; //set the object hit
		Debug.Log("trigger: " + this.GetComponent<Collider>().isTrigger);

			//check the tag of the hit object or if we are not filtering by tags
			if (collision.collider.CompareTag(filterTag)
				|| !filterByTag)
			{
				ExecuteAllActions(collision.gameObject); //run actions
	
				
				//if delete on Collison
				if (destroyOnCollision) { 
					this.gameObject.GetComponent<MeshRenderer>().enabled=false; 
				}

		}

		if (debugCode) { Debug.Log(hitObj); } //debug the collider object
	}

	// Reset Action on exit
	void OnCollisionExit(Collision collision)
	{

	}



	//Debug the collider at first updated
	void DebugCollider(bool started)
	{
		if (started)
		{
			objCollider = this.gameObject.GetComponent<Collider>();
			Debug.Log("This object is using a " + objCollider.GetType());
			onStart = false;
		}


	}//end DebugCode()

}


