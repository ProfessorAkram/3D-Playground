/*****
 * Author: Akram Taghavi-Burris
 * Date Created: May 24, 2021
 * Last Updated: May 24, 2021
 * Description: Auto moves game object
 * Project: 3D Playground - a drag and drop framework for 3d game development derived from Unity's own 2D Playground framework.
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("3D Playground/Movement/Auto Move")]
[RequireComponent(typeof(Rigidbody))]

public class AutoMove : MonoBehaviour
{
    // These are the forces that will push the object every frame
    // don't forget they can be negative too!
    public Vector3 direction = new Vector3(1f, 0f, 0f);

    //is the push relative or absolute to the world?
    public bool relativeToRotation = true;

	//reference to the rigidbody component
	Rigidbody go_Rigidbody; 

	//on scene start
	void Start()
	{
		//Fetch the Rigidbody from the GameObject with this script attached
		go_Rigidbody = GetComponent<Rigidbody>();
	}//end Start()

	// FixedUpdate is called once per frame
	void FixedUpdate()
	{
		if (relativeToRotation)
		{
			go_Rigidbody.AddRelativeForce(direction * 2f);

		}
		else
		{
			go_Rigidbody.AddForce(direction * 2f);
		}//end if (relativeToRotation)
	}//end FixedUpdate()
}
