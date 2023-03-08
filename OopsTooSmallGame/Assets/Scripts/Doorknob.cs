using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doorknob : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyHandler keyHandler;
    public GameObject lock_text;

    void Start()
    {
        lock_text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (keyHandler.get_key) {
            // open door
            SceneManager.LoadScene("BasementBoss");
        } else
        {
            lock_text.SetActive(true);
            Invoke("HideLockText", 3f);
        }

    }

    void HideLockText()
    {
        lock_text.SetActive(false);
    }

}
