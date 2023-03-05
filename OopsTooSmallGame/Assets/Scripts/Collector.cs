using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public int numCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void starCollected()
    {
        numCounter++;
        this.gameObject.GetComponent<TextMeshProUGUI>().text = "x" + numCounter;
    }
}
