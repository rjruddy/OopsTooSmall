using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public EventManager evmanScript;
    public KeyHandler keyHandler;
    // public AudioClip clickSound;

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
        // SoundManager.Instance.PlayClickSound(clickSound);
        evmanScript.DisablePause();
    }

    public void QuitGame()
    {
        // SoundManager.Instance.PlayClickSound(clickSound);
        keyHandler.lose_key();
        evmanScript.DisablePause();
        SceneManager.LoadScene("TitleScreen");
    }
}
