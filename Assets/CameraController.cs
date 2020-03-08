using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    float moveSpeed = 5.0f;
    float horizontalInput;
    float verticalInput;
    float speed = 10;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    bool moveable = false;
    public bool freeze = false;

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.F))
        {
            moveable = !moveable;
        }
        if(!freeze && moveable)
        {
            Cursor.visible = false;
            yaw += speed * Input.GetAxis("Mouse X");
            pitch -= speed * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        } else {
            Cursor.visible = true;
        }
    }

    void FixedUpdate() 
    {
        if (horizontalInput < 0 && moveable) {
            Vector3 newPosition = new Vector3(horizontalInput, 0, 0) * moveSpeed + transform.position;
            transform.position = transform.position - Camera.main.transform.right * speed * Time.fixedDeltaTime;//Vector3.Lerp(transform.position, newPosition, 0.8f);
        }
        if (horizontalInput > 0 && moveable) {
            Vector3 newPosition = new Vector3(horizontalInput, 0, 0) * moveSpeed + transform.position;
            transform.position = transform.position + Camera.main.transform.right * speed * Time.fixedDeltaTime;//Vector3.Lerp(transform.position, newPosition, 0.8f);
        }
        if (verticalInput < 0 && moveable) {
            Vector3 newPosition = new Vector3(0, 0, verticalInput) * moveSpeed + transform.position;
            transform.position = transform.position - Camera.main.transform.forward * speed * Time.fixedDeltaTime;//Vector3.Lerp(transform.position, newPosition, 0.8f);
        }
        if (verticalInput > 0 && moveable) {
            Vector3 newPosition = new Vector3(0, 0, verticalInput) * moveSpeed + transform.position;
            transform.position = transform.position + Camera.main.transform.forward * speed * Time.fixedDeltaTime;//Vector3.Lerp(transform.position, newPosition, 0.8f);
        }
        
    }

}
