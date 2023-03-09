using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyHandler", menuName = "KeyHandler", order = 1)]
public class KeyHandler : ScriptableObject
{

    [SerializeField]
    public bool has_key = false;

    private int starsCollected;


    public bool get_key { get => has_key; }

    public void lose_key()
    {
        has_key = false;
    }

    public void obtain_key() {
        has_key = true;
    }
}

