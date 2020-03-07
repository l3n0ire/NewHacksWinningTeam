using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    private float moveSpeed = 1.0f;
    private float scrollSpeed = 10.0f;
    float horizontalInput;
    float verticalInput;
    float scrollInput;
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        scrollInput = Input.GetAxis("Mouse ScrollWheel");
    }

    void FixedUpdate() 
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || verticalInput != 0) {
            transform.position += moveSpeed * new Vector3(horizontalInput, 0, verticalInput);
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0) {
            transform.position += scrollSpeed * new Vector3(0, -scrollInput, 0);
        }
    }

}
