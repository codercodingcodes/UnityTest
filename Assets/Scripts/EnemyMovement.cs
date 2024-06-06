using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody trb;
    void Start()
    {
        trb = this.gameObject.GetComponent<Rigidbody>();
        StartCoroutine("IdleWalk");
        
    }
    IEnumerator IdleWalk(){
        while (true){
            yield return new WaitForSeconds(Random.Range(3f,7f));
            this.transform.Rotate(0.0f,Random.Range(0f,360f),0.0f,Space.Self);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        trb.velocity = this.transform.forward;
    }
}
