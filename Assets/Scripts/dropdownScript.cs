using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dropdownScript : MonoBehaviour
{
    public Dropdown dropdown;
    public string material;
    public PhysicMaterial[] physicMaterials;
    public Material[] materials;
    Collider myObject;
    Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        myObject =GameObject.Find("cube").GetComponent<Collider>();
        rend =GameObject.Find("slope").GetComponent<Renderer>();

        material = dropdown.options[0].text;
        myObject.material = physicMaterials[0];
        rend.sharedMaterial = materials[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeMaterial(){
        material = dropdown.options[dropdown.value].text;
        if(material=="Copper"){
            myObject.material = physicMaterials[0];
            rend.sharedMaterial = materials[0];

        }
        else if(material=="Leather"){
            myObject.material = physicMaterials[1];
            rend.sharedMaterial = materials[1];

        }
        else if (material=="Zinc"){
            myObject.material = physicMaterials[2];
            rend.sharedMaterial = materials[2];

        }
    }
}
