using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public GameObject firstLife;
    public GameObject secondLife;
    public GameObject thirdLife;
    public int lifeCounter = 3;


    // public AudioClip deathSound;
    // public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        firstLife.SetActive(true);
        secondLife.SetActive(true);
        thirdLife.SetActive(true);

        // audioSource = GetComponent<AudioSource>();
        // deathSound = Resources.Load<AudioClip>("Sounds/death");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool Death()
    {
        // audioSource.PlayOneShot(deathSound);
        // SoundManager.Instance.PlayDeathSound(deathSound);

        if (lifeCounter == 3)
        {
            firstLife.SetActive(false);
            lifeCounter--;
            return false;
        }
        else if(lifeCounter == 2){

            secondLife.SetActive(false);
            lifeCounter--;
            return false;
        }
        else
        {
            thirdLife.SetActive(false);
            lifeCounter = 0;
            return true;
        }
    }
}
