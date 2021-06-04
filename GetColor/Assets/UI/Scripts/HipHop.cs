using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipHop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("HipHop") == 0)
        {
            PlayerPrefs.SetInt("HipHop", 1);
            PlayerPrefs.SetString("Dance","HipHop");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
