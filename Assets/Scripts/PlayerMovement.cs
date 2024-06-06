using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float xInput;
    float zInput;
    float drag;
    public float speed;
    public LayerMask ground;
    bool onGround;
    bool jump;
    float maxSpeed;
    public float mSpeed;
    public int height;
    Rigidbody rb;
    Rigidbody trb;
    bool crouch;  
    bool sprint;
    float crouchSpeed;
    float sprintSpeed;
    
    Vector3 inputDirection;

    // Start is called before the first frame update
    void Start()
    {
        trb = this.gameObject.GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        drag = 5f;
        maxSpeed = mSpeed;
        crouchSpeed = mSpeed /2f; 
        sprintSpeed = mSpeed * 2f;
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics.Raycast(transform.position,Vector3.down,height*0.5f +0.2f, ground);
        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");
        jump = Input.GetKey(KeyCode.Space);
        crouch = Input.GetKey("left ctrl");
        sprint = Input.GetKey("left shift");
        if (onGround){
            rb.drag = drag;
        }
        if (crouch){
            maxSpeed = crouchSpeed;
        }else if (sprint){
            maxSpeed = sprintSpeed;
        }else{maxSpeed = mSpeed;}
        
    }
    
    private void FixedUpdate() {
        inputDirection = transform.forward*zInput+transform.right*xInput;
        rb.AddForce(inputDirection.normalized*speed*5f,ForceMode.Force);
        
        Vector2 horizontalMovement = new Vector2(rb.velocity.x, rb.velocity.z);
        if (horizontalMovement.magnitude > maxSpeed){
            horizontalMovement = horizontalMovement.normalized;
            horizontalMovement = horizontalMovement*maxSpeed;
        }
        trb.velocity = new Vector3(horizontalMovement.x,trb.velocity.y,horizontalMovement.y);
    }
}
