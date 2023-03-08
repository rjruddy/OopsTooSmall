// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CollectedStars : MonoBehaviour
// {

//     List<int> collectedStars = new List<int>();

//     void Awake() {
//         collectedStars = new List<int>();

//         DontDestroyOnLoad(gameObject);

//     }


//     void OnLevelWasLoaded ()
//    {
//      var stars = GameObject.FindObjectsOfType(typeof(Star));
//      foreach (var star in stars)
//      {
//        // Have we already collected t$$anonymous$$s coin?
//        if (collectedStars.Contains(star.StarId))
//        {
//          // If we've already collected it, then remove object from the scene
//          GameObject.Destroy(star);
//        }
//      }
//    }


//    public void CollectStar (Star star) {
//         if (collectedStars.Contains(star.starId)) {
//             return;
//         }

//         else {
//             collectedStars.Add(star.starId);
//         }

//    }

//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
