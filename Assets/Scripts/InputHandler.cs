using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;
    private Stopwatch _stopwatch;
    public string Technique;

    private void Awake()
    {
        _stopwatch = gameObject.AddComponent<Stopwatch>();
        _mainCamera = Camera.main;
        CSVHelper.CSVName = Path.Combine(Application.dataPath, "GameData.csv");
        CSVHelper.initCSV(new Data(), filename: CSVHelper.CSVName);
        _stopwatch.StartStopwatch();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            return;
        }

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) { return; }

        Debug.Log(rayHit.collider.gameObject.name);
        Data d = new Data(name: rayHit.collider.gameObject.name,
                          timeTriggered: _stopwatch.GetElapsedTime().ToString(),
                          technique: Technique,
                          width: GetObjectWidth(rayHit.collider.gameObject),
                          amplitude: GetObjectHeight(rayHit.collider.gameObject),
                          correct: (rayHit.collider) ? "True" : "False");

        CSVHelper.WriteObjToCSV(d, CSVHelper.CSVName);
    }

    private string GetObjectWidth(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            return renderer.bounds.size.x.ToString();
        }
        else
        {
            Debug.LogWarning("The GameObject does not have a Renderer component.");
            return 0f.ToString();
        }
    }
    private string GetObjectHeight(GameObject obj)
    {

        Collider2D collider = obj.GetComponent<Collider2D>();
        if (collider != null)
        {
            return collider.bounds.size.y.ToString(); // Height in the y-axis
        }
        else
        {
            Debug.LogWarning("The GameObject does not have a Collider component.");
            return 0f.ToString();
        }
    }
}
