using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    float moveSpeed = 5.0f;
    float horizontalInput = 0;
    float verticalInput = 0;
    float speed = 10;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    bool moveable = false;
    public bool freeze = false;
    int currentCamera;
    GameObject closest;
    Camera[] cams;
    Vector3 move;

    void Start() 
    {
        cams = GameObject.FindObjectsOfType<Camera>();   
        for(int i=0; i < cams.Length; i++)
        {
            if(cams[i] != Camera.main)
            {
                cams[i].enabled = false;    
            } else {
                currentCamera = i;
            }
        }
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        move = new Vector3(horizontalInput, 0, verticalInput);

        if(Input.GetKeyDown(KeyCode.F))
        {
            moveable = !moveable;
        }
        if(Input.GetKeyDown(KeyCode.E))
        {   
            if(currentCamera < cams.Length - 1)
            {
                cams[currentCamera].enabled = false;
                cams[currentCamera + 1].enabled = true;
                currentCamera++;
            } else {
                cams[currentCamera].enabled = false;
                cams[0].enabled = true;
                currentCamera = 0; 
            }
        }
        handleCameraLock();

        if(cams[currentCamera] == Camera.main)
        {
            handleCameraMovement();
        } else {
            closest = FindClosestObject(cams[currentCamera]);
            handleObjectMovement(closest);
            cams[currentCamera].transform.position = closest.transform.position + new Vector3(0, 5, -20); 
        }
    }
    public void freeMove(){
                    moveable = !moveable;


    }

    public void follow(){

        
            if(currentCamera < cams.Length - 1)
            {
                cams[currentCamera].enabled = false;
                cams[currentCamera + 1].enabled = true;
                currentCamera++;
            } else {
                cams[currentCamera].enabled = false;
                cams[0].enabled = true;
                currentCamera = 0; 
            }
        
        if(cams[currentCamera] == Camera.main)
        {
            handleCameraMovement();
        } else {
            closest = FindClosestObject(cams[currentCamera]);
            handleObjectMovement(closest);
            cams[currentCamera].transform.position = closest.transform.position + new Vector3(0, 5, -20); 
        }
    }

    void handleCameraLock()
    {
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

    void handleObjectMovement(GameObject ob)
    {
        ob.transform.Translate(move * 10 * Time.deltaTime, Space.World);
        if(move!=Vector3.zero){
            ob.transform.rotation = Quaternion.Slerp(ob.transform.rotation, Quaternion.LookRotation(move), 0.15F);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            ob.GetComponent<Rigidbody>().AddForce(new Vector3(0, 500, 0));
        }
    }

    void handleCameraMovement()
    {
        if (horizontalInput < 0 && moveable) {
            Vector3 newPosition = new Vector3(horizontalInput, 0, 0) * moveSpeed + transform.position;
            transform.position = transform.position - Camera.main.transform.right * speed * Time.fixedDeltaTime;
        }
        if (horizontalInput > 0 && moveable) {
            Vector3 newPosition = new Vector3(horizontalInput, 0, 0) * moveSpeed + transform.position;
            transform.position = transform.position + Camera.main.transform.right * speed * Time.fixedDeltaTime;
        }
        if (verticalInput < 0 && moveable) {
            Vector3 newPosition = new Vector3(0, 0, verticalInput) * moveSpeed + transform.position;
            transform.position = transform.position - Camera.main.transform.forward * speed * Time.fixedDeltaTime;
        }
        if (verticalInput > 0 && moveable) {
            Vector3 newPosition = new Vector3(0, 0, verticalInput) * moveSpeed + transform.position;
            transform.position = transform.position + Camera.main.transform.forward * speed * Time.fixedDeltaTime;        
        }
    }
    
    GameObject FindClosestObject(Camera cam)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("object");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = cam.transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
