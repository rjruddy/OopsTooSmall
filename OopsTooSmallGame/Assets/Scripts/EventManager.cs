using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    //EVENT MANAGER HANDLES:
    // Pause button "esc" -- DONE
    // Player health updates
    // Player collectible updates
    // Game Music
    // Start is called before the first frame update

    public GameObject pauseMenu;
    public GameObject playerUI;
    public GameObject keyCollector;

    //Variables holding collectibles found in each room
    private int livCount;
    private int kitCount;
    private int bedCount;
    private int batCount;

    void Start()
    {
        pauseMenu.SetActive(false);
        keyCollector.SetActive(false);
        playerUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //check for pause 
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        //Don't display playerUI in tutorial:
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            playerUI.SetActive(false);
        }
    }

    public void DisablePause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void CollectedKey()
    {
        keyCollector.SetActive(true);
    }
}
