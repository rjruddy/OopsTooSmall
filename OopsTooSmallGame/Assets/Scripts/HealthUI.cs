using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private static Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SetText(string s)
    {
        healthText.text = s;
    }
}
