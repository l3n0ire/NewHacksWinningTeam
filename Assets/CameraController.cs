using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    float moveSpeed = 10.0f;
    float scrollSpeed = 10.0f;
    float horizontalInput;
    float verticalInput;
    float scrollInput;
    float mouseX;
    float mouseY;
    float speed = 10;
    public bool freeze = false;

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        scrollInput = Input.GetAxis("Mouse ScrollWheel");
        mouseX = (Input.mousePosition.x / Screen.width ) - 0.5f;
        mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;
        if(!freeze)
        {
            transform.localRotation = Quaternion.Euler (new Vector4 (-1f * (mouseY * 180f), mouseX * 360f, transform.localRotation.z));
        }
    }

    void FixedUpdate() 
    {
        if (horizontalInput < 0) {
            Vector3 newPosition = new Vector3(horizontalInput, 0, 0) * moveSpeed + transform.position;
            transform.position = transform.position - Camera.main.transform.right * speed * Time.fixedDeltaTime;//Vector3.Lerp(transform.position, newPosition, 0.8f);
        }
        if (horizontalInput > 0) {
            Vector3 newPosition = new Vector3(horizontalInput, 0, 0) * moveSpeed + transform.position;
            transform.position = transform.position + Camera.main.transform.right * speed * Time.fixedDeltaTime;//Vector3.Lerp(transform.position, newPosition, 0.8f);
        }
        if (verticalInput < 0) {
            Vector3 newPosition = new Vector3(0, 0, verticalInput) * moveSpeed + transform.position;
            transform.position = transform.position - Camera.main.transform.forward * speed * Time.fixedDeltaTime;//Vector3.Lerp(transform.position, newPosition, 0.8f);
        }
        if (verticalInput > 0) {
            Vector3 newPosition = new Vector3(0, 0, verticalInput) * moveSpeed + transform.position;
            transform.position = transform.position + Camera.main.transform.forward * speed * Time.fixedDeltaTime;//Vector3.Lerp(transform.position, newPosition, 0.8f);
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0) {
            Vector3 newPosition1 = new Vector3(0, -scrollInput, 0) * scrollSpeed + transform.position;
            transform.position = Vector3.Lerp(transform.position, newPosition1, 0.8f);
        }
        
    }

}
