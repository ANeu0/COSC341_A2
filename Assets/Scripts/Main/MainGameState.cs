using Assets.Scripts.Main;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class MainGameState : MonoBehaviour
    {
        // Target gen Params 
        public GameObject targetTemplate;
        public int numberOfObjects = 10;  // Number of objects to spawn
        public float radius = 5f;         // Radius of the circle
        public float targetSize = 0f;
        public Vector2 center = Vector2.zero;

        private InputHandler inputHandler;
        public static IList<GameObject> gameTargets = new List<GameObject>();
        private TargetGenerator TargetGen;
        private static int _activeTarget = 0;

        void Start()
        {
            TargetGen = new TargetGenerator(targetTemplate);
            // Find and assign the InputHandler component (assuming it's on the same GameObject)
            Debug.Log($"{targetTemplate}, {numberOfObjects}, {radius}, {center}");
            Debug.Log(TargetGen);
            gameTargets = TargetGen.SpawnObjInCircle(numberOfObjects, radius, center, new Vector2(targetSize, targetSize));


            var activeTarget = gameTargets[_activeTarget].GetComponent<TargetBehavior>();
            activeTarget.active = true;
        }

        public static void moveActiveTarget()
        {
            // set the current active to false
            var activeTarget = gameTargets[_activeTarget].GetComponent<TargetBehavior>();
            activeTarget.active = false;
            // move the target over 1
            _activeTarget = (_activeTarget + 1) % gameTargets.Count;
            Debug.Log(_activeTarget);
            activeTarget = gameTargets[_activeTarget].GetComponent<TargetBehavior>();
            activeTarget.active = true;
        }

    }
}
