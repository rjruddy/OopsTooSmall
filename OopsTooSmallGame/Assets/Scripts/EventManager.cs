using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //EVENT MANAGER HANDLES:
    // Pause button "esc"
    // Player health updates
    // Player collectible updates
    // Game Music
    // Start is called before the first frame update

    public GameObject PauseMenu;

    void Start()
    {
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //check for pause 
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void DisablePause()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
