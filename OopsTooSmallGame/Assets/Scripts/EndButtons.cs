using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButtons : MonoBehaviour
{
    public KeyHandler keyHandler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        keyHandler.lose_key();
        SceneManager.LoadScene("TitleScreen");
    }

    public void RestartGame()
    {
        keyHandler.lose_key();
        SceneManager.LoadScene("LivingRoom");
    }
}
