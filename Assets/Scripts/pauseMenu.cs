using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public bool isVisible =false;
    public GameObject panel;
    //public GameObject mainMenu;
    //public GameObject resume;

    // Start is called before the first frame update
    void Start()
    {
                panel.SetActive(isVisible);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeMenu(){
        isVisible=!isVisible;
        panel.SetActive(isVisible);

    }
}
