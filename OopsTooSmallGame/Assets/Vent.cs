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
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        int prevSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;

        if (gameObject.tag == "f-vent" && SceneManager.sceneCountInBuildSettings > nextSceneIndex) {
            SceneManager.LoadScene(nextSceneIndex);
        }

        else if (gameObject.tag == "b-vent" && prevSceneIndex >= 0) {
            SceneManager.LoadScene(prevSceneIndex);
        }    
       
        else {
            Debug.Log("No more scenes to load");
        }  
        
    }
}
