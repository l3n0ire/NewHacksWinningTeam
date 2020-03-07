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
            if(!paused)
            {
                Time.timeScale = 0;
                isVisible = !isVisible;
                cam.GetComponent<CameraController>().freeze = true;
                panel.SetActive(isVisible);
                paused = !paused;
            } else {
                closeMenu();
            }
            
        }
    }

    public void closeMenu(){
        isVisible=!isVisible;
        paused = !paused;
        panel.SetActive(isVisible);
        Time.timeScale = 1;
        cam.GetComponent<CameraController>().freeze = false;

    }
}
