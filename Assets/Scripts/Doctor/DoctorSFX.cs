using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorSFX : MonoBehaviour {
	/*public AudioClip grabSound;
	public AudioClip releaseFalseSound;
	public AudioClip releaseTrueSound;
	public AudioClip hoverSound;*/
	public AudioSource sourceSound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void PlaySFX(AudioClip audio) {
		sourceSound.clip = audio;
		sourceSound.Play();
	}
}
