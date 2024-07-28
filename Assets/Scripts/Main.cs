using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private InputHandler inputHandler;
    public string tagToSearch = "Targets";
    private GameObject[] gameObjectsWithTag;

    void Start()
    {
        // Find and assign the InputHandler component (assuming it's on the same GameObject)
        inputHandler = GetComponent<InputHandler>();

        gameObjectsWithTag = GameObject.FindGameObjectsWithTag(tagToSearch);

        if (inputHandler == null)
        {
            Debug.LogError("InputHandler component not found on the GameObject.");
            return;
        }


    }

    private void HandleJump()
    {

    }

}
