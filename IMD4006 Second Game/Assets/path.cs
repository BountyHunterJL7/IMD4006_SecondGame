using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path : MonoBehaviour
{
    public Color pathColor;

    private List<Transform> points = new List<Transform>();

    void OnDrawGizmosSelected() {
        Gizmos.color = pathColor;

        Transform[] pathTransform = GetComponentsInChildren<Transform>();
        points = new List<Transform>();

        for (int i = 0; i < pathTransform.Length; i ++){
            if (pathTransform[i] != transform) {
                points.Add(pathTransform[i]);
            }
        }

        for (int i = 0; i <points.Count; i++){
            Vector3 currentPoint = points[i].position;
            Vector3 previousPoint = Vector3.zero;
            if (i>0){
                previousPoint = points[i-1].position;
            }
            else if (i == 0 && points.Count > 1){
                previousPoint = points[points.Count - 1].position;
            }

            Gizmos.DrawLine(previousPoint, currentPoint);
            Gizmos.DrawWireSphere(currentPoint, 0.8f);
        }
    }

}
