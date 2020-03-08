using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MomentumScript : MonoBehaviour
{
    public InputField velocityInput1;
    Rigidbody rb1;
    float myVelocity1;
    Vector3 newVelocity1;
    Vector3 initialPosition1;
    GameObject Ob1;

    public InputField velocityInput2;
    Rigidbody rb2;
    float myVelocity2;
    Vector3 newVelocity2;
    Vector3 initialPosition2;
    Quaternion initialRotation1;
    Quaternion initialRotation2;
    GameObject Ob2;

    public InputField massInput1;
    float mass1;

    public InputField massInput2;
    float mass2;

    // Start is called before the first frame update
    void Start()
    {
        Ob1 =GameObject.Find("Cube1");
        initialPosition1 = Ob1.transform.position;
        initialRotation1 = Ob1.transform.rotation;
        rb1=Ob1.GetComponent<Rigidbody>();
        myVelocity1 = 20;
        newVelocity1 = new Vector3(myVelocity1,0,0);
        rb1.velocity =newVelocity1;
        mass1=1;
        rb1.mass=mass1;

        Ob2 =GameObject.Find("Cube2");
        initialPosition2 = Ob2.transform.position;
        initialRotation2 = Ob2.transform.rotation;
        rb2=Ob2.GetComponent<Rigidbody>();
        myVelocity2 = 20;
        newVelocity2 = new Vector3(-myVelocity2,0,0);
        rb2.velocity =newVelocity2;
        mass1=1;
        rb1.mass=mass1;


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setVelocity1(){
            myVelocity1 = float.Parse(velocityInput1.text.ToString());
        newVelocity1 = new Vector3(myVelocity1,0,0);


    }
        public void setVelocity2(){
            myVelocity2 = float.Parse(velocityInput2.text.ToString());
        newVelocity2 = new Vector3(myVelocity2,0,0);
        }
    public void setMass1(){
        mass1 = float.Parse(massInput1.text.ToString());
    }
    public void setMass2(){
        mass2 = float.Parse(massInput2.text.ToString());
    }
    public void resetObject(){
        Ob1.transform.position=initialPosition1;
        Ob1.transform.rotation=initialRotation1;
        rb1.velocity=newVelocity1;
        rb1.mass=mass1;

        Ob2.transform.position=initialPosition2;
        Ob2.transform.rotation=initialRotation2;
        rb2.velocity=newVelocity2;
        rb2.mass=mass2;




    }
}
