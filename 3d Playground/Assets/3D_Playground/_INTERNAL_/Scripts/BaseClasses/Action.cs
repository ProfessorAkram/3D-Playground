/*****
 * Author: Akram Taghavi-Burris
 * Date Created: May 31, 2021
 * Last Updated: May 31, 2021
 * Description: All component that are actions inherit from this class
 * Project: 3D Playground - a drag and drop framework for 3d game development derived from Unity's own 2D Playground framework.
 ****/

using UnityEngine;
using System.Collections;
using System;

public abstract class Action : MonoBehaviour
{
	public virtual bool ExecuteAction(GameObject other)
	{
		//the return value indicates if the action has been successful
		//some actions always return true
		return true;
	}
}
