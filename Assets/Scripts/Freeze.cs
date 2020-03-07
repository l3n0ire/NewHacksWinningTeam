using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject[] obs;

    void Start()
    {
        obs = GameObject.FindGameObjectsWithTag("object");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {  
            foreach (GameObject ob in obs) 
            {
                ob.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }
}
