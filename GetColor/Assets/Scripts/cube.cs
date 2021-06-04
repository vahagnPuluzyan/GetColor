using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour {
    Player player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
	}

    // Update is called once per frame
    void Update() {
   if (gameObject.tag == "Untagged" && player.time)
     {
       Destroy(gameObject);
     }
    }
}
