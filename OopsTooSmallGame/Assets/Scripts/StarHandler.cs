using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StarHandler", menuName = "StarHandler", order = 1)]
public class StarHandler : ScriptableObject
{

    [SerializeField]
    List<string> rooms_visited = new List<string>();
    




    public void visit_room(string room_name) {
        rooms_visited.Add(room_name);
    }

    public bool is_new_room(string room_name) {
        return !rooms_visited.Contains(room_name);
    }

    


}

