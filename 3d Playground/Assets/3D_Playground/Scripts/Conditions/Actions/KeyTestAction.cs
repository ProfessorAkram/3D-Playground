/*****
 * Author: Akram Taghavi-Burris
 * Date Created: June 6, 2021
 * Last Updated: June 6, 2021
 * Description: Check for required Key before interaction
 * Project: 3D Playground - a drag and drop framework for 3d game development derived from Unity's own 2D Playground framework.
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("3D Playground/Actions/KeyTestAction")]
public class KeyTestAction : Action
{
    [Header("Lock Status")]
    public bool unlocked; // unlocked status

    [Header("Required Key")]
    [Tooltip("The object that unlocks this action")]
    public GameObject keyGameObject;
    bool keyPickedUp;

    [Header("Debug")]
    //Debug code
    [Tooltip("When checked will output values to console")]
    public bool debugCode = false;

    // Update is called once per frame
    void Update()
    {
        //get the keyPickedUp value of the required key object
        keyPickedUp = keyGameObject.GetComponent<KeyPickUpAction>().keyPickedUp;

        //If the key is Pickedup 
        if (keyPickedUp)
        {
            Debug.Log("Unlock");
            unlocked = true;
        }

        //if debugCode is true
        if (debugCode)
        {
            DebugLock();
        }
    }//end Update()

    //ExecuteAction runs the action and must return a true or false.
    public override bool ExecuteAction(GameObject other)
    {

        if (unlocked)
        {
            Debug.Log("Unlocked");
            return true; //if true run next action in sequece
        }
        else
        {
            Debug.Log("Not Unlocked");
            return false; //if false stop all actions following this action

        }

    }//end ExecuteAction()

    //Debugs the status of unlocked
    void DebugLock()
    {
        Debug.Log(this.gameObject.name + "Unlocked = " + unlocked);
    }//end DebugLock()



}
