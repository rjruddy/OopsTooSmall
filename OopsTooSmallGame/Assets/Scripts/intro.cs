using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    public GameObject first_intro;
    public GameObject second_intro;
    public GameObject third_intro;
    public GameObject fourth_intro;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (count == 0)
            {
                first_intro.SetActive(true);
            }
            if (count == 1)
            {
                first_intro.SetActive(false);
                second_intro.SetActive(true);
            }
            if (count == 2)
            {
                second_intro.SetActive(false);
                third_intro.SetActive(true);
            }
            if (count == 3)
            {
                third_intro.SetActive(false);
                fourth_intro.SetActive(true);
            }
            if (count == 4)
            {
                fourth_intro.SetActive(false);
                SceneManager.LoadScene("TitleScreen");
            }
            count++;
        }
    }
}
