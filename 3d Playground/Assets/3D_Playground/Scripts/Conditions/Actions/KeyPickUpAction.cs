/*****
 * Author: Akram Taghavi-Burris
 * Date Created: June 6, 2021
 * Last Updated: June 6, 2021
 * Description: Sets a value if the key has been picked up
 * Project: 3D Playground - a drag and drop framework for 3d game development derived from Unity's own 2D Playground framework.
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUpAction : Action
{
    [HideInInspector]
    public bool keyPickedUp = false; //has the key been picked up

    [Header("Debug")]
    //Debug code
    [Tooltip("When checked will output values to console")]
    public bool debugCode = false;

    public override bool ExecuteAction(GameObject other)
    {
        keyPickedUp = true;
        Debug.Log("Key Pickedup:" + keyPickedUp);
        return true;
    }//end ExecuteAction()

    // Update is called once per frame
    void Update()
    {
        //if debugCode is true
        if (debugCode)
        {
            DebugKey();
        }
    }//end Update()

    //Debugs the status of unlocked
    void DebugKey()
    {
        Debug.Log("Pickedup " + this.gameObject.name + " : " + keyPickedUp);
    }//end DebugLock()


}
