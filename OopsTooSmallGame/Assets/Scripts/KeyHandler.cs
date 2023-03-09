using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyHandler", menuName = "KeyHandler", order = 1)]
public class KeyHandler : ScriptableObject
{

    [SerializeField]
    public bool has_key = false;

    private int starsCollected = 0;


    public bool get_key { get => has_key; }
    public int get_stars { get => starsCollected; }

    public void lose_key()
    {
        has_key = false;
    }

    public void obtain_key() {
        has_key = true;
    }

    public void IncrementStars()
    {
        starsCollected += 1;
    }

    public void reset_stars()
    {
        starsCollected = 0;
    }
}

