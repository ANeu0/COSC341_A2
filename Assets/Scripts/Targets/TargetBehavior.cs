using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TargetBehavior : MonoBehaviour
{
    public string tagToSearch = "Targets"; // Set this in the Inspector to the tag you want to search for
    private GameObject[] gameObjectsWithTag;


    public GameObject targetObject; // Assign the target GameObject
    public Color restColor = Color.white; // Choose the new color
    public Color activeColor = Color.red; // Choose the new color
    public bool active = false;

    private void Update()
    {
        Renderer renderer = targetObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = (active) ? activeColor : restColor;
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        Debug.Log("clicked");
    }
}
