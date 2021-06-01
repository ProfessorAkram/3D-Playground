/*****
 * Author: Akram Taghavi-Burris
 * Date Created: May 31, 2021
 * Last Updated: May 31, 2021
 * Description: Test action to ensure condition is working. Will output message to console.
 * Project: 3D Playground - a drag and drop framework for 3d game development derived from Unity's own 2D Playground framework.
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAction : Action
{

    //ExecuteAction runs the action and must return a true or false.
    public override bool ExecuteAction(GameObject other)
    {
        Debug.Log("Collsision action working");
        return true;
    }
}
