using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // this will work as a temporary solution for one scene transition, until we have a proper scene manager.
        Debug.Log("hit vent");
        SceneManager.LoadScene("Kitchen");
    }
}
