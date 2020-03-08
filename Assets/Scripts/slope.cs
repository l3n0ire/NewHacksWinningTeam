using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class slope : MonoBehaviour
{
    float angle;
    public InputField angleInput;
    Transform pivot;
    GameObject myObject;
    Transform slopeObject;
    

    // Start is called before the first frame update
    void Start()
    {
        pivot =GameObject.Find("pivot").GetComponent<Transform>();
        myObject =GameObject.Find("cube");
        slopeObject = GameObject.Find("slope").GetComponent<Transform>();

        angle=40;

        

        
    }

    // Update is called once per frame
    void Update()
    {    
        
    }
    public void setSlope(){
        angle=float.Parse(angleInput.text.ToString());
        pivot.rotation = Quaternion.Euler(0,0,-angle);
        myObject.transform.position=slopeObject.position+ new Vector3(1.5f,1.5f,1.5f);
        myObject.transform.rotation = Quaternion.Euler(0,0,-angle);
        
    }
    public void resetObject() {
        myObject.transform.rotation = Quaternion.Euler(0,0,-angle);
        myObject.transform.position=slopeObject.position+ new Vector3(1.4f,1.4f,1.4f);
        myObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        
    }
}
