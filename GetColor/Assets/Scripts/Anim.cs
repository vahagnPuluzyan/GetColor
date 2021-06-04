using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour {

   [HideInInspector] public FloatingJoystick joy;
    Animator anim;
    public Player player;
    string dance = "";

    void Start ()
    {
        anim = GetComponent<Animator>();
        dance = PlayerPrefs.GetString("Dance");
        joy = FindObjectOfType<FloatingJoystick>();
	}
	
	void Update ()
    {
        if (player.win)
        {
            anim.Play(dance);
        }
        if (joy.Horizontal != 0f || joy.Vertical != 0f)
        {
            anim.SetBool("run",true);
        }
        else
        {
            anim.SetBool("run",false);
        }
    }
}
