using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runGraph : MonoBehaviour
{
   [SerializeField] private GameObject WG;
    private void Awake() {
    }
    void Start(){
                WG.GetComponent<WindowGraph>().runGraphFromButton();

    }

    public void pressButton(){
        
        WG.GetComponent<WindowGraph>().runGraphFromButton();
    }
}
