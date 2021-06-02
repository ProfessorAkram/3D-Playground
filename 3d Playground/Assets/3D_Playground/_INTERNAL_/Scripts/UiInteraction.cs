/*****
 * Author: Akram Taghavi-Burris
 * Date Created: June 1, 2021
 * Last Updated: June 1, 2021
 * Description: Setsup the UI interactions with the new input system
 * Project: 3D Playground - a drag and drop framework for 3d game development derived from Unity's own 2D Playground framework.
 ****/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UiInteraction : MonoBehaviour
{
    //reference to dialogue group
    public GameObject ui_canvas;
    public GameObject current_canvas;
    public GameObject previous_canvas;

    //ui element clicked on
    public GameObject ui_element;

    GraphicRaycaster ui_raycaster;

    PointerEventData click_data;
    List<RaycastResult> click_results;

    // Start is called before the first frame update
    void Start()
    {
        ui_raycaster = ui_canvas.GetComponent<GraphicRaycaster>();
        click_data = new PointerEventData(EventSystem.current);
        click_results = new List<RaycastResult>();
        setUICanvas(ui_canvas);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            GetUiElementClicked();
        }
    }


   public void setUICanvas(GameObject goCanvas)
    {
        if (ui_canvas)
        {
            previous_canvas = ui_canvas;
            ui_canvas = goCanvas;
            current_canvas = ui_canvas;
        }
        else
        {
            ui_canvas = goCanvas;
        }
    }

    void GetUiElementClicked()
    {
        click_data.position = Mouse.current.position.ReadValue();
        click_results.Clear();
        ui_raycaster.Raycast(click_data, click_results);

        foreach(RaycastResult result in click_results)
        {
            ui_element = result.gameObject;
            Debug.Log(ui_element.name);
        }
    }


}
