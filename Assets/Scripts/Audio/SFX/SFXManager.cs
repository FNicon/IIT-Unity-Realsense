﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {
	public AudioSource sourceSound;
	public SFXContainer container;
	public bool isAllowInterruption;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Stop() {
		sourceSound.Stop();
	}
	public void PlayFromString(string input) {
		if (isAllowInterruption || !sourceSound.isPlaying) {
			int choosenIndex = FindAudioFromString(input);
			if (choosenIndex != -1) {
				AudioClip choosenSound = container.soundEffects[choosenIndex];
				PlaySFX(choosenSound);
			}
		}
	}
	public void PlaySFX(AudioClip audio) {
		sourceSound.clip = audio;
		sourceSound.Play();
		//Debug.Log(audio.name);
	}
	public int FindAudioFromString(string input) {
		int i = 0;
		//Debug.Log(container.identifier.Length);
		while ((input != container.identifier[i]) && (i < container.identifier.Length)) {
			i = i + 1;
		}
		if (i == container.identifier.Length) {
			i = -1;
			Debug.LogWarning("Audio Name Not Found! " + input);
		}
		return (i);
	}
}
