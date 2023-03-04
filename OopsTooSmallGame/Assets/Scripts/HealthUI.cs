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

    // Start is called before the first frame update
    void Start()
    {
        firstLife.SetActive(true);
        secondLife.SetActive(true);
        thirdLife.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool Death()
    {
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
