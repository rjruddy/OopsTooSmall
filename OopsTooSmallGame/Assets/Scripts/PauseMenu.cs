using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public EventManager evmanScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeGame()
    {
        evmanScript.DisablePause();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
