using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doorknob : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyHandler keyHandler;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (keyHandler.get_key) {
            // open door
            SceneManager.LoadScene("BasementBoss");

        }

    }

}
