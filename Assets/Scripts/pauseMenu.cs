using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public bool isVisible =false;
    public GameObject panel;
    bool paused = false;
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(isVisible);
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
                isVisible = !isVisible;
                cam.GetComponent<CameraController>().freeze = true;
                panel.SetActive(isVisible);
            } else {
<<<<<<< HEAD
                
=======
>>>>>>> 98c8691fe1a91e1eb4a3a8fa2a083319232e7296
                closeMenu();
            }
            
        }
    }

    public void closeMenu(){
        Time.timeScale = 1;
        isVisible=!isVisible;
        panel.SetActive(isVisible);
        Time.timeScale = 1;
        cam.GetComponent<CameraController>().freeze = false;

    }
}
