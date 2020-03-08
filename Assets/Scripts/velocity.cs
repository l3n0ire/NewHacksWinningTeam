using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class velocity : MonoBehaviour
{
    public InputField velocityInput;
    Rigidbody rb;

    float myVelocity;
    Vector3 newVelocity;
    Vector3 initialPosition;
    GameObject Ob;
    // Start is called before the first frame update
    void Start()
    {
        Ob =GameObject.Find("Sphere");
        initialPosition = Ob.transform.position;
        rb=Ob.GetComponent<Rigidbody>();
        myVelocity = 10;
        newVelocity = new Vector3(myVelocity,myVelocity,0);
        rb.velocity =newVelocity;


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setVelocity(){
        myVelocity = float.Parse(velocityInput.text.ToString());
        newVelocity = new Vector3(myVelocity,myVelocity,0);


    }
    public void resetObject(){
        Ob.transform.position=initialPosition;
        rb.velocity=newVelocity;


    }
}
