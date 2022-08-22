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
    public float threshold = .5f;
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Vector2 targetPos = target.position;
        Vector2 seekerPos = transform.position;

        Vector2 seekerDir = transform.right; // The x axis of the seeker object, with this object, we can tell if the seeker is facing the target or not...

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(seekerPos, seekerPos + seekerDir); // Draw line from seekers position to the direction the seeker is facing, we use the x axis in this case

        Vector2 targetDir = (targetPos - seekerPos).normalized; // We find the direction vector/resultant between the seeker and his target

        Gizmos.color = Color.white;
        float diff = Vector2.Dot(seekerDir.normalized, targetDir); // We find the similarities between the seeker and target directions...
        dotProduct = diff; // To display Dot product in editor

        bool isLookingAt = diff >= threshold; // we determine if the target is in the seekers view based on a threshold.

        Gizmos.color = isLookingAt ? Color.green : Color.red; // We change line color based on whether the seeker is looking at the target or not.

        Gizmos.DrawLine(seekerPos, seekerPos + targetDir); // We draw the line pointing to the target from the seeker position with the color...
                                                           // that tells when and when not the seeker can see the target based on the threshold
    }
#endif
}
