using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public Camera _mainCamera;
    public ColorChanger colorChanging;
    public DataLogger dataLogger;

    void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        dataLogger.time += Time.deltaTime;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(pos: (Vector3)Mouse.current.position.ReadValue()));
        if (!rayHit.collider)
        {
            return;
        }
        else
        {
            dataLogger.Finaltime = dataLogger.time;
            dataLogger.time = 0;
            colorChanging.changeColor(rayHit.collider.gameObject);
            Debug.Log(rayHit.collider.gameObject.name);
        }
    }
}
