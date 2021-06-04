using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public ParticleSystem fire;
    [HideInInspector]public bool time =false;
    [HideInInspector] public UI ui;
    [HideInInspector] public bool win = false;
    [HideInInspector] public FloatingJoystick joy;
    public int diamonds =0;
    public GameObject winMenu;
    [HideInInspector] public bool over = false;
    [HideInInspector] public GameObject joystick;
    ThirdPersonUserControl userControl;
    

    void Start () {
        ui = FindObjectOfType<UI>();
        userControl = GetComponent<ThirdPersonUserControl>();
        AudioListener.volume = PlayerPrefs.GetInt("Volume");
        diamonds = PlayerPrefs.GetInt("Diamonds");
        joy = FindObjectOfType<FloatingJoystick>();
        joystick = joy.gameObject;
        joystick = FindObjectOfType<FloatingJoystick>().gameObject;
    }

    void Update() {
        if (!time) {
            userControl.h = joy.Horizontal;
            userControl.v = joy.Vertical;
        }
        else
        {
            userControl.h = 0;
            userControl.v = 0;
        }
        
        StartCoroutine(Couroutine(ui.timer));


        if (transform.position.y < -2)
        {
            winMenu.SetActive(false);
            GameOver();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Diamond")
        {
            diamonds++;
        }
    }
    private void OnTriggerStay(Collider other)
    {
       if (other.tag == "true" & time)
       {
            StartCoroutine(Win());
       }
    }
    void GameOver()
    {
        
        joystick.SetActive(false);

        if (!win) {
            fire.Play();
            over = true;
            Vibration.Vibrate(40);
            PlayerPrefs.SetInt("Diamonds", diamonds);
            Destroy(gameObject, 1f);
        }
        else
        {
            fire.Play();
            Destroy(gameObject);
        }

    }

    IEnumerator Couroutine(float timer)
    {
        while (ui.isPaused)
        {
            yield return null;
        }
        yield return new WaitForSecondsRealtime(timer);
        time = true;
    }

    IEnumerator Win()
    {
        if (gameObject.transform.position.y > 0) {
            joystick.SetActive(false);
            PlayerPrefs.SetInt("Diamonds",diamonds);
            win = true;
            yield return new WaitForSecondsRealtime(2.3f);
            winMenu.SetActive(true);
        }
    }
}
