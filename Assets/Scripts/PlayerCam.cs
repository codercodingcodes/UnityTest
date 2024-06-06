using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public Transform parentPos;
    public float sens;
    public float x; 
    public float y;
    bool crouch;
    bool sprint;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X")*Time.deltaTime*sens;
        float mouseY = Input.GetAxisRaw("Mouse Y")*Time.deltaTime*sens;
        crouch = Input.GetKey("left ctrl");
        sprint = Input.GetKey("left shift");
        if (crouch){
            this.transform.position = new Vector3(parentPos.position.x,parentPos.position.y-0.5f,parentPos.position.z);
        }else if (sprint){
            transform.position = parentPos.position;
            cam.fieldOfView = 90;
        }else{
            transform.position = parentPos.position; 
            cam.fieldOfView = 60;
        }
        x -= mouseY;
        x = Mathf.Clamp(x,-90f,90f);
        y += mouseX;
        transform.rotation = Quaternion.Euler(x,y,0);
        parentPos.rotation = Quaternion.Euler(0,y,0);
    }
    void FixedUpdate()
    {
        

    }
}
