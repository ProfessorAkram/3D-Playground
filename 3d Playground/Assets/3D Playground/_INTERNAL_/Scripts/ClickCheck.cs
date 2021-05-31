/*****
 * Author: Akram Taghavi-Burris
 * Date Created: May 31, 2021
 * Last Updated: May 31, 2021
 * Description: Checks object being clicked
 * Project: 3D Playground - a drag and drop framework for 3d game development derived from Unity's own 2D Playground framework.
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClickCheck: MonoBehaviour
{

    //Instance of PlayerInput (script)
    PlayerInput input;

    //main camear in scene used to check raycasts
    Camera mainCamera;

    [HideInInspector]
    public string clickedObj;


    //Awake loads before scene start
    protected void Awake()
    {

        //create new instace of playerInput 
        input = new PlayerInput();

    }//end Awake()


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        input.Mouse.LeftClick.started += _ => StartClick();
        input.Mouse.LeftClick.performed += _ => EndClick();
        
    }

    void StartClick()
    {

    }

    void EndClick()
    {
        DetectObject();
    }

    //Detect objects being clicked
    void DetectObject()
    {
        //ray to camera
        Ray ray = mainCamera.ScreenPointToRay(input.Mouse.Position.ReadValue<Vector2>());

        //hit object
        RaycastHit hit;

        ///3D Raycast check
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider != null)
            {
                clickedObj = hit.transform.name;
                Debug.Log(clickedObj);
            }
        }

        //2D Raycast Check
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
        if (hit2D.collider != null)
        {
            Debug.Log("2D Hit");
        }


    }//end DetectObject

    //when game object is Enabled
    private void OnEnable()
    {
        //enable the playerInput actions
        input.Mouse.Enable();

    }//ednd OnEnable()

    //when game object is Disabled
    private void OnDisable()
    {
        //disable the playerInput actions
        input.Mouse.Disable();

    }//ednd OnEnable()

    // Update is called once per frame
    void Update()
    {
        
    }
}
