using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LineOfSight : MonoBehaviour
{
    public float vRadius;
    [Range(0,360)]
    public float vAngle;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    [HideInInspector]
    public List<Transform> targets = new List<Transform>();
    public bool showLine;
    
    void FindVisibleTargets(){
        targets.Clear();
        Collider[] targetsInViewRadius= Physics.OverlapSphere(transform.position, vRadius,targetMask);

        for(int i=0; i<targetsInViewRadius.Length;i++){
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position-transform.position).normalized;
            if (Vector3.Angle(transform.forward,dirToTarget)<vAngle/2){
                float dstToTarget = Vector3.Distance(transform.position,target.position);
                if (!Physics.Raycast(transform.position,dirToTarget,dstToTarget,obstacleMask)){
                    targets.Add(target);
                }
            }
        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FindTargets",.2f);
    }
    IEnumerator FindTargets(float delay){
        while (true){
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }
    public Vector3 DirFromAngle(float ang,bool isG){
        if (!isG){
            ang += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(ang*Mathf.Deg2Rad),0,Mathf.Cos(ang*Mathf.Deg2Rad));
    }
}
