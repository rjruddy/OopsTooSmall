using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButtons : MonoBehaviour
{
    public KeyHandler keyHandler;
    public GameObject starText;

    // Start is called before the first frame update
    void Start()
    {
        starText.GetComponent<TextMeshProUGUI>().text = "Total stars collected: " + keyHandler.get_stars;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        keyHandler.lose_key();
        keyHandler.reset_stars();
        SceneManager.LoadScene("TitleScreen");
    }

    public void RestartGame()
    {
        keyHandler.lose_key();
        keyHandler.reset_stars();
        SceneManager.LoadScene("LivingRoom");
    }
}
