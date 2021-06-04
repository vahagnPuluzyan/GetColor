using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiAnim : MonoBehaviour {

    Animator anim;
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        string dance = PlayerPrefs.GetString("Dance");
        anim.Play(dance);
	}
}
