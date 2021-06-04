using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {
    public GameObject on;
    public GameObject off;
    int volume;


	void Start () {
        volume = PlayerPrefs.GetInt("Volume");
        if (volume == 0)
        {
            on.SetActive(false);
            off.SetActive(true);
        }
        if (volume == 1)
        {
            on.SetActive(true);
            off.SetActive(false);
        }
	}
	

	void Update () {
	}

    public void Mute()
    {
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Volume", 0);
    }
    public void OnAudio()
    {
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Volume",1);
    }
}
