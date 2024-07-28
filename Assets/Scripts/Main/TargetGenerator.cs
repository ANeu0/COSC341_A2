using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class TargetGenerator
    {
        GameObject objectToSpawn;
        public TargetGenerator(GameObject ObjectToSpawn)
        {
            objectToSpawn = ObjectToSpawn;
        }
        public IList<GameObject> SpawnObjInCircle(int numberOfTargets, float radius, Vector2 center, Vector2 size)
        {
            IList<GameObject> result = new List<GameObject>();
            float angleStep = 360f / numberOfTargets;
            float angle = 0f;

            for (int i = 0; i < numberOfTargets; i++)
            {
                float objectPosX = center.x + Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
                float objectPosY = center.y + Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

                Vector2 objectPos = new Vector2(objectPosX, objectPosY);

                // Instantiate a new clone of the object
                GameObject newObject = UnityEngine.Object.Instantiate(objectToSpawn, objectPos, Quaternion.identity);

                // Optional: Customize the newly instantiated object
                newObject.name = "Target_" + angle; // Rename the clone
                //newObject.transform.parent = transform; // Set the parent to the current object
                newObject.transform.localScale = size;
                newObject.SetActive(true);
                result.Add(newObject);
                angle += angleStep;
            }
            return result;
        }
    }
}
