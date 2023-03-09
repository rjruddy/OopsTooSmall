using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Star : MonoBehaviour
{

    public StarHandler starHandler;
    public string room_name;
    // Start is called before the first frame update
    void Start()
    {
        room_name = SceneManager.GetActiveScene().name; 

        if (starHandler.is_new_room(room_name)) {
            starHandler.visit_room(room_name);
        }

        else {
            Destroy(this.gameObject);
        }
 
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
