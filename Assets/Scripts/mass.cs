using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class mass : MonoBehaviour
{
    slope slopeScript;
    Rigidbody rb;
    public InputField massInput;
    float massData;
    
    // Start is called before the first frame update
    void Start()
    {
        rb=GameObject.Find("cube").GetComponent<Rigidbody>();
        slopeScript=GetComponent<slope>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeMass(){
        massData = float.Parse(massInput.text.ToString());
        rb.mass=massData;
        

        
    }
}
