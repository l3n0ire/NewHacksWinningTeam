using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    GameObject myObject;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        myObject=GameObject.Find("Sphere");
        velocity = new Vector3(10,10,0);
        myObject.GetComponent<Rigidbody>().velocity=velocity;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void launch(){

    }
}
