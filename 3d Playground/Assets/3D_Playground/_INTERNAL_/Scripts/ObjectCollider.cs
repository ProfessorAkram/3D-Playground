/*****
 * Author: Akram Taghavi-Burris
 * Date Created: May 31, 2021
 * Last Updated: May 31, 2021
 * Description: Sets the Collider type of an object
 * Project: 3D Playground - a drag and drop framework for 3d game development derived from Unity's own 2D Playground framework.
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollider : MonoBehaviour
{
    [Header("Collision Collider")]
    [Tooltip("Use current collider if exsists or default box collider")]
    public bool useCurrentCollider = false;  

    [Tooltip("Type either: box, sphere, capsule, mesh")]
    public string typeOfCollider;

    [HideInInspector]
    public Collider objCollider;


    bool setCollider = false; //sets the current collider

    //Awake loads before scene start
    protected void Awake()
    {
        //Check if the gameobject has a collider
        if (this.gameObject.GetComponent<Collider>() != null)
        { //set a default box collider
           objCollider = this.gameObject.GetComponent<Collider>();
        }

        //if we want to use the default collider but there is no collider, set it to a box collider
        if (useCurrentCollider && objCollider==null)
        {
            this.gameObject.AddComponent<BoxCollider>();
            objCollider = this.gameObject.GetComponent<Collider>();
        }

        //if we do not want to use the defulat collider 
        if(!useCurrentCollider)
        {
            Destroy(objCollider); //destroy the current collider
            AddCollider();//add the new collider
        }

    }//end Awake;

    void AddCollider()
    {
        //set string to lowercase
        typeOfCollider.ToLower();

        //apply collider
        switch (typeOfCollider)
        {
            case "box":
                this.gameObject.AddComponent<BoxCollider>();
                break;
            case "sphere":
                this.gameObject.AddComponent<SphereCollider>();
                break;
            case "capsule":
                this.gameObject.AddComponent<CapsuleCollider>();
                break;
            case "mesh":
                this.gameObject.AddComponent<MeshCollider>();
                break;
            default:
                this.gameObject.AddComponent<BoxCollider>();
                break;
        }//end switch

    }//end AddCollider

}
