/*****
 * Author: Akram Taghavi-Burris
 * Date Created: May 26, 2021
 * Last Updated: May 26, 2021
 * Description: All component that require physics inherit from this class, for easy access to the Rigidbody component
 * Project: 3D Playground - a drag and drop framework for 3d game development derived from Unity's own 2D Playground framework.
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

//Abstract class: is a restricted class that cannot be used to create objects (to access it, it must be inherited from another class)
public abstract class PhysicsObject : MonoBehaviour
{
    [HideInInspector]
    //reference to the rigidbody component
    public Rigidbody go_Rigidbody;

    protected virtual void Awake()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        go_Rigidbody = GetComponent<Rigidbody>();

        //Freeze all rotation
        go_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

}
