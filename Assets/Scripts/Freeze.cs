using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ob;
    public CameraController cc;
    bool paused = false; 

    void Start()
    {
        ob = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {  
            paused = !paused;

            if(paused) 
            {
                Time.timeScale = 0;
            } else {
                Time.timeScale = 1;
            }
            
        }
    }
}
