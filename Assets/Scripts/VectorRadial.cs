using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class VectorRadial : MonoBehaviour
{
    public Transform objTrans;

    [Range(0f, 5f)]
    public float radius = 1f;

#if UNITY_EDITOR
    void freyaCode()
    {
        // The code below shows whether an object is within the circumference of a circle or not
        // using the distance between the trigger origin and the object
        // it then checks if the distance is less that the radius
        Vector2 objPos = objTrans.position;
        Vector2 origin = transform.position;

        // float dist = Vector2.Distance(origin, objPos);   // This should not be used for optimization sake, since sqrt has an expensive processing time...
                                                            // do the following instead:
        Vector2 disp = objPos - origin;

        float distSqrd = disp.sqrMagnitude;     // Instead of using the manual version I did below, Unity has sqrMagnitude which means the same thing
                                                //float distSqrd = disp.x * disp.x + disp.y * disp.y; 
                                                // Instead of magninute/ distance we find the distance_Squared and we compare it with radius_Squared
                                                // If you actually need the distance, use need to do the square root

        bool isInside = distSqrd < (radius * radius);   // in many cases, doing the square manually is faster than using | Mathf.Pow(radius, 2); |

        Handles.color = isInside ? Color.green : Color.red;

        Handles.DrawWireDisc(origin, Vector3.forward, radius);
    }
#endif
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        // My code - just the same
        Vector2 objPos = objTrans.position;
        Vector2 origin = transform.position;

        Vector2 disp = objPos - origin;
        float distSq = disp.sqrMagnitude;

        bool isInside = distSq < radius * radius;

        Handles.color = isInside ? Color.green : Color.red;

        Handles.DrawWireDisc(origin, new Vector3(0, 0, 1), radius);

    }
#endif
}
