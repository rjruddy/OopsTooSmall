using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player_character;
    public float screen_height;
    public float screen_width;
    private float camera_height;
    private float camera_width;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (player_character.transform.position.y > screen_height)
        { camera_height = screen_height; }
        else if (player_character.transform.position.y < -screen_height)
        { camera_height = -screen_height; }
        else { camera_height = player_character.transform.position.y; }

        if (player_character.transform.position.x > screen_width)
        { camera_width = screen_width; }
        else if (player_character.transform.position.x < -screen_width)
        { camera_width = -screen_width; }
        else { camera_width = player_character.transform.position.x; }

        this.gameObject.transform.position =
                    new Vector3(camera_width,
                                camera_height, -10);

    }
}

