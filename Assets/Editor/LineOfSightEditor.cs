using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LineOfSight))]
public class LineOfSightEditor : Editor
{
    void OnSceneGUI(){ 
        LineOfSight los = (LineOfSight)target;
        if (los.showLine){
            Handles.color = Color.white;
            Handles.DrawWireArc(los.transform.position,Vector3.up,Vector3.forward,360,los.vRadius);
            Vector3 vAngleA = los.DirFromAngle (-los.vAngle / 2, false);
            Vector3 vAngleB = los.DirFromAngle (los.vAngle/2,false);
            Handles.DrawLine(los.transform.position,los.transform.position + vAngleA*los.vRadius);
            Handles.DrawLine(los.transform.position,los.transform.position + vAngleB*los.vRadius);
            Handles.color = Color.red;
            foreach(Transform t in los.targets){
                Handles.DrawLine(los.transform.position,t.position);
            }
        }

    }
}
