using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class normal : MonoBehaviour
{
    public GameObject myObject;
    public GameObject myArrow;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()

    {
        var rotation = myObject.transform.eulerAngles;
        myArrow.transform.rotation=Quaternion.Euler(rotation.x,rotation.y,rotation.z+180);

        
    }

    void OnCollisionEnter(Collision collsion) {

        myObject = collsion.gameObject;


        
    }
}
