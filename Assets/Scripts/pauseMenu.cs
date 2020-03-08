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
            if(!isVisible)
            {
                Time.timeScale = 0;
                isVisible = !isVisible;
                panel.SetActive(isVisible);
                cam.GetComponent<CameraController>().freeze = true;
            } else {
                closeMenu();
            }
            
        }
    }

    public void closeMenu()
    {
        Time.timeScale = 1;
        isVisible=!isVisible;
        panel.SetActive(isVisible);
        cam.GetComponent<CameraController>().freeze = false;
    }
}
