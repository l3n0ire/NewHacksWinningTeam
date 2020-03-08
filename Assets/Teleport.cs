using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    public string PortalTo;
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other) {
        SceneManager.LoadScene(PortalTo);
    }
}
