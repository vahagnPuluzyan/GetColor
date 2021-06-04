using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour {

    public int index = 1;
    public GameObject loadImage;

    void Start () {
        index = PlayerPrefs.GetInt("Index");
	}

    public void Next()
    {
        loadImage.SetActive(true);
        StartCoroutine(Delay());
    }


    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        index += 1;
        SceneManager.LoadScene(index);
        PlayerPrefs.SetInt("Index", index);
    }
}
