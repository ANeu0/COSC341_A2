using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Stopwatch : MonoBehaviour
    {
        private bool isRunning = false;
        private float elapsedTime = 0f;

        void Update()
        {
            if (isRunning)
            {
                elapsedTime += Time.deltaTime;
            }
        }

        public void StartStopwatch()
        {
            isRunning = true;
        }

        public void StopStopwatch()
        {
            isRunning = false;
        }

        public void ResetStopwatch()
        {
            isRunning = false;
            elapsedTime = 0f;
        }

        public float GetElapsedTime()
        {
            return elapsedTime;
        }
    }


}
