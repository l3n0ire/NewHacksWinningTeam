using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class slope : MonoBehaviour
{
    int angle;
    public InputField angleInput;
    Transform pivot;
    Transform myObject;
    Transform slopeObject;
    

    // Start is called before the first frame update
    void Start()
    {
        pivot =GameObject.Find("pivot").GetComponent<Transform>();
        myObject =GameObject.Find("cube").GetComponent<Transform>();

        

        
    }

    // Update is called once per frame
    void Update()
    {    
        
    }
    public void setSlope(){
        angle=Int32.Parse(angleInput.text.ToString());
        pivot.rotation = Quaternion.Euler(0,0,-angle);
        slopeObject = GameObject.Find("slope").GetComponent<Transform>();
        myObject.position=slopeObject.position+ new Vector3(1,1,1);
        myObject.rotation = Quaternion.Euler(0,0,-angle);
        
    }
}
