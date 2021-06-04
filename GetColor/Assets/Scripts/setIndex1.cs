using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setIndex1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Index") < 1) {
            PlayerPrefs.SetInt("Index", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
