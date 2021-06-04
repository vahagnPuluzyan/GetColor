using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Text diamonds;
    public GameObject loadImage;

    void Update () {
        diamonds.text = PlayerPrefs.GetInt("Diamonds").ToString();
	}

    public void StartGame()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        loadImage.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        int index = PlayerPrefs.GetInt("Index");
        SceneManager.LoadScene(index);
    }
}
