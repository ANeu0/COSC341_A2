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

        public bool RandomMode = false;


        private InputHandler inputHandler;
        public static IList<GameObject> gameTargets = new List<GameObject>();
        private TargetGenerator TargetGen;
        private static int _activeTarget = 0;

        void Start()
        {
            GameSettings.PopulateModeSettings(RandomMode);
            TargetGen = new TargetGenerator(targetTemplate);
            // Find and assign the InputHandler component (assuming it's on the same GameObject)
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
            if (GameSettings.RandomMode)
            {
                _activeTarget = GetRandomIntExcluding(0, gameTargets.Count, _activeTarget);
            }
            else
            {
                _activeTarget = (_activeTarget + 1) % gameTargets.Count;
            }
            activeTarget = gameTargets[_activeTarget].GetComponent<TargetBehavior>();
            activeTarget.active = true;
        }
        static int GetRandomIntExcluding(int min, int max, int exclude)
        {
            System.Random random = new System.Random();
            int randomInt;
            do
            {
                randomInt = random.Next(min, max);
            } while (randomInt == exclude);
            return randomInt;
        }

    }
}
