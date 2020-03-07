using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public GameObject gravityArrow;
    public GameObject myObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gravityArrow.transform.position = myObject.transform.position;
        gravityArrow.transform.rotation = Quaternion.Euler(0,0,0);
        
    }
}
