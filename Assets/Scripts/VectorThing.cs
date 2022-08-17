using UnityEngine;

public class VectorThing : MonoBehaviour
{
    public Transform aTf;
    public Transform bTf;

    public float abDist;
    
    void OnDrawGizmos()
    {
        Vector2 a = aTf.position;
        Vector2 b = bTf.position;

        abDist = Vector2.Distance(a, b);



        Vector2 aToB = b - a;
        Vector2 aToBDir = aToB.normalized;
        Gizmos.DrawLine(a, a + aToBDir);    // Only for visualizing, Gizmos.DrawLine(Vector2.zero, aToBDir); should do...
                                            // What we have here is the same as Gizmos.DrawLine(Vector2.zero + a, a + aToBDir); // Change origin to a, then to draw the normalized vector correctly, we need to add a to it's endpoint too.

        // Vector2 point = transform.position;

        /* "My own Normalize function"
        float magSq = (point.x * point.x) + (point.y * point.y);
        float mag = Mathf.Sqrt(magSq);  // Magnitude of the vector
                                        // Magnitude could be done using 
                                        // float mag = point.magnitude; 
                                        // This way we need not to calculate magSq

        Vector2 ptNormalized = new((float)point.x / mag, (float)point.y / mag);

        Vector2 dirToPoint = ptNormalized;
        */

        // Vector2 dirToPoint = point.normalized;
        // Gizmos.DrawLine(Vector2.zero, dirToPoint);


        // to find distance between two vectors, we can say:
        // float distance = Vector2.Distance(a, b); // or
        // float distance = (a - b).magnitude;
        // a and b are Vectors

    }
}
