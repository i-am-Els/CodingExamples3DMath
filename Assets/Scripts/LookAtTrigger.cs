using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class LookAtTrigger : MonoBehaviour
{
    public Transform target;
    public float dotProduct;

    [Range(0f, 1f)]
    public float threshold;
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Vector2 targetPos = target.position;
        Vector2 seekerPos = transform.position;
/*
        Vector2 sTotPos = targetPos - seekerPos;
        Vector2 sTotUnit = sTotPos.normalized;
*/

        float diff = Vector2.Dot(seekerPos.normalized, targetPos.normalized);
        dotProduct = diff;


        bool isLookingAway = diff < 0;

        Gizmos.color = isLookingAway ? Color.red : Color.green;

        Gizmos.DrawLine(Vector2.zero, seekerPos);
        Gizmos.DrawLine(Vector2.zero, targetPos);

    }
#endif
}
